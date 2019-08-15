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
using MS_SQL_1;

namespace MS_Sql
{
    public partial class Form1 : Form
    {
        Form Category;
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
            if (radioButtonDELETE.Checked == false)
            {
                if (!IntError(textBoxID)) e.Cancel = true;
            }

        }

        private void textBoxNAME_Validating(object sender, CancelEventArgs e)
        {
            if (!TextError(textBoxNAME)) e.Cancel = true;
        }

        private void textBoxPRICE_Validating(object sender, CancelEventArgs e)
        {
            if (!IntError(textBoxPRICE)) e.Cancel = true;
        }

        private void textBoxMASTER_Validating(object sender, CancelEventArgs e)
        {
            if (!TextError(textBoxMASTER)) e.Cancel = true;
        }



        private void checkBoxID_CheckedChanged(object sender, EventArgs e)
        {
            FillTypes();
            textBoxID.Enabled = !textBoxID.Enabled;
        }

        private void checkBoxTYPE_CheckedChanged(object sender, EventArgs e)
        {
            FillTypes();
            comboBoxTYPE.Enabled = !comboBoxTYPE.Enabled;
        }
        private void radioButtonGET_CheckedChanged(object sender, EventArgs e)
        {
            textBoxID.Enabled = !textBoxID.Enabled;
            textBoxNAME.Enabled = !textBoxNAME.Enabled;
            textBoxMASTER.Enabled = !textBoxMASTER.Enabled;
            textBoxPRICE.Enabled = !textBoxPRICE.Enabled;
            textBoxDURATION.Enabled = !textBoxDURATION.Enabled;
            comboBoxTYPE.Enabled = !comboBoxTYPE.Enabled;
            buttonQUERY.Enabled = true;
            errorProvider.Clear();
            textBoxResult.Text = string.Empty;
            textBoxID.Text = "ID";
            textBoxNAME.Text = "Name";
            textBoxMASTER.Text = "MASTER Name";
            textBoxDURATION.Text = "DURATION";
            textBoxPRICE.Text = "PRICE";
            comboBoxTYPE.Text = "";
        }
        private void radioButtonADD_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxTYPE.Enabled = !checkBoxTYPE.Enabled;
            checkBoxID.Enabled = !checkBoxID.Enabled;
            checkBoxTYPE.Checked = false;
            checkBoxID.Checked = false;
            textBoxID.Enabled = !textBoxID.Enabled;
            textBoxNAME.Enabled = true;
            textBoxMASTER.Enabled = true;
            textBoxPRICE.Enabled = true;
            textBoxDURATION.Enabled = true;
            comboBoxTYPE.Enabled = true;
            buttonQUERY.Enabled = false;
            errorProvider.Clear();
            textBoxResult.Text = string.Empty;
            textBoxID.Text = "ID";
            textBoxNAME.Text = "Name";
            textBoxMASTER.Text = "MASTER Name";
            textBoxDURATION.Text = "DURATION";
            textBoxPRICE.Text = "PRICE";
            comboBoxTYPE.Text = "";
        }

        private void radioButtonDELETE_CheckedChanged(object sender, EventArgs e)
        {
            textBoxID.Enabled = true;
            checkBoxTYPE.Checked = false;
            checkBoxID.Checked = false;
            textBoxNAME.Enabled = !textBoxNAME.Enabled;
            textBoxPRICE.Enabled = !textBoxPRICE.Enabled;
            textBoxMASTER.Enabled = !textBoxMASTER.Enabled;
            textBoxDURATION.Enabled = !textBoxDURATION.Enabled;
            checkBoxTYPE.Enabled = !checkBoxTYPE.Enabled;
            checkBoxID.Enabled = !checkBoxID.Enabled;
            comboBoxTYPE.Enabled = !comboBoxTYPE.Enabled;
            buttonQUERY.Enabled = false;
            errorProvider.Clear();
            textBoxResult.Text = string.Empty;
            textBoxID.Text = "ID";
            textBoxNAME.Text = "Name";
            textBoxMASTER.Text = "MASTER Name";
            textBoxDURATION.Text = "DURATION";
            textBoxPRICE.Text = "PRICE";
            comboBoxTYPE.Text = "";
        }
        private void radioButtonUPDATE_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxTYPE.Enabled = !checkBoxTYPE.Enabled;
            checkBoxID.Enabled = !checkBoxID.Enabled;
            checkBoxTYPE.Checked = false;
            checkBoxID.Checked = false;
            textBoxID.Enabled = true;
            textBoxNAME.Enabled = true;
            textBoxMASTER.Enabled = true;
            textBoxPRICE.Enabled = true;
            textBoxDURATION.Enabled = true;
            comboBoxTYPE.Enabled = true;
            buttonQUERY.Enabled = false;
            errorProvider.Clear();
            textBoxResult.Text = string.Empty;
            textBoxID.Text = "ID";
            textBoxNAME.Text = "Name";
            textBoxMASTER.Text = "MASTER Name";
            textBoxDURATION.Text = "DURATION";
            textBoxPRICE.Text = "PRICE";
            comboBoxTYPE.Text = "";
        }

        private void buttonTYPE_Click(object sender, EventArgs e)
        {
            if (!TypeCreated)
            {
                Category = new Category(this);
                TypeCreated = true;
            }
            Category.Show();
            this.Hide();
        }

        private void buttonQUERY_Click(object sender, EventArgs e)
        {
            int a;
            string query = "";
            string res = "";
            if (radioButtonGET.Checked)
            {
                res = "row(s) selected";
                query = "select b.ID, b.service, b.price, b.master, b.duration, b.categoryid, c.Category_Name, c.Description from beauty as b join Category as c on b.categoryid = c.ID";
                if (checkBoxID.Checked && int.TryParse(textBoxID.Text, out a))
                {
                    query += " where b.ID = " + textBoxID.Text;
                }
                else
                    if (checkBoxTYPE.Checked && comboBoxTYPE.Text != "")
                {
                    query += " WHERE b.Category_ID = (select id from Category where Category_Name = N'" + comboBoxTYPE.Text + "')";
                }
            }
            if (radioButtonADD.Checked && textBoxNAME.Text != "" && textBoxDURATION.Text != "" && textBoxMASTER.Text != "" && textBoxPRICE.Text != "" && comboBoxTYPE.Text != "")
            {
                res = "1 row(s) inserted";
                query = @"insert into beauty (service, price, master, duration, categoryid) values (N'" + textBoxNAME.Text + "'" + "," + " '" + textBoxPRICE.Text + "'" + "," + " N'" + textBoxMASTER.Text + "'" + "," + "'" + textBoxDURATION.Text + "'" + "," + "(select ID from Category where Category_Name=N'" + comboBoxTYPE.Text + "')" + ")";
            }
            if (radioButtonUPDATE.Checked && textBoxID.Text != "" && textBoxNAME.Text != "" && textBoxMASTER.Text != "" && textBoxDURATION.Text != "" && textBoxPRICE.Text != "" && comboBoxTYPE.Text != "")
            {
                res = "1 row(s) updated";
                query = @"update beauty set service = N'" + textBoxNAME.Text + "'" + "," + " master=N'" + textBoxMASTER.Text + "'" + "," + " duration='" + textBoxDURATION.Text + "'" + "," + " price='" + textBoxPRICE.Text + "'" + "," + "categoryid = (select ID from Category where Category_Name=N'" + comboBoxTYPE.Text + "')" + " where ID=" + textBoxID.Text;
            }
            if (radioButtonDELETE.Checked && textBoxID.Text != "")
            {
                res = "1 row(s) deleted";
                query = "delete beauty where ID=" + textBoxID.Text;
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
                        adapt = new SqlDataAdapter("select b.ID, b.service, b.price, b.master, b.duration, b.categoryid, c.Category_Name, c.Description from beauty as b join Category as c on b.categoryid = c.ID;", connectionString);
                        data = new DataSet();
                        adapt.Fill(data);
                        dataGridView1.DataSource = data.Tables[0];
                    }
                }

                 errorProvider.Clear();
                textBoxResult.Text = res;
                FillTypes();
                textBoxID.Text = "ID";
                textBoxNAME.Text = "Name";
                textBoxMASTER.Text = "MASTER Name";
                textBoxDURATION.Text = "DURATION";
                textBoxPRICE.Text = "PRICE";
                comboBoxTYPE.Text = "";
            }
            catch (Exception exc) { MessageBox.Show(exc.Message); };
        }

        private void comboBoxTYPE_Validating(object sender, CancelEventArgs e)
        {
            if (comboBoxTYPE.Text == "") e.Cancel = true;
        }

        private void textBoxID_TextChanged(object sender, EventArgs e)
        {
            if(radioButtonDELETE.Checked==true)
            {
                if (IntError(textBoxID))
                {
                    buttonQUERY.Enabled = true;
                }
                else buttonQUERY.Enabled = false;
            }
        }
    }
}
