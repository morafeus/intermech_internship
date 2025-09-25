using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace second_lesson_4ex
{
    public static class OrderedDictionaryExt
    {
        public static object CompareKeys(this OrderedDictionary dict, object key1, object key2)
        {
            if ((dict[key1] != null && dict[key2] != null))
            {
                var val1 = dict[key1] as IComparable;
                var val2 = dict[key2] as IComparable;

                var result = val1.CompareTo(val2);

                if (result <= 0)
                    return key2;
                if (result > 0)
                    return key1;
            }
            throw new Exception("нет такого ключа");
        }
    }
}
