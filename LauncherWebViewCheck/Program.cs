using System.Diagnostics;

namespace LauncherWebViewCheck
{
    class Program
    {
        static public bool IsInstalled => WebView2Install.GetInfo().InstallType != InstallType.NotInstalled;
        static public bool IsNotInstalled => !IsInstalled;
        static void Main(string[] args)
        {
            Debug.WriteLine($"Hello World! WebView2 is{(IsInstalled ? string.Empty : " not")} installed");
            if (!IsInstalled)
            {
                using (Process myProcess = new Process())
                {
                    myProcess.StartInfo.UseShellExecute = false;
                    myProcess.StartInfo.FileName = "MicrosoftEdgeWebView2RuntimeInstallerX64.exe";
                    myProcess.StartInfo.CreateNoWindow = true;
                    myProcess.Start();
                    
                    myProcess.WaitForExit();
                }
             }

            Process.Start(new ProcessStartInfo("samplewebview2:") { UseShellExecute = true });
        }
    }
}
