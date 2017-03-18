using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace ThreadTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread thread1 = new Thread(new ThreadStart(count));
            Thread thread2 = new Thread(new ThreadStart(count));
            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();
            Console.Read();
        }

        static void count()
        {
            for (int i = 0; i < 5; i++) {
                Console.WriteLine(i);
                Thread.Sleep(10);
            }
        }
    }
}
