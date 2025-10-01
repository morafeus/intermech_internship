
using System;
using System.Xml;

namespace fifth_lesson
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            const string relativePath = @"D:\internship\file_system\TelephoneBook.xml";
            try
            {
                var doc = new XmlDocument();
                doc.Load(relativePath);

                XmlNode node = doc.DocumentElement.SelectSingleNode("/MyContacts");

                if (node != null)
                {
                    foreach (XmlNode child in node.ChildNodes)
                    {
                        Console.WriteLine(child.Attributes["TelephoneNumber"].InnerText);
                    }
                }
                else
                {
                    throw new Exception("некорректный формат документа");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            } 
            
           
        }

    }
}
