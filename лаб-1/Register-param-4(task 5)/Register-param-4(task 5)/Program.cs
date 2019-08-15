using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace Registry_05
{
    class Program
    {
        static void Main(string[] args)
        {
            string Path = "HKEY_LOCAL_MACHINE\\Software\\UVARENKO";

            Registry.SetValue(Path, "P1", "KI1-Studen", RegistryValueKind.String);
            Registry.SetValue(Path, "P2", new byte[] { 0x2A, 0x4B, 0xCE, 0xDF }, RegistryValueKind.Binary);
            Registry.SetValue(Path, "P3", 0x1A4BCEDF, RegistryValueKind.DWord);
            Registry.SetValue(Path, "P4", 709611231, RegistryValueKind.DWord);
        }
    }
}