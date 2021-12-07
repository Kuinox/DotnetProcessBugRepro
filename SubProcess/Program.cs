using System;
using System.Threading.Tasks;

namespace SubProcess
{
    class Program
    {
        static async Task Main(string[] args)
        {

            Console.WriteLine("SubProcess start!");
            await Task.Delay(60_000*100);
            Console.WriteLine("Exiting:0/5!");
            Console.WriteLine("Exiting:1/5!");
            Console.WriteLine("Exiting:2/5!");
            Console.WriteLine("Exiting:3/5!");
            Console.WriteLine("Exiting:4/5!");
            Console.WriteLine("Exiting:5/5!(last message)");
        }
    }
}
