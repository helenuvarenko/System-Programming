using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace terminateWMI
{
    class Program
    {
        static void Main(string[] args)
        {
            //ManagementScope S = new ManagementScope(@"\\.\ROOT\cimv2");

            ////create object query
            //ObjectQuery Q = new ObjectQuery("SELECT * FROM Win32_Process where ExecutablePath like 'W:%'");

            ////create object searcher
            //ManagementObjectSearcher F = new ManagementObjectSearcher(S, Q);

            ////get collection of WMI objects
            //ManagementObjectCollection queryCollection = F.Get();

            ////enumerate the collection.
            //foreach (ManagementObject m in queryCollection)
            //{
            //    // access properties of the WMI object
            //    Console.WriteLine(m["Name"]);
            //    Console.WriteLine("===========================");
            //    Console.WriteLine("Description:  " + m["Description"]);
            //    Console.WriteLine("ExecutablePath:  " + m["ExecutablePath"]);

            //        object[] IN = { 128 };
            //   // if (m["Name"] == "Dicter.exe") { object R = m.InvokeMethod("Terminate", IN); }
            //       object R = m.InvokeMethod("Terminate", IN);

            //string reqName = "Dicter.exe";
            //string queryString = "Win32_Process";
            //string condition = "Name='" + reqName + "'";
            //SelectQuery query = new SelectQuery(queryString, condition);
            //ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            //ManagementObjectCollection processes = searcher.Get();
            //ManagementObjectCollection.ManagementObjectEnumerator enumerator = processes.GetEnumerator();

            //if (enumerator.MoveNext())
            //{
            //    ManagementObject obj = (ManagementObject)enumerator.Current;
            //    obj.InvokeMethod("Terminate", null);
            //    Console.WriteLine("Процес зупинено! ^_^");
            //}
            //else Console.WriteLine("Помилка запиту :(");

            ManagementScope S = new ManagementScope(@"\\.\ROOT\cimv2");
            string name = "Dicter.exe";
            //create object query
            ObjectQuery Q = new ObjectQuery("SELECT * FROM Win32_Process where Name='"+name+"'");

            //create object searcher
            ManagementObjectSearcher F = new ManagementObjectSearcher(S, Q);

            //get collection of WMI objects
            ManagementObjectCollection queryCollection = F.Get();

            //enumerate the collection.
            foreach (ManagementObject m in queryCollection)
            {
                // access properties of the WMI object
                Console.WriteLine(m["Name"]);
                Console.WriteLine("===========================");
                Console.WriteLine("Description:  " + m["Description"]);
                Console.WriteLine("ExecutablePath:  " + m["ExecutablePath"]);

                object[] IN = { 128 };
                // if (m["Name"] == "Dicter.exe") { object R = m.InvokeMethod("Terminate", IN); }
                object R = m.InvokeMethod("Terminate", IN);
                Console.WriteLine("Процес зупинено! ^_^");

            }
            Console.ReadKey();
        }
    }
}
