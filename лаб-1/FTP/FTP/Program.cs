using System;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace Task6c
{
    class Program
    {
        static void Main(string[] args)
        {
           
            using (WebClient W = new WebClient())
            {
                
                W.DownloadFile(args[0], "D:\\register.txt");
            }
            string localPath = "D:\\";
            string fileName = "register.txt"; ;
            StreamReader reader = new StreamReader("D:\\register.txt");
            string testLine = "";
            string rowsList = "";
            int i = 0;
            while (!reader.EndOfStream)
            {
                testLine = reader.ReadLine();
                if (testLine.Contains(args[1]))
                {
                    rowsList += i + ", ";
                }
                i++;
            }
            reader.Close();

            Console.WriteLine("Number(s) of rows, which contain(s) word " + "'" + args[1] + "'" + ": " + rowsList);
            
            Process.Start("notepad.exe", localPath + fileName);
            Console.ReadKey();
        }
    }
}