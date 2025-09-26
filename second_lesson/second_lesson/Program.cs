
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace second_lesson
{
    public class Company
    {
        public int id;
        public double value;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var x = 123456789;
            var y = 200.51;

            var dict = new Dictionary<int, double>();
            dict.Add(x, y);

            var hashtable = new Hashtable();
            hashtable.Add(x, y);

            var keyValuePairs = new SortedList<int, double>();
            keyValuePairs.Add(x, y);

            var listDictionary = new ListDictionary();
            listDictionary.Add(x, y);

            var hybridDictionary = new HybridDictionary();
            hybridDictionary.Add(x, y);

            //?????
            var list = new List<Company>();
            list.Add(new Company() { id = x, value = y });
            
        }
    }
}
