using first_lesson.Models;
using System;

namespace first_lesson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student("Алексей");
            Student student1 = new Student("Андрей");
            Student student2 = new Student("Филип");

            Retrie retrie = new Retrie("Анатолий");
            Retrie retrie1 = new Retrie("Степан");
            Retrie retrie2 = new Retrie("Денис");

            Worker worker = new Worker("Аркадий");
            Worker worker1 = new Worker("Федор");
            Worker worker2 = new Worker("Петр");

            PersonCollection.PersonCollection collection = new PersonCollection.PersonCollection();
            collection.Add(student);
            collection.Add(student1);
            collection.Add(retrie);
            collection.Add(student);
            collection.Add(worker);
            collection.Add(worker1);
            collection.Add(worker2);
            collection.Add(retrie1);
            collection.Add(student2);
            collection.Add(retrie2);

            foreach(var person in collection)
            {
                Console.WriteLine(person.ToString());
            }

            collection.Remove();
            collection.Remove(student);

            Console.WriteLine("\n\n");
            foreach (var person in collection)
            {
                Console.WriteLine(person.ToString());
            }

            Console.WriteLine("\n" + collection.Contains(student1));

            int pos = 0;
            var pers = collection.ReturnLast(out pos);
            Console.Write("\n"+ pers.ToString() + ", position: " + pos);

            collection.Clear();
            Console.WriteLine("\nЭлементов в коллекции: " + collection.Count);
        }
    }
}
