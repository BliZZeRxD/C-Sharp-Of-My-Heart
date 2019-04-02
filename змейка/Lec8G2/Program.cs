using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace Lec8G2
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Timers.Timer timer = new System.Timers.Timer(100);
            timer.Elapsed += DoIt;
            timer.Start();

            while (true)
            {
                ConsoleKeyInfo info = Console.ReadKey();
                switch (info.Key)
                {
                    case ConsoleKey.Spacebar:
                        timer.Stop();
                        break;
                    case ConsoleKey.Enter:
                        timer.Start();
                        break;
                }

            }
        }

        private static void DoIt(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        }

    }
}
