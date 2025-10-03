using System;
using System.IO;
using System.Threading;

namespace eleventh_lesson
{
    internal class Program
    {
        private const string FIRSTPATH = @"D:\internship\file_system\first.txt";
        private const string SECONDPATH = @"D:\internship\file_system\second.txt";
        private const string THIRDPATH = @"D:\internship\file_system\third.txt";

        static object locker = new object();

        static void Main(string[] args)
        {
            var threadFirst = new Thread(()=> 
            {
                var info = File.ReadAllText(FIRSTPATH);
                SaveThird(info);
            });

            var threadSecond = new Thread(()=> 
            {
                var info = File.ReadAllText(SECONDPATH);
                SaveThird(info);
            });

            threadFirst.Start();
            threadSecond.Start();

            threadFirst.Join();
            threadSecond.Join();
        }

        static void SaveThird(string data)
        {
            lock (locker)
            {
                using (StreamWriter writer = new StreamWriter(THIRDPATH, true))
                {
                    Thread.Sleep(1000);
                    writer.WriteLine(data);
                }
            }
        }
    }
}
