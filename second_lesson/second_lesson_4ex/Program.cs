

using System;
using System.Collections.Specialized;

namespace second_lesson_4ex
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var x = 123456789;
            var y = 200.51;

            OrderedDictionary compareOrdered = new OrderedDictionary();
            compareOrdered.Add(100, 100);
            compareOrdered.Add(200, 200);
            compareOrdered.Add(400, 400);
            compareOrdered.Add("hello",300);

            try
            {
                Console.WriteLine(compareOrdered.CompareKeys(100, 400));
            }
            catch (Exception ex)
            { 
                Console.WriteLine(ex.Message); 
            }
        }
    }
}
