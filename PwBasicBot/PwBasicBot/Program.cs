using System;
using System.Diagnostics;
using System.Threading;

namespace PwBasicBot
{
    class Program
    {
        private const string PROCESS_NAME = "ELEMENTCLIENT";

        static void Main(string[] args)
        {
            try
            {
                while (true)
                {
                    var process = FindProcess(PROCESS_NAME);
                    Console.WriteLine(string.Concat("Procurando processo ", PROCESS_NAME));
                    if (process != null)
                    {
                        Console.WriteLine("Processo encontrado");
                        Bot gameBot = new Bot(process);
                        gameBot.Start();
                        Thread.Sleep(Timeout.Infinite);
                    }
                    Thread.Sleep(1000);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static Process FindProcess(string process)
        {
            Process[] processes = Process.GetProcessesByName(PROCESS_NAME);
            if (processes.Length > 0)
            {
                return processes[0];
            }
            else
            {
                return null;
            }
        }
    }
}
