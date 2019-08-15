using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace MS_Sql
{
    public partial class Form1 : Form
    {
        Form Type;
        bool TypeCreated = false;
        string connectionString = @"Data Source=DESKTOP-O41O67V\SQLEXPRESS;Initial Catalog=BeautySalon;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
        }
        private bool CheckINT(string text)
        {
            Regex Sample = new Regex(@"^[0-9]{0,10}");
            Match result = Sample.Match(text);
            return result.Success;
        }
        private void IntError(TextBox t)
        {
            int i;
            //Int32.TryParse(t.Text, out i);
            //if (!CheckINT(t.Text) && t.Text != "")
            //{
            //    errorProvider.SetError(t, "Only DIGITALS are allowed here!");
            //    buttonQUERY.Enabled = false;
            //}
            if (!Int32.TryParse(t.Text, out i) || i < 0)
            {
                errorProvider.SetError(t, "Enter POSITIVE ( > 0 ) value!");
                buttonQUERY.Enabled = false;
            }
            else
            {
                errorProvider.Clear();
                buttonQUERY.Enabled = true;
            }
        }
        public bool CheckText(string text)
        {
            Regex Sample = new Regex("^[а-яА-ЯёЁa-zA-Z]{1,20}$");
            Match result = Sample.Match(text);
            return result.Success;
        }
        public void TextError(TextBox t)
        {
            if ((!CheckText(t.Text)) && (t.Text != ""))
            {
                errorProvider.SetError(t, "Only LETTERS are allowed!");
                buttonQUERY.Enabled = false;
            }
            else
            {
                errorProvider.Clear();
                buttonQUERY.Enabled = true;
            }
        }
        public void GetQuery(string com)
        {
            DataSet data = new DataSet();
            string command = com;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlDataAdapter ad = new SqlDataAdapter(command, connectionString);
                ad.Fill(data);
            }
        }
        public void CheckStart(string select, string insert) //перевірка наявності початкових рядків (значень) у таблиці
        {
            DataSet data = new DataSet();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlDataAdapter ad = new SqlDataAdapter(select, connectionString);
                ad.Fill(data);
            }
            try
            {
                string s = data.Tables[0].Rows[0][0].ToString();
            }
            catch
            {
                GetQuery(insert);
            }
        }
        public void FillTypes() //заповнення випадаючого списку типів
        {
            DataSet data = new DataSet();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlDataAdapter ad = new SqlDataAdapter("SELECT Category_Name From Category", connectionString);
                ad.Fill(data);
            }
            comboBoxTYPE.Items.Clear();
            for (int i = 0; i < data.Tables[0].Rows.Count; i++)
                comboBoxTYPE.Items.Add(data.Tables[0].Rows[i][0]);
        }

        private void comboBoxTYPE_Click(object sender, EventArgs e)
        {
            FillTypes();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckStart("Select Category_Name From Category where Category_Name='Haircut'", "insert into [Category] (Category_Name, description) values ('Haircut', 'cuttin your hair away' )");
            CheckStart("Select Category_Name From Category where Category_Name='Nails'", "insert into [Category] (Category_Name, description) values ('Nails', 'Polishing your nails' )");

            FillTypes();
        }

        private void textBoxID_Validating(object sender, CancelEventArgs e)
        {
            IntError(textBoxID);
        }

        private void textBoxNAME_Validating(object sender, CancelEventArgs e)
        {
            TextError(textBoxNAME);
        }

        private void textBoxPRICE_Validating(object sender, CancelEventArgs e)
        {
            IntError(textBoxPRICE);
        }

        private void textBoxMASTER_Validating(object sender, CancelEventArgs e)
        {
            TextError(textBoxMASTER);
        }

        private void textBoxDURATION_TextChanged(object sender, EventArgs e)
        {
            IntError(textBoxDURATION);
        }

        private void checkBoxID_CheckedChanged(object sender, EventArgs e)
        {
            if ((radioButtonGET.Checked) || (radioButtonDELETE.Checked))
            {
                if (checkBoxID.Checked)
                {
                    textBoxID.Enabled = true;
                    textBoxNAME.Enabled = false;
                    textBoxMASTER.Enabled = false;
                    textBoxPRICE.Enabled = false;
                    textBoxDURATION.Enabled = false;
                    comboBoxTYPE.Enabled = false;
                }
                else
                {
                    if (!checkBoxTYPE.Checked)
                    {
                        textBoxID.Enabled = false;
                        textBoxNAME.Enabled = false;
                        textBoxMASTER.Enabled = false;
                        textBoxPRICE.Enabled = false;
                        textBoxDURATION.Enabled = false;
                        comboBoxTYPE.Enabled = false;
                    }
                    else
                        textBoxID.Enabled = false;
                }
                if ((checkBoxID.Checked) && (checkBoxTYPE.Checked))
                {
                    textBoxID.Enabled = true;
                    comboBoxTYPE.Enabled = true;
                }
            }
        }

        private void checkBoxTYPE_CheckedChanged(object sender, EventArgs e)
        {
            if ((radioButtonGET.Checked) || (radioButtonDELETE.Checked))
            {
                if (checkBoxTYPE.Checked)
                {
                    textBoxID.Enabled = false;
                    textBoxNAME.Enabled = false;
                    textBoxMASTER.Enabled = false;
                    textBoxPRICE.Enabled = false;
                    textBoxDURATION.Enabled = false;
                    comboBoxTYPE.Enabled = true;
                }
                else
                {
                    if (!checkBoxID.Checked)
                    {
                        textBoxID.Enabled = false;
                        textBoxNAME.Enabled = false;
                        textBoxMASTER.Enabled = false;
                        textBoxPRICE.Enabled = false;
                        textBoxDURATION.Enabled = false;
                        comboBoxTYPE.Enabled = false;
                    }
                    else
                        comboBoxTYPE.Enabled = false;
                }
                if ((checkBoxID.Checked) && (checkBoxTYPE.Checked))
                {
                    textBoxID.Enabled = true;
                    comboBoxTYPE.Enabled = true;
                }
            }
        }

        private void radioButtonGET_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonGET.Checked)
            {
                checkBoxID.Enabled = true;
                checkBoxTYPE.Enabled = true;
                textBoxID.Enabled = true;
                textBoxNAME.Enabled = false;
                textBoxMASTER.Enabled = false;
                textBoxPRICE.Enabled = false;
                textBoxDURATION.Enabled = false;
                comboBoxTYPE.Enabled = false;
            }
            else
            {
                checkBoxID.Enabled = false;
                checkBoxTYPE.Enabled = false;
                checkBoxID.Checked = false;
                checkBoxTYPE.Checked = false;
                textBoxID.Enabled = false;
                textBoxNAME.Enabled = true;
                textBoxMASTER.Enabled = true;
                textBoxPRICE.Enabled = true;
                textBoxDURATION.Enabled = true;
                comboBoxTYPE.Enabled = true;
            }
        }

        private void radioButtonDELETE_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonDELETE.Checked)
            {
                checkBoxID.Enabled = true;
                checkBoxTYPE.Enabled = true;
                textBoxID.Enabled = true;
                textBoxNAME.Enabled = false;
                textBoxMASTER.Enabled = false;
                textBoxPRICE.Enabled = false;
                textBoxDURATION.Enabled = false;
                comboBoxTYPE.Enabled = false;
            }
            else
            {
                checkBoxID.Enabled = false;
                checkBoxTYPE.Enabled = false;
                checkBoxID.Checked = false;
                checkBoxTYPE.Checked = false;
                textBoxID.Enabled = false;
                textBoxNAME.Enabled = true;
                textBoxMASTER.Enabled = true;
                textBoxPRICE.Enabled = true;
                textBoxDURATION.Enabled = true;
                comboBoxTYPE.Enabled = true;
            }
        }

        private void radioButtonUPDATE_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonUPDATE.Checked)
            {
                textBoxID.Enabled = true;
            }
            else
            {
                textBoxID.Enabled = false;
            }
        }

        private void buttonTYPE_Click(object sender, EventArgs e)
        {
            if (!TypeCreated)
            {
                Type = new Type(this);
                TypeCreated = true;
            }
            Type.Show();
            this.Hide();
        }
    }
}
