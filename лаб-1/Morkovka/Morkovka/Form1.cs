using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Morkovka
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string caption = "Добре", text = "Правильно! Морковка дуже корисна!";
            MessageBoxButtons button = MessageBoxButtons.OK;
            MessageBoxIcon icon = MessageBoxIcon.Information;
            this.Hide();
            MessageBox.Show(text, caption, button, icon);
            Application.Exit();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string caption = "Погано", text = "Дуже прикро:((\nНаступного разу не забудьте про морковку!";
            MessageBoxButtons button = MessageBoxButtons.OK;
            MessageBoxIcon icon = MessageBoxIcon.Information;
            this.Hide();
            MessageBox.Show(text, caption, button, icon);
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string caption = "Ухилення від запитання", text = "Ви ухилились від запитання!\nЯкщо ви не будете їсти морковку.. Краще не буде!(";
            MessageBoxButtons button = MessageBoxButtons.OK;
            MessageBoxIcon icon = MessageBoxIcon.Error;
            this.Hide();
            MessageBox.Show(text, caption, button, icon);
            Application.Exit();

        }
    }
}
