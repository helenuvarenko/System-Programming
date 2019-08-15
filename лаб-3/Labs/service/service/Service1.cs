using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;
using System.Timers;
using System.Text.RegularExpressions;


namespace service
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        public static string pattern = @"^Task_[0-9]{4}\.txt$";
        public static Regex CheckClaim = new Regex(pattern, RegexOptions.IgnoreCase);
        public static double timeToDo = 0.0;
        public static double tick = 0.0;
        public static int Y = 0;
        protected override void OnStart(string[] args)
        {
            Directory.CreateDirectory(@"C:\Windows\Task_Queue\Tasks");
            Directory.CreateDirectory(@"C:\Windows\Task_Queue\Claims");

            using (RegistryKey key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).CreateSubKey(@"Software\Task_Queue\Parameters\"))
            {
                if (key.GetValue("Task_Execution_Duration") == null)
                    key.SetValue("Task_Execution_Duration", 60);

                if (key.GetValue("Task_Claim_Check_Period") == null)
                    key.SetValue("Task_Claim_Check_Period", 30);

                if (key.GetValue("Task_Execution_Quantity") == null)
                    key.SetValue("Task_Execution_Quantity", 1);
            }

            using (RegistryKey key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).CreateSubKey(@"Software\Task_Queue\Parameters\"))
            {
                Y = Convert.ToInt32(key.GetValue("Task_Execution_Quantity", 1));
            }
            System.Threading.Thread ThreadCheck = new System.Threading.Thread(CheckClaims);
            ThreadCheck.Start();

            System.Threading.Thread ThreadWork = new System.Threading.Thread(StartWork);
            ThreadWork.Start();

            using (StreamWriter writeLOG = new StreamWriter(new FileStream(@"C:\Windows\Logs\Task_Queue.log", FileMode.Append)))
            {
                writeLOG.WriteLine("[" + DateTime.Now + "] Сервіс запущено!");
            }
        }

        static void CheckClaims()
        {
            using (RegistryKey key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).CreateSubKey(@"Software\Task_Queue\Parameters\"))
            {
                int CheckPeriod = Convert.ToInt32(key.GetValue("Task_Claim_Check_Period", 30));
                Timer t = new Timer(CheckPeriod * 1000);
                t.Elapsed += new ElapsedEventHandler(PrepareToWork);
                t.Enabled = true;
            }
        }
        static void StartWork()
        {
            using (RegistryKey key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).CreateSubKey(@"Software\Task_Queue\Parameters\"))
            {
                timeToDo = Convert.ToDouble(key.GetValue("Task_Execution_Duration", 60));
                tick = 100.0 / timeToDo;
                Timer t = new Timer(2000);
                t.Elapsed += new ElapsedEventHandler(DoSomeWork);
                t.Enabled = true;
            }
        }
        static void PrepareToWork(object source, ElapsedEventArgs e)
        {
            bool same = false;
            string[] claims = Directory.GetFiles(@"C:\Windows\Task_Queue\Claims");
            string[] tasks = Directory.GetFiles(@"C:\Windows\Task_Queue\Tasks");
            Array.Sort(claims);
            Array.Sort(tasks);
            using (StreamWriter writeLOG = new StreamWriter(new FileStream(@"C:\Windows\Logs\Task_Queue.log", FileMode.Append)))
            {
                Match CheckName;
                bool goodTask = false;
                string fileName = "";

                if (claims.Length != 0)
                {
                    if (claims[0] != "")
                    {
                        fileName = claims[0].Substring(29);
                        CheckName = CheckClaim.Match(fileName);
                        goodTask = CheckName.Success;
                        if (goodTask)
                        {
                            same = false;
                            for (int k = 0; k < tasks.Length; k++)
                            {
                                if (Regex.Match(tasks[k].Substring(28), fileName.Substring(0, 9)).Success)
                                {
                                    writeLOG.WriteLine("[" + DateTime.Now + "] Помилка розміщення задачі " + fileName.Substring(0, 9) + " задача з таким номером вже існує!");
                                    File.Delete(claims[0]);
                                    same = true;
                                    break;
                                }
                            }
                            if (!same)
                            {
                                writeLOG.WriteLine("[" + DateTime.Now + "] Задача " + fileName.Substring(0, 9) + " успішно прийнята в обробку...");
                                using (StreamWriter task = new StreamWriter(new FileStream(@"C:\Windows\Task_Queue\Tasks\" + fileName.Substring(0, 9) + "-[....................]-Queued.txt", FileMode.Create)))
                                {
                                }
                                File.Delete(claims[0]);
                                claims[0] = "";
                                goodTask = false;
                            }
                        }
                        else
                        {
                            File.Delete(claims[0]);
                            claims[0] = "";
                            writeLOG.WriteLine("[" + DateTime.Now + "] Помилка розміщення задачі " + fileName.Substring(0, fileName.Length - 4) + " - некоректний синтаксис!");
                        }
                    }
                }
            }
        }
        static void DoSomeWork(object source, ElapsedEventArgs e)
        {
            double p = 0;
            int stick = 0;
            string prog = "";

            string[] tasks = Directory.GetFiles(@"C:\Windows\Task_Queue\Tasks");
            var queue = new List<string>();

            for (int i = 0; i < tasks.Length; i++)
            {
                if (Regex.IsMatch(tasks[i], @"Task_[0-9]{4}-\[\.{20}]-Queued.txt"))
                {
                    queue.Add(tasks[i]);
                }
            }
            if (queue.Count > 0)
            {
                Array.Sort(queue.ToArray());

                int count = Y;
                for (int j = 0; j < count && j < queue.Count; j++)
                {
                    if (queue[j] != null)
                        if (Regex.Match(queue[j], @"Task_[0-9]{4}-\[\.{20}]-Queued.txt").Success)
                        {
                            File.Delete(queue[j]);
                            using (StreamWriter task = new StreamWriter(new FileStream(queue[j].Substring(0, 37) + "-[....................]-In Progress - 0 percents" + ".txt", FileMode.Create)))
                            {
                            }
                            Y--;
                        }
                }
            }

            string[] alltasks = Directory.GetFiles(@"C:\Windows\Task_Queue\Tasks");
            string[] progress = new string[alltasks.Length];

            for (int j = 0; j < alltasks.Length; j++)
            {
                if (Regex.Match(alltasks[j], @"Task_[0-9]{4}-\[[\.I]{20}\]-In Progress - [0-9]{1,2} percents.txt").Success)
                {
                    progress[j] = alltasks[j];
                }
            }
            Array.Sort(progress);

            for (int i = 0; i < alltasks.Length; i++)
            {
                if (progress[i] != null)
                {
                    p = Convert.ToDouble(progress[i].Substring(75, 2));
                    p += (int)Math.Round(2 * tick);

                    if (p < 100)
                    {
                        stick = (int)p / 5;

                        for (int j = 0; j < stick; j++)
                        {
                            prog += "I";
                        }
                        for (int j = 0; j < 20 - stick; j++)
                        {
                            prog += ".";
                        }

                        File.Delete(progress[i]);
                        using (StreamWriter progr = new StreamWriter(new FileStream(progress[i].Substring(0, 37) + "-[" + prog + "]-In Progress - " + p + " percents" + ".txt", FileMode.Create)))
                        {
                        }

                        prog = "";

                    }
                    else
                    {
                        File.Delete(progress[i]);
                        using (StreamWriter progr = new StreamWriter(new FileStream(progress[i].Substring(0, 37) + "-[IIIIIIIIIIIIIIIIIIII]-Completed" + ".txt", FileMode.Create)))
                        {
                        }

                        using (StreamWriter writeLOG = new StreamWriter(new FileStream(@"C:\Windows\Logs\Task_Queue.log", FileMode.Append)))
                        {
                            writeLOG.WriteLine("[" + DateTime.Now + "] Задача " + progress[i].Substring(28, 9) + " - успішно виконана!");
                        }
                        Y++;
                    }
                }
            }
        }
        protected override void OnStop()
        {
            using (StreamWriter writeLOG = new StreamWriter(new FileStream(@"C:\Windows\Logs\Task_Queue.log", FileMode.Append)))
            {
                writeLOG.WriteLine("[" + DateTime.Now + "] Сервіс вимкнено!");
            }
        }
    }
}
