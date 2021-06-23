using System;
using System.Diagnostics;
using Microsoft.Web.WebView2.Core;

namespace LauncherWebViewCheck
{
    class Program
    {
        static public bool IsInstalled => WebView2Install.GetInfo().InstallType != InstallType.NotInstalled;
        static public bool IsNotInstalled => !IsInstalled;
        static void Main(string[] args)
        {
            Console.WriteLine($"Hello World! WebView2 is{(IsInstalled ? string.Empty : " not")} installed");

            if (!IsInstalled)
            {
                using (Process myProcess = new Process())
                {
                    myProcess.StartInfo.UseShellExecute = false;
                    myProcess.StartInfo.FileName = "MicrosoftEdgeWebView2RuntimeInstallerX64.exe";
                    myProcess.StartInfo.CreateNoWindow = true;
                    myProcess.Start();
                }
            }

            Process.Start(new ProcessStartInfo("samplewebview2:") { UseShellExecute = true });
            //using (Process myProcess = new Process())
            //{
            //    myProcess.StartInfo.UseShellExecute = false;
            //    //myProcess.StartInfo.WorkingDirectory = "\\Sample-WebView2\\";
            //    myProcess.StartInfo.FileName = "..\\Sample-WebView2\\Sample-WebView2.exe";
            //    //myProcess.StartInfo.CreateNoWindow = true;
            //    myProcess.Start();
            //}


        }
    }
}
