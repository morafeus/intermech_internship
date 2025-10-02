using System;
using System.IO;
using System.Threading;

namespace eleventh_lesson
{
    internal class Program
    {
        static object locker = new object();

        static void Main(string[] args)
        {
            var threadFirst = new Thread(()=> 
            {
                var info = File.ReadAllText(@"D:\internship\file_system\first.txt");
                Console.WriteLine(info);
            });

            var threadSecond = new Thread(()=> 
            {
                var info = File.ReadAllText(@"D:\internship\file_system\second.txt");
                Console.WriteLine(info);
            });

            threadFirst.Start();
            threadSecond.Start();
        }

        static void SaveThird(string data)
        {
            lock (locker)
            {
               
            }
        }
    }
}
