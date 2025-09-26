

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

            var compareOrdered = new OrderedDictionary();
            compareOrdered.Add(100, 100);
            compareOrdered.Add(200, 200);
            compareOrdered.Add(400, 400);
            compareOrdered.Add("hello",300);

            var orderedDictionaryEq = new OrderedDictionaryEqComp();

            object[] keys = new object[compareOrdered.Keys.Count];
            compareOrdered.Keys.CopyTo(keys, 0);
            Console.WriteLine(orderedDictionaryEq.Equals(keys[0], keys[1]));

            try
            {
                Console.WriteLine(compareOrdered.CompareKeys(100, 400));
                Console.WriteLine(compareOrdered.CompareKeys(100, 400));
            }
            catch (Exception ex)
            { 
                Console.WriteLine(ex.Message); 
            }
        }
    }
}
