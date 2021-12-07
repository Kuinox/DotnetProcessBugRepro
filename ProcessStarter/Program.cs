using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ProcessStarter
{
    class Program
    {
        static async Task Main(string[] args)
        {
            ProcessStartInfo cmdStartInfo = new ProcessStartInfo
            {
                UseShellExecute = false,
                CreateNoWindow = true,
                FileName = @"C:\Program Files\dotnet\dotnet.exe",
                Arguments = @"C:\Users\nicolas.vandeginste\source\repos\ProcessRepro\ProcessRepro\bin\Debug\net5.0\ProcessRepro.dll",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                RedirectStandardInput = true,
            };
            using Process cmdProcess = new Process();
            DataReceivedEventHandler outputReceived = delegate (object o, DataReceivedEventArgs e) { Console.WriteLine("<StdOut> " + e.Data); };
            DataReceivedEventHandler errorReceived = delegate (object o, DataReceivedEventArgs e) { Console.WriteLine(e.Data); };

            cmdProcess.StartInfo = cmdStartInfo;
            cmdProcess.OutputDataReceived += outputReceived;
            cmdProcess.ErrorDataReceived += errorReceived;
            cmdProcess.Start();
            cmdProcess.BeginErrorReadLine();
            cmdProcess.BeginOutputReadLine();
            cmdProcess.WaitForExit(int.MaxValue);
            Console.WriteLine("Exited ?:"+cmdProcess.HasExited);
            cmdProcess.WaitForExit();
            Console.WriteLine("Exited !");
        }
    }
}
