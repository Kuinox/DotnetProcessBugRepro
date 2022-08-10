using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ProcessRepro
{
    class Program
    {
        static async Task Main()
        {
            Console.WriteLine("ProcessRepro start.");
            ProcessStartInfo cmdStartInfo = new()
            {
                UseShellExecute = false,
                CreateNoWindow = true,
                FileName = @"dotnet",
                Arguments = @"run --project SubProcess",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                RedirectStandardInput = true,
            };
            using Process cmdProcess = new();
            static void outputReceived(object o, DataReceivedEventArgs e) { Console.WriteLine("<StdOut> " + e.Data); }
            static void errorReceived(object o, DataReceivedEventArgs e) { Console.WriteLine(e.Data); }

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
