using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Management;

namespace TCP_Service
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }
        Thread T, Th;
        bool mustStop, mustStopSecond;
        public bool extra;
        public string myIP = Dns.GetHostEntry(Dns.GetHostName()).AddressList[3].ToString();

        protected override void OnStart(string[] args)
        {
            extra = false;
            T = new Thread(WorkerThread);
            T.Start();
            //Th = new Thread(SecondWorkerThread);
            //Th.Start();

        }

        protected override void OnStop()
        {
            if ((T != null) && (T.IsAlive))
            {
                mustStop = true;
            }
            if ((Th != null) && (Th.IsAlive))
            {
                mustStopSecond = true;
            }
        }

        void WorkerThread()
        {
            while (!mustStop)
            {
                IPAddress IP = IPAddress.Parse(myIP);
                IPEndPoint ipEndPoint = new IPEndPoint(IP, 45000);
                Socket S = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    S.Bind(ipEndPoint);
                    S.Listen(10);

                    while (true)
                    {
                        using (Socket H = S.Accept())
                        {
                            IPEndPoint L = new IPEndPoint(IP, 0);
                            EndPoint R = (EndPoint)(L);
                            byte[] D = new byte[1000000];
                            int Receive = H.ReceiveFrom(D, ref R);
                            string Request = Encoding.UTF8.GetString(D, 0, Receive);
                            WriteData("ReqFromClient", Request);
                            string responseFirst = WQL_request();
                            byte[] respF = File.ReadAllBytes(responseFirst);
                            H.Send(respF);
                            Receive = H.ReceiveFrom(D, ref R);
                            Request = Encoding.UTF8.GetString(D, 0, Receive);
                            if (Request=="true")
                            {
                                Receive = H.ReceiveFrom(D, ref R);
                                Request = Encoding.UTF8.GetString(D, 0, Receive);
                                WriteData("SecondReqFromClient", Request);
                                string Answer = Killer();
                                WriteLog(Answer);
                                string AnswerFile = CreateXMLAnswer(Answer);
                                byte[] respS = File.ReadAllBytes(AnswerFile);
                                H.Send(respS);
                            }
                            H.Shutdown(SocketShutdown.Both);
                        }
                    }
                }
                catch (Exception e)
                {
                    // WriteLog(e.Message);
                }
            }
        }
        //void SecondWorkerThread()
        //{
        //    while (!mustStopSecond)
        //    {
        //        IPAddress IP = IPAddress.Parse(myIP);
        //        IPEndPoint ipEndPoint = new IPEndPoint(IP, 45000);
        //        Socket S = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //        try
        //        {
        //            S.Bind(ipEndPoint);
        //            S.Listen(10);

        //            while (true)
        //            {
        //                using (Socket H = S.Accept())
        //                {
        //                    IPEndPoint L = new IPEndPoint(IP, 0);
        //                    EndPoint R = (EndPoint)(L);
        //                    byte[] G = new byte[1000000];
        //                    int Rec = H.ReceiveFrom(G, ref R);
        //                    string Req = Encoding.UTF8.GetString(G, 0, Rec);
        //                    string Answer = Killer(Req);
        //                    string AnswerFile = CreateXMLAnswer(Answer);
        //                    byte[] respS = File.ReadAllBytes(AnswerFile);
        //                    H.Send(respS);
        //                    H.Shutdown(SocketShutdown.Both);
        //                }
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            WriteLog(e.Message);
        //        }
        //    }
        //}
        private static void WriteLog(string z)
        {
            using (StreamWriter F = new StreamWriter("C:\\lab_sys\\TCP-Req.log", true))
            {
                F.WriteLine(DateTime.Now + "  " + z);
            }
        }
        public string CreateXMLAnswer(string answer)
        {
            string nameXML = "C:\\lab_sys\\Server\\Response-2.xml";
            XDocument request1 = new XDocument(new XElement("root",
                new XElement("answer", answer)));
            request1.Save(nameXML);
            return nameXML;
        }
        private static void WriteData(string name, string data)
        {
            using (FileStream stream = new FileStream("C:\\lab_sys\\Server\\" + name + ".xml", FileMode.Create))
            {
                using (BinaryWriter F = new BinaryWriter(stream))
                {
                    byte[] text = Encoding.UTF8.GetBytes(data);
                    F.Write(text);
                }
            }
        }
        private static string WQL_request()
        {
            XDocument req = XDocument.Load("C:\\lab_sys\\Server\\ReqFromClient.xml");
            XElement root = req.Element("root");
            XElement path = root.Element("path");
            string reqPath = path.Value;
            string respName = "C:\\lab_sys\\Server\\Response-1.xml";
            XDocument resp = new XDocument(new XElement("Root"));
            //COLLECTION
            ManagementScope S = new ManagementScope(@"\\.\ROOT\cimv2");
            ObjectQuery Q;
            //create object query
            if (reqPath != "")
            {
                Q = new ObjectQuery("SELECT * FROM Win32_Process where ExecutablePath like '" + reqPath + ":%'");
            }
            else Q = new ObjectQuery("SELECT * FROM Win32_Process");
            WriteLog(Q.QueryString.ToString());
            //create object searcher
            ManagementObjectSearcher F = new ManagementObjectSearcher(S, Q);
            //get collection of WMI objects
            ManagementObjectCollection queryCollection = F.Get();
            //enumerate the collection.
            foreach (ManagementObject m in queryCollection)
            {
                resp.Element("Root").Add(new XElement("Process",
                    new XElement("Name", m["Name"]),
                    new XElement("Description", m["Description"]),
                    new XElement("ExecutablePath", m["ExecutablePath"]),
                    new XElement("KernelModeTime", m["KernelModeTime"])));
            }
            resp.Save(respName);
            return respName;
        }
        private static string Killer()
        {
            try
            {
                //XDocument req = XDocument.Load("C:\\lab_sys\\Server\\extra.xml");
                XDocument req = XDocument.Load("C:\\lab_sys\\Server\\SecondReqFromClient.xml");
                XElement root = req.Element("root");
                XElement name = root.Element("name");
                string reqName = name.Value;
                ManagementScope S = new ManagementScope(@"\\.\ROOT\cimv2");
                //create object query
                ObjectQuery Q = new ObjectQuery("SELECT * FROM Win32_Process where Name='" + reqName + "'");
                WriteLog(Q.QueryString.ToString());
                //create object searcher
                ManagementObjectSearcher F = new ManagementObjectSearcher(S, Q);
                //get collection of WMI objects
                ManagementObjectCollection queryCollection = F.Get();
                //enumerate the collection.
                foreach (ManagementObject m in queryCollection)
                {
                    object[] IN = { 128 };
                    object R = m.InvokeMethod("Terminate", IN);
                }
                return "Процес зупинено! ^_^";
            }
            catch (Exception e)
            {
                WriteLog(" Killer:" + e.Message);
                return " Killer:" + e.Message;
            }

        }

    }
}
