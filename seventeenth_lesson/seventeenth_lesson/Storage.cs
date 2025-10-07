using System;
using System.Collections.Generic;

namespace seventeenth_lesson
{
    public class Storage<T>
    {
        private List<T> items;

        public void AddItem(T item)
        {
            if (items == null)
            {
                items = new List<T>();
            }
            if (item != null)
            {
                items.Add(item);
            }
        }

        public void RemoveItem(T item)
        {
            if (items.Count == 0)
                throw new Exception("пустая коллекция");
            if (item != null)
            {
                if (!items.Contains(item))
                    throw new Exception("такого элемента нет в хранилище");
                items.Remove(item);
            }
        }

        public List<T> GetAll()
        {
            if (items == null)
                throw new Exception("на складе ничего нет");
            return items;
        }
    }
}
