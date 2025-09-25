
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

            Dictionary<int, double> dict = new Dictionary<int, double>();
            dict.Add(x, y);

            Hashtable hashtable = new Hashtable();
            hashtable.Add(x, y);

            SortedList<int, double> keyValuePairs = new SortedList<int, double>();
            keyValuePairs.Add(x, y);

            ListDictionary listDictionary = new ListDictionary();
            listDictionary.Add(x, y);

            HybridDictionary hybridDictionary = new HybridDictionary();
            hybridDictionary.Add(x, y);

            //?????
            List<Company> list = new List<Company>();
            list.Add(new Company() { id = x, value = y });
            
        }
    }
}
