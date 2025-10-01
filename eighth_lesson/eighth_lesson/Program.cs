

using System;
using System.IO;
using System.Xml.Serialization;

namespace eighth_lesson
{
    internal class Program
    {
        private const string PATH = "person.xml";

        static void Main(string[] args)
        {
            var person = new SerializeblePerson(123, "Alexey", new DateTime(2005, 10, 01));
            SerializePerson(person);
            DeserializePerson();
        }

        static void SerializePerson(SerializeblePerson person)
        {
            if (person == null)
                return;
            var xmlSerializer = new XmlSerializer(person.GetType());
            using (var fs = new FileStream(PATH, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, person);
            }
        }

        static void DeserializePerson()
        {

            var xmlSerializer = new XmlSerializer(typeof(SerializeblePerson));
            using (var fs = new FileStream(PATH, FileMode.Open))
            {
                var person = xmlSerializer.Deserialize(fs);
                Console.WriteLine(person.ToString());
            }
        }
    }
}
