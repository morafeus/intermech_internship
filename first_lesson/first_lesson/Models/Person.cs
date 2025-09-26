

using System;

namespace first_lesson.Models
{
    public abstract class Person
    {
        private Guid id;
        private string name;
        
        public Guid Id {  get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        
        public Person(string name)
        {
            this.id = Guid.NewGuid();
            this.name = name;
        }

        public override bool Equals(object obj)
        {
            Person person = obj as Person;
            if (obj is Person other)
            {
                return this.id == other.id;
            }
            return false;
        }

        public override string ToString()
        {
            return $"{name}, id: {id}";
        }
    }
}
