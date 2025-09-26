

using System;
using System.Globalization;

namespace fourth_lesson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var checkList = new CheckList();
            var info = checkList.ReadFile(@"D:\internship\file_system\file_check.txt");
            string[] strings = info.Split('\n');


            foreach (string s in strings)
            {
                var name = s.Split(' ')[0];
                var buf = s.Split(' ')[1].TrimEnd('\r');
                DateTime date = DateTime.Parse(buf);
                Console.WriteLine(name + " " + date);
            }

            Console.WriteLine("\n");
            foreach (string s in strings)
            {
                var name = s.Split(' ')[0];
                var buf = s.Split(' ')[1].TrimEnd('\r');
                DateTime date = DateTime.ParseExact(buf,"mm.dd.yyyy", CultureInfo.CurrentCulture = new CultureInfo("en-us"));
                Console.WriteLine(name + " " + date);
            }

        }
    }
}
