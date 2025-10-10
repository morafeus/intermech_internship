using System;
using System.Collections.Generic;
using System.Linq;

namespace seventeenth_lesson
{
    public static class StorageFinder<T>
    {

        public static T FindItem(IReadOnlyCollection<T> items, Func<T, bool> predicate)
        {
            if (items == null)
                throw new Exception("коллекция пуста");
            return items.Where(predicate).FirstOrDefault();

        }
    }
}
