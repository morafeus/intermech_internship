using System;
using System.Collections.Generic;

namespace second_lesson_4ex
{
    public class OrderedDictionaryEqComp : IEqualityComparer<object>
    {
        public new bool Equals(object key1, object key2)
        {
            var val1 = key1 as IComparable;
            var val2 = key2 as IComparable;

            var result = val1.CompareTo(val2);

            if (result == 0)
                return true;
            else
                return false;
        }

        public int GetHashCode(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
