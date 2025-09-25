

using first_lesson.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace first_lesson.PersonCollection
{
    internal class PersonCollection : ICollection<Person>, IEnumerable
    {
        private List<Person> people = new List<Person>();

        public int Count => people.Count;

        public bool IsReadOnly => throw new System.NotImplementedException();

        public void Add(Person item)
        {
            try
            {
                if (Contains(item))
                {
                    throw new Exception($"{item.Name}. passport:{item.Id}");
                }
                else
                {
                    if (typeof(Retrie) == item.GetType())
                    {
                        for (var i = 0; i < people.Count; i++)
                        {
                            if (!(typeof(Retrie) == people[i].GetType()))
                            {
                                Person buf = people[i];
                                people.Insert(i> 0 ? i : 0, item);
                                break;
                            }
                        }
                    }
                    else
                    {
                        people.Add(item);
                    }
                    Console.WriteLine($"{item.Name}, позиция:  {people.IndexOf(item)}");
                }
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message + " Элемент уже есть в коллекции");
            }
        }

        public void Clear()
        {
            people.Clear();
        }

        public bool Contains(Person item)
        {
            foreach (Person p in people)
            {
                if (p.Equals(item))
                    return true;
            }
            return false;
      
        }

        public void CopyTo(Person[] array, int arrayIndex)
        {
            throw new System.NotImplementedException();
        }
        public bool Remove(Person item)
        {
            if(people.Contains(item))
                return people.Remove(item);
            else
                return false;
        }

        public void Remove()
        {
            people.RemoveAt(0);
        }

        public Person ReturnLast(out int position)
        {
            position = people.Count - 1;
            return people[people.Count - 1];
        }


        public IEnumerator<Person> GetEnumerator()
        {
            return people.GetEnumerator();
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
