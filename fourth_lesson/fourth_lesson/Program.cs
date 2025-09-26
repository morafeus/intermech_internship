
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace fourth_lesson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var info = File.ReadAllText(@"D:\internship\file_system\file_check.txt");
            string[] strings = info.Split('\n' );

            List<string> names = new List<string>();
            List<DateTime> dates = new List<DateTime>();

            foreach (string s in strings)
            {

                var result = s.Substring(0, s.Length - 1).Split(' ');
                dates.Add(DateTime.Parse(result[1]));
                names.Add(result[0]);

            }

            //CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-us");
            foreach(DateTime date in dates)
            {
                Console.WriteLine(date);
            }
        }
    }
}
