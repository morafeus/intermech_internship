using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;

namespace twelvth_lesson_ex3
{
    internal class Program
    {

        static string appGuid = 
                ((GuidAttribute) Assembly
            .GetExecutingAssembly()
            .GetCustomAttributes(typeof(GuidAttribute), false)
            .GetValue(0)
        ).Value.ToString(); 

        static void Main(string[] args)
        {
            string mutexId = string.Format("Global\\{{{0}}}", appGuid);
            var mutex = new Mutex(false, mutexId);

            if (!mutex.WaitOne(TimeSpan.FromSeconds(5), false))
            {
                Console.WriteLine("приложение уже запущено");
                Environment.Exit(0);
            }
                    
            Console.ReadLine();
               
            mutex.ReleaseMutex();
        }
    }
}
