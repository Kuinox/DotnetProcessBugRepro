using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ProcessRepro
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("ProcessRepro start.");
            ProcessStartInfo cmdStartInfo = new ProcessStartInfo
            {
                UseShellExecute = false,
                CreateNoWindow = true,
                FileName = @"C:\Program Files\dotnet\dotnet.exe",
                Arguments = @"C:\Users\nicolas.vandeginste\source\repos\ProcessRepro\SubProcess\bin\Debug\net5.0\SubProcess.dll",
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
            await Task.Delay(5_000);
            Console.WriteLine("Summoned process exited.");
        }
    }
}
