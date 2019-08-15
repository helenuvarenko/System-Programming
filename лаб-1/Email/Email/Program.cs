using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace Email
{
    class Program
    {
        static void Main(string[] args)
        {
            string from = "helen0504uvarenko@gmail.com"; //from who   
            string message = DateTime.Now.ToString() + " Helen Uvarenko"; 
            string passw = "edfhtyrjueuk"; //mail password
            string input = "";
            string[] MailCaption = input.Split(' ');
            //while ((MailCaption.Length != 2))
            //{
            //   // Console.WriteLine("Enter here email adress of person, who you want send e-letter and reason to write(use one raw and space key) ");
            //    input = Console.ReadLine(); 
            //   // MailCaption = input.Split(' ');
            //}
            //string mailto = MailCaption[0];
            //string caption = MailCaption[1];//reason to write
            NetworkCredential loginInfo = new NetworkCredential(args[0], passw); 
            MailMessage msg = new MailMessage(); 
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);//gmail protocol and port
            msg.From = new MailAddress(args[0]);
            msg.To.Add(new MailAddress(args[0]));
            msg.Subject = args[1]; 
            msg.Body = message;
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = loginInfo; 
            smtpClient.Send(msg);
        }
    }
}
