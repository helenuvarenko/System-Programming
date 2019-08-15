using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Xml.Linq;

namespace TCP_Client_Server
{
    public partial class Form1 : Form
    {
        private string fullPath, nameXML;//, A;
        protected string Answer;
        public string processToKill;
        public bool second = false;
        public string button2clicked="false";
        public Form1()
        {
            InitializeComponent();
            string myIP = Dns.GetHostEntry(Dns.GetHostName()).AddressList[3].ToString();
            textBox1.Text = myIP;
            button2.Enabled = false;
        }
        public void Speaking(string nameofXML, string serverIP)
        {
            IPAddress IP = IPAddress.Parse(serverIP);
            byte[] M = File.ReadAllBytes(nameofXML);
            IPEndPoint ipEndPoint = new IPEndPoint(IP, 45000);
            byte[] bytes = new byte[1000000];
            using (Socket S = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                S.Connect(ipEndPoint);
                S.Send(M);
                int bytesRec = S.Receive(bytes);
                string getResponse = Encoding.UTF8.GetString(bytes, 0, bytesRec);
                WriteData("RespFromServer", getResponse);
                FillList();
                button2.Enabled = true;
                //if (second)
                //{
                //    byte[] bytesSec = new byte[1000000];
                //    byte[] MC = File.ReadAllBytes(processToKill);
                //    S.Send(MC);
                //    int bytesRecSec = S.Receive(bytesSec);
                //    string getResponseSec = Encoding.UTF8.GetString(bytesSec, 0, bytesRecSec);
                //    WriteData("SecondRespFromServer", getResponseSec);
                //    MessageBox.Show(AnswerFromXML());
                //    S.Shutdown(SocketShutdown.Both);
                //    WriteLog(AnswerFromXML());
                //}
               S.Shutdown(SocketShutdown.Both);
            }
        }
        public void SecondSpeaking(string serverIP)
        {
            IPAddress IP = IPAddress.Parse(serverIP);
            byte[] M = File.ReadAllBytes(processToKill);
            IPEndPoint ipEndPoint = new IPEndPoint(IP, 45000);
            byte[] bytes = new byte[1000000];
            using (Socket S = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                S.Connect(ipEndPoint);
                byte[] bt2cl = Encoding.UTF8.GetBytes(button2clicked);
                S.Send(bt2cl);
                S.Send(M);
                int bytesRecSec = S.Receive(bytes);
                string getResponseSec = Encoding.UTF8.GetString(bytes, 0, bytesRecSec);
                WriteData("SecondRespFromServer", getResponseSec);
                MessageBox.Show(AnswerFromXML());
                S.Shutdown(SocketShutdown.Both);
                WriteLog(AnswerFromXML());
            }
        }
        private static void WriteLog(string z)
        {
            using (StreamWriter F = new StreamWriter("C:\\lab_sys\\TCP-Responce.log", true))
            {
                F.WriteLine(DateTime.Now + z);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            fullPath = textBox2.Text;
            nameXML = CreateXML(fullPath);
            Speaking(nameXML, textBox1.Text);
        }

        private void FillList()
        {
            XDocument resp = XDocument.Load("C:\\lab_sys\\Client\\RespFromServer.xml");
            var query =
                from objProcesses in resp.Descendants("Process")
                let kernel = (UInt64)objProcesses.Element("KernelModeTime")
                orderby kernel descending
                select (string)objProcesses.Element("Name");
            foreach (string name in query)
            {
                if (name != "") comboBox1.Items.Add(name);
            }
        }
        public string AnswerFromXML()
        {
            XDocument response2 = XDocument.Load("C:\\lab_sys\\Client\\SecondRespFromServer.xml");
            XElement root = response2.Element("root");
            XElement answer = root.Element("answer");
            string ans = answer.Value;
            return ans;
        }
        public string CreateXML(string fullPath)
        {
            string nameXML = "C:\\lab_sys\\Client\\Request-1.xml";
            XDocument request1 = new XDocument(new XElement("root",
                new XElement("path", fullPath)));
            request1.Save(nameXML);
            return nameXML;
        }
        public string CreateXMLtoKill(string procName)
        {
            string nameXML = "C:\\lab_sys\\Client\\Request-2.xml";
            XDocument request1 = new XDocument(new XElement("root",
                new XElement("name", procName)));
            request1.Save(nameXML);
            return nameXML;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            processToKill = CreateXMLtoKill(comboBox1.Text);
            second = true;
            button2clicked = "true";
            SecondSpeaking(textBox1.Text);

        }
        private static void WriteData(string name,string data)
        {
            using (FileStream stream = new FileStream("C:\\lab_sys\\Client\\"+name+".xml", FileMode.Create))
            {
                using (BinaryWriter F = new BinaryWriter(stream))
                {
                    byte[] text = Encoding.UTF8.GetBytes(data);
                    F.Write(text);
                }
            }
        }
    }

}
