using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            using (ServiceReference1.Service1Client serv = new ServiceReference1.Service1Client())
            {
                dataGridView1.DataSource = serv.GetAllRows();
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                    dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                using (ServiceReference1.Service1Client serv = new ServiceReference1.Service1Client())
            {
                dataGridView2.DataSource = serv.GetRowByID(int.Parse(textBox2.Text));
                for (int i = 0; i < dataGridView2.ColumnCount; i++)
                    dataGridView2.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
            }
            else MessageBox.Show("Введіть бажаний ID(число)!");
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                using (ServiceReference1.Service1Client serv = new ServiceReference1.Service1Client())
                {
                    label3.Text = serv.F4(double.Parse(textBox1.Text)).ToString();
                }
            }
            else MessageBox.Show("Вводьте лише число!");
        }
    }
}
