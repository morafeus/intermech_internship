using System;
using System.Threading;

namespace twelvth_lesson_ex3
{
    internal class Program
    {

        const string MUTEX_ID = "Global\\{B1E7934A-F688-417f-8FCB-65C3985E9E27}"; 

        static void Main(string[] args)
        { 
            var mutex = new Mutex(false, MUTEX_ID);
            
            if (!mutex.WaitOne(TimeSpan.FromSeconds(5), false))
            {
                Console.WriteLine("Another instance of this program is running");
                Environment.Exit(0);
            }
                    
            Console.ReadLine();
               
            mutex.ReleaseMutex();
        }
    }
}
