using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace seventeenth_lesson
{
    public class Storage<T>
    {
        private List<T> items = new List<T>();

        public void AddItem(T item)
        {
            if (item != null)
            {
                items.Add(item);
            }
        }

        public void RemoveItem(T item)
        {
            if (item != null)
            {
                if (!items.Contains(item))
                    throw new Exception("такого элемента нет в хранилище");
                items.Remove(item);
            }
        }

        public ReadOnlyCollection<T> GetAll()
        {
            return items.AsReadOnly();
        }

    }
}
