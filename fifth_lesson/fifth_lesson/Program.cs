
using System;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Xml;

namespace fifth_lesson
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(@"D:\internship\file_system\TelephoneBook.xml");

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
