using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.IO;
using System.Drawing;

namespace lab5
{
    public partial class Page2 : System.Web.UI.Page
    {
        private User u = new User();
        
        public static string code = GenerateString();
        private static Random random = new Random();
       // string role = "";
        public static string GenerateString()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, 8)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result;
        }
        private string Roles(bool s, bool c, bool d)
        {
            string role = "";

            if (s)
                role += "Майстер спорту ";
            if (c)
                role += "Кандидат наук ";

            if (d)
                role += "Доктор наук";
            return role;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.UrlReferrer==null)
                Response.Redirect("Page1.aspx");

            string[] faculties = { "Механіко-математичний", "Радіофізичний", "Геологічний", "Історичний", "Філософський" };
            string[] structures = { "Наукова бібліотека", "Ботанічний сад", "Інформаційно-обчислювальний центр", "Ректорат"};

            for (int i = 1; i <= 6; i++)
                DropDownListCourse.Items.Add(i.ToString() + " курс");
            for (int i = 0; i < faculties.Length; i++)
                DropDownListFaculty.Items.Add(faculties[i]);
            for (int i = 0; i < structures.Length; i++)
                DropDownListStruct.Items.Add(structures[i]);

        }
        public bool CheckPhoto()
        {
            string path = @"C:\lab_sys_5\photo";

            if (FileUpload1.FileName == "")
                return true;
            if (File.Exists(path + Container.GetUser().Photo))
                File.Delete(path + Container.GetUser().Photo);

            FileUpload1.SaveAs(path + FileUpload1.FileName);

            using (Bitmap photo = new Bitmap(path + FileUpload1.FileName))
                if (photo.Height >= 150 && photo.Height <= 300 && photo.Width >= 100 && photo.Width <= 200)
                {
                    u.Photo = FileUpload1.FileName;
                    Container.GetUser().Photo = u.Photo;
                    return true;
                }
            File.Delete(path + FileUpload1.FileName);

            return false;
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ButtonNext_Click(object sender, EventArgs e)
        {
            string from = "helen0504uvarenko@gmail.com",
                mailto = "",
                caption = "",
                email = "helen0504uvarenko@gmail.com",
                password = "edfhtyrjueuk";

            NetworkCredential loginInfo = new NetworkCredential(email, password);
            MailMessage msg = new MailMessage();
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

            mailto = TextBoxEmail.Text;
            caption = "Code";

            msg.From = new MailAddress(from);
            msg.To.Add(new MailAddress(mailto));
            msg.Subject = caption;
            msg.Body = "Your secret code for registration is: " + code;

            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = loginInfo;
            smtpClient.Send(msg);

            u.Login = TextBoxLogin.Text;
            u.Name = TextBoxName.Text;
            u.Surname = TextBoxSurname.Text;
            u.Photo = FileUpload1.FileName;
            u.Password = TextBoxPassword.Text;
            u.Email = TextBoxEmail.Text;
            if (RadioButtonList.SelectedIndex == 0)
            {
                u.Role = "Студент";
                u.Course = DropDownListCourse.SelectedItem.ToString();
                DropDownListCourse.Enabled = true;
                DropDownListStruct.Enabled = false;
                DropDownListFaculty.Enabled = true;

            }
            else if (RadioButtonList.SelectedIndex == 1)
            {
                u.Role = "Викладач";
                DropDownListCourse.Enabled = false;
                DropDownListStruct.Enabled = false;
                DropDownListFaculty.Enabled = true;
            }

            else if (RadioButtonList.SelectedIndex == 2)
            {
                u.Role = "Навчально-допоміжний персонал";
                DropDownListCourse.Enabled = false;
                DropDownListStruct.Enabled = true;
                DropDownListFaculty.Enabled = false;
            }
            

            u.Faculty = DropDownListFaculty.SelectedItem.ToString();
            u.Department = DropDownListStruct.SelectedItem.ToString();
            u.Skill = Roles(CheckBoxList.Items[0].Selected, CheckBoxList.Items[1].Selected, CheckBoxList.Items[2].Selected);
            if (FileUpload1.FileName != null) FileUpload1.SaveAs(@"C:\lab_sys_5\AUTH\AUTH\photo\" + FileUpload1.FileName);
            Container.SetUser(u);

            if (CheckPhoto())
            {
                Thread.Sleep(2000);
                Response.Redirect("Page3.aspx");
            }
            else
            {
                LabelError.Text = "Невірний формат фотографії";
                System.Threading.Thread.Sleep(5000);
            }

        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            Thread.Sleep(2000);
            Response.Redirect("Page1.aspx");
        }

        protected void DropDownListCourse_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void FileUpload1_Load(object sender, EventArgs e)
        {
        }

        protected void RadioButtonList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList.SelectedIndex == 1 || RadioButtonList.SelectedIndex == 2)
            {
                CheckBoxList.Items[1].Enabled = true;
            }
            else CheckBoxList.Items[1].Enabled = false;

            if (RadioButtonList.SelectedIndex == 1)
            {
                CheckBoxList.Items[2].Enabled = true;
            }
            else CheckBoxList.Items[2].Enabled = false;

            if (RadioButtonList.SelectedIndex == 0)
            {
                CheckBoxList.Items[1].Enabled = false;
                     CheckBoxList.Items[2].Enabled = false;
            }
        }
    }
}