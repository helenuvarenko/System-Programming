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


namespace MS_SQL_1
{
    public partial class Category : Form
    {
        Form form;
        string connectionString = @"Data Source=DESKTOP-O41O67V\SQLEXPRESS;Initial Catalog=BeautySalon;Integrated Security=True";
        public Category(Form Form1)
        {
            this.form = Form1;
            InitializeComponent();
        }

        private void Category_Load(object sender, EventArgs e)
        {

            CheckStart("Select Category_Name From Category where Category_Name='Haircut'", "insert into [Category] (Category_Name, Description) values ('Haircut', 'cuttin your hair away' )");
            CheckStart("Select Category_Name From Category where Category_Name='Nails'", "insert into [Category] (Category_Name, Description) values ('Nails', 'Polishing your nails' )");

        }

        private void radioButtonGET_CheckedChanged(object sender, EventArgs e)
        {
            textBoxID.Enabled = !textBoxID.Enabled;
            textBoxNAME.Enabled = !textBoxNAME.Enabled;
            textBoxDESCRIPTION.Enabled = !textBoxDESCRIPTION.Enabled;
            buttonQUERY.Enabled = true;
            errorProvider.Clear();
            textBoxResult.Text = string.Empty;
            textBoxID.Text = "ID";
            textBoxNAME.Text = "Name";
            textBoxDESCRIPTION.Text = "Description";

        }

        private void radioButtonADD_CheckedChanged(object sender, EventArgs e)
        {
            textBoxID.Enabled = !textBoxID.Enabled;
            textBoxNAME.Enabled = true;
            textBoxDESCRIPTION.Enabled = true;
            buttonQUERY.Enabled = false;
            errorProvider.Clear();
            textBoxResult.Text = string.Empty;
            textBoxID.Text = "ID";
            textBoxNAME.Text = "Name";
            textBoxDESCRIPTION.Text = "Description";
        }

        private void radioButtonUPDATE_CheckedChanged(object sender, EventArgs e)
        {
            textBoxID.Enabled = true;
            textBoxNAME.Enabled = true;
            textBoxDESCRIPTION.Enabled = true;
            buttonQUERY.Enabled = false;
            errorProvider.Clear();
            textBoxResult.Text = string.Empty;
            textBoxID.Text = "ID";
            textBoxNAME.Text = "Name";
            textBoxDESCRIPTION.Text = "Description";
        }

        private void radioButtonDELETE_CheckedChanged(object sender, EventArgs e)
        {
            textBoxNAME.Enabled = !textBoxNAME.Enabled;
            textBoxDESCRIPTION.Enabled = !textBoxDESCRIPTION.Enabled;
            buttonQUERY.Enabled = false;
            errorProvider.Clear();
            textBoxResult.Text = string.Empty;
            textBoxID.Text = "ID";
            textBoxNAME.Text = "Name";
            textBoxDESCRIPTION.Text = "Description";
        }

        private void textBoxID_TextChanged(object sender, EventArgs e)
        {
            if (radioButtonDELETE.Checked == true)
            {
                if (IntError(textBoxID))
                {
                    buttonQUERY.Enabled = true;
                }
                else buttonQUERY.Enabled = false;
            }
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            form.Show();
        }

        private void textBoxID_Validating(object sender, CancelEventArgs e)
        {
            if (radioButtonDELETE.Checked == false)
            {
                if (!IntError(textBoxID)) e.Cancel = true;
            }
        }

        private void textBoxNAME_Validating(object sender, CancelEventArgs e)
        {
            if (!TextError(textBoxNAME)) e.Cancel = true;
        }

        private void textBoxDESCRIPTION_Validating(object sender, CancelEventArgs e)
        {
            if (!TextError(textBoxDESCRIPTION)) e.Cancel = true;
        }
        private bool CheckINT(string text)
        {
            Regex Sample = new Regex(@"^[0-9]{0,10}");
            Match result = Sample.Match(text);
            return result.Success;
        }
        private bool IntError(TextBox t)
        {
            if (!Int32.TryParse(t.Text, out int i))
            {
                errorProvider.SetError(t, "Enter Only DIGITALS here!");
                buttonQUERY.Enabled = false;
                return false;
            }
            else if (i <= 0)
            {
                errorProvider.SetError(t, "Enter SOME POSITIVE ( > 0 ) value!");
                buttonQUERY.Enabled = false;
                return false;
            }


            else
            {
                errorProvider.Clear();
                buttonQUERY.Enabled = true;
                return true;
            }
        }
        public bool CheckText(string text)
        {
            Regex Sample = new Regex("^[а-яА-ЯёЁa-zA-Z]{1,20}$");
            Match result = Sample.Match(text);
            return result.Success;
        }
        public bool TextError(TextBox t)
        {
            if (t.Text == String.Empty)
            {
                errorProvider.SetError(t, "Enter some text!");
                buttonQUERY.Enabled = false;
                return false;
            }
            else if (!CheckText(t.Text))
            {
                errorProvider.SetError(t, "Enter Only LETTERS here!");
                buttonQUERY.Enabled = false;
                return false;
            }

            else
            {
                errorProvider.Clear();
                buttonQUERY.Enabled = true;
                return true;
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

        private void Category_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            form.Show();
        }

        private void buttonQUERY_Click_1(object sender, EventArgs e)
        {
            int a;
            string query = "";
            string res = "";
            if (radioButtonGET.Checked)
            {
                res = "row(s) selected";
                query = "select * from Category";
            }
            if (radioButtonADD.Checked && textBoxNAME.Text != "" && textBoxDESCRIPTION.Text != "")
            {
                res = "1 row(s) inserted";
                query = @"insert into Category (Category_Name, Description) values (N'" + textBoxNAME.Text + "', " + " N'" + textBoxDESCRIPTION.Text + "'" + ")";
            }
            if (radioButtonUPDATE.Checked && textBoxID.Text != "" && textBoxNAME.Text != "" && textBoxDESCRIPTION.Text != "")
            {
                res = "1 row(s) updated";
                query = @"update Category set Category_Name = N'" + textBoxNAME.Text + "'" + "," + " Description  =N'" + textBoxDESCRIPTION.Text + "'" + " where ID=" + textBoxID.Text;
            }
            if (radioButtonDELETE.Checked && textBoxID.Text != "")
            {
                res = "1 row(s) deleted";
                query = "delete Category where ID = " + textBoxID.Text;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlDataAdapter adapt = new SqlDataAdapter(query, conn);
                    DataSet data = new DataSet();
                    adapt.Fill(data);
                    dataGridView1.Visible = true;
                    if (radioButtonGET.Checked)
                    {
                        dataGridView1.DataSource = data.Tables[0];
                    }
                    else
                    {
                        adapt = new SqlDataAdapter("select * from Category", connectionString);
                        data = new DataSet();
                        adapt.Fill(data);
                        dataGridView1.DataSource = data.Tables[0];
                    }
                }

                errorProvider.Clear();
                textBoxResult.Text = res;

                textBoxID.Text = "ID";
                textBoxNAME.Text = "Name";
                textBoxDESCRIPTION.Text = "MASTER Name";
            }
            catch (Exception exc) { MessageBox.Show(exc.Message); };
        }
    }
}
