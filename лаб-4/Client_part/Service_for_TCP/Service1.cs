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

namespace Service_for_TCP
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }
        Thread T;
        bool mustStop;
        public string myIP = Dns.GetHostEntry(Dns.GetHostName()).AddressList[3].ToString();

        protected override void OnStart(string[] args)
        {
            T = new Thread(WorkerThread);
            T.Start();
        }

        protected override void OnStop()
        {
            if ((T != null) && (T.IsAlive))
            {
                mustStop = true;
            }
        }

        void WorkerThread()
        {
            while (!mustStop)
            {
                IPAddress IP = IPAddress.Parse(myIP);
                IPEndPoint ipEndPoint = new IPEndPoint(IP, 45000);
                //Socket S = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
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
                            WriteData(Request);
                            //WriteLog(Request);
                            string W = "  Ласкаво просимо в TCP-порт 45000 !!! Слава єдиній Україні!";
                            Byte[] B = Encoding.UTF8.GetBytes(W);
                            H.Send(B);
                            H.Shutdown(SocketShutdown.Both);
                        }
                    }
                }
                catch (Exception e)
                {
                    WriteLog(e.Message);
                }
            }
        }

        private static void WriteLog(string z)
        {
            using (StreamWriter F = new StreamWriter("C:\\lab_sys\\TCP-Req.log", true))
            {
                F.WriteLine(DateTime.Now + "  " + z);
            }
        }
        public string CreateXML(string fullPath)
        {
            string nameXML = "Request-1.xml";
            XDocument request1 = new XDocument(new XElement("root",
                new XElement("path", fullPath)));
            request1.Save(nameXML);
            return nameXML;
        }
        private static void WriteData(string data)
        {
            using (FileStream stream = new FileStream("C:\\lab_sys\\Server\\Request-1.xml", FileMode.Create))
            {
                using (BinaryWriter F = new BinaryWriter(stream))
                {
                    byte[] text = Encoding.UTF8.GetBytes(data);
                    F.Write(text);
                }
            }
        }
        private void WQL_request()
        {
            XDocument req = XDocument.Load("C:\\lab_sys\\Server\\Request-1.xml");
            XElement root = req.Element("root");
            XElement path = req.Element("path");
            string reqPath = path.Value;
        }
    }
}
