using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Registry_param_5_task_6_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string Path = "HKEY_LOCAL_MACHINE\\Software\\UVARENKO";
        private void button1_Click(object sender, EventArgs e)
        {
            
            Registry.SetValue(Path, "P5", new string[] { "Я-", "студент", "кафедри", "Комп'ютерної інженерії!!!" }, RegistryValueKind.MultiString);
            MessageBox.Show("This task was done successfully!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] oldText = (string[])Registry.GetValue(Path, "P6", "nothing to show :(");
            string text = "";
            for (int i = 0; i < oldText.Length; i++)
            {
                text += "\n" + oldText[i];
            }
            MessageBox.Show(text);
        }
    }
}
