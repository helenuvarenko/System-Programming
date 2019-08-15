using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            using (ServiceReference1.Service1Client log = new ServiceReference1.Service1Client())
            {
                label5.Text = log.IsLoginFree(textBox1.Text).ToString();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            using (ServiceReference1.Service1Client ip = new ServiceReference1.Service1Client())
            {
                label6.Text = ip.MyIPAddress();
            }
        }
    }
}
