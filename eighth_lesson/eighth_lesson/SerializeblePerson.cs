
using System;
using System.Xml;
using System.Xml.Serialization;

namespace eighth_lesson
{
    [Serializable]
    public class SerializeblePerson
    {
        private SomeInfo<int> _id;
        private SomeInfo<string> _name;
        private SomeInfo<DateTime> _birthday;

        [XmlElement("id")]
        public SomeInfo<int> Id { get { return _id; } set { _id = value; } }

        [XmlElement("name")]
        public SomeInfo<string> Name { get { return _name; } set { _name = value; } }

        [XmlElement("birthday")]
        public SomeInfo<DateTime> Birthday { get { return _birthday; } set { _birthday = value; } }

        public SerializeblePerson() { }

        public SerializeblePerson(int id, string name, DateTime birthday)
        {
            Id = new SomeInfo<int> { Value = id };
            Name= new SomeInfo<string> { Value = name };
            Birthday = new SomeInfo<DateTime> { Value = birthday };
        }

        public override string ToString()
        {
            return $"Id: {_id.Value} Name: {_name.Value} Birthday: {_birthday.Value}";
        }
    }

    public class SomeInfo<T>
    {
        [XmlAttribute]
        public T Value { get; set; }
    }
}
