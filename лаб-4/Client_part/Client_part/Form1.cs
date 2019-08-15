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

namespace Client_part
{
    public partial class Form1 : Form
    {
        string fullPath, nameXML, A;
        protected string Answer;
        public string myIP = Dns.GetHostEntry(Dns.GetHostName()).AddressList[3].ToString();
        public Form1()
        {
            InitializeComponent();
        }
        public string Speaking(string nameofXML, string serverIP)
        {
            IPAddress IP = IPAddress.Parse(serverIP);
            byte[] M = Encoding.UTF8.GetBytes(nameXML);
            IPEndPoint ipEndPoint = new IPEndPoint(IP, 45000);
            byte[] bytes = new byte[1000000];
            using (Socket S = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                S.Connect(ipEndPoint);
                S.Send(M);
                int bytesRec = S.Receive(bytes);
                Answer = Encoding.UTF8.GetString(bytes, 0, bytesRec);
                S.Shutdown(SocketShutdown.Both);
                return Answer;
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
            textBox1.Text = myIP;
            button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            fullPath = textBox2.Text;
            nameXML = CreateXML(fullPath);
        }
        public string CreateXML(string fullPath)
        {
            string nameXML = "Request-1.xml";
            XDocument request1 = new XDocument(new XElement("root",
                new XElement("path", fullPath)));
            request1.Save(nameXML);
            return nameXML;
        }
    }
    
}
