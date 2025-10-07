
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
            ThreadPool.QueueUserWorkItem((object state) =>
            {
                var info = File.ReadAllText(FIRSTPATH);
                SaveThird(info);
            });

            ThreadPool.QueueUserWorkItem((object state) =>
            {
                var info = File.ReadAllText(SECONDPATH);
                SaveThird(info);
            });

            Thread.Sleep(1000);
        }

        static void SaveThird(string data)
        {
            lock (locker)
            {
                using (var writer = new StreamWriter(THIRDPATH, true))
                {
                    writer.WriteLine(data);
                }
            }
        }
    }
}
