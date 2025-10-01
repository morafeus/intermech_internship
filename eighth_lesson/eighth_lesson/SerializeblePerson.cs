
using System;

namespace eighth_lesson
{
    [Serializable]
    public class SerializeblePerson
    {
        private int _id;
        private string _name;
        private int _age;
        private DateTime _birthday;

        public int Id { get { return _id; } set { _id = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        public int Age { get { return _age; } set { _age = value; } }
        public DateTime Birthday { get { return _birthday; } set { _birthday = value; } }

        public SerializeblePerson(int id, string name, int age, DateTime birthday)
        {
            Id = id;
            Name = name;
            Age = age;
            Birthday = birthday;
        }
    }
}
