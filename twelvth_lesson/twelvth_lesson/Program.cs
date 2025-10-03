
using System.IO;
using System.Threading;

namespace twelvth_lesson
{
    // в задании не было примера ручной событийной блокировки, я взял прошлый урок и сделал эту же задачу с использованием автоматической событийной блокировки
    internal class Program
    {
        private const string FIRSTPATH = @"D:\internship\file_system\first.txt";
        private const string SECONDPATH = @"D:\internship\file_system\second.txt";
        private const string THIRDPATH = @"D:\internship\file_system\third.txt";

        private static AutoResetEvent _waitHandler = new AutoResetEvent(true);

        static void Main(string[] args)
        {
            var threadFirst = new Thread(() =>
            {
                var info = File.ReadAllText(FIRSTPATH);
                SaveThird(info);
            });

            var threadSecond = new Thread(() =>
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
            _waitHandler.WaitOne();
            using (var writer = new StreamWriter(THIRDPATH, true))
            {
                Thread.Sleep(1000);
                writer.WriteLine(data);
            }
            _waitHandler.Set();
        }
    }
}
