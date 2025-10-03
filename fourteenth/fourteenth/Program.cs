using System;
using System.Threading;
using System.Threading.Tasks;

namespace fourteenth
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task.Factory.StartNew(() => {
                Parallel.Invoke(FirstMethod, SecondMethod);
            });
            for(int i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine(i);
            }
        }

        static void FirstMethod()
        {
            Thread.Sleep(5000);
            Console.WriteLine("первый метод");
        }

        static void SecondMethod()
        {
            Thread.Sleep(4000);
            Console.WriteLine("второй метод");
        }
    }
}
