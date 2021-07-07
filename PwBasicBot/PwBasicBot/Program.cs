using System;
using System.Diagnostics;
using System.Text;
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
                    var selectedProcess = ProcessSelect(process);
                    if (selectedProcess != null)
                    {
                        Bot gameBot = new Bot(selectedProcess);
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

        static Process[] FindProcess(string process)
        {
            Process[] processes = Process.GetProcessesByName(PROCESS_NAME);
            if (processes.Length > 0)
            {
                return processes;
            }
            else
            {
                return null;
            }
        }

        static Process ProcessSelect(Process[] processes)
        {            
            while(true)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Indice / ID / Nome\n\n");
                int[] allOptions = new int[processes.Length];
                for(int count = 0; count < processes.Length; count++)
                {
                    allOptions[count] = count;
                    sb.Append(string.Concat(count, " / ", processes[count].Id, " / ", processes[count].ProcessName,"\n"));
                }
                sb.Append("\n");
                sb.Append("Selecione o indice do processo desejado > ");
                Console.Write(sb);
                string ind = Console.ReadLine();
                if (ind.IsNumber())
                {
                    if (Array.Exists(allOptions, option => option.Equals(Convert.ToInt32(ind))))
                    {
                        Console.Clear();
                        return processes[Convert.ToInt32(ind)];
                    }
                    else
                    {
                        Console.WriteLine("Essa opção nao existe");
                    }
                }
                else
                {
                    Console.WriteLine("Digite apenas numeros");
                }
            }
            return null;
        }
    }
}
