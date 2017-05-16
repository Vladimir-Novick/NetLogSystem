using System;
using NetLogSystem.NetCoreLib;
using System.Threading;

namespace NetLogSystem.NetCoreLib.TestConsoleApp
{
    class Program
    {
        private static volatile int threadCount = 0;


        

        public static void ThreadProc(object data)
        {
            for (int j = 0;j < 30; j++ ){
                LogMessage message = new LogMessage($"{data.ToString()}", "test", "Message");
                NetLogSystem.Send(message);
                
            }

            threadCount--;
        }

            static void Main(string[] args)
           {

            NetLogSystem.NetAdderss = @"http://localhost:49857/LogSystem/NewMessage";

            for (int i = 0; i <= 4; i++)
            {
                Thread t = new Thread(
                    new ParameterizedThreadStart(ThreadProc)
                );
                t.Start(i);
                threadCount++;
            }

            while (threadCount > 0)
            {
                Thread.Sleep(300);
            }

            Console.WriteLine("Press enter to close...");
            Console.ReadLine();

        }
    }
}