
using System;
using System.Reflection;

namespace seventh_lesson
{
    [Serializable]
    internal class Program
    {
        static void Main(string[] args)
        {
            var assembly = Assembly.GetExecutingAssembly();
            Console.WriteLine("\nСборка:");
            Console.WriteLine(assembly.GetName());

            var attributes = assembly.GetCustomAttributes(true);
            Console.WriteLine("\nАтрибуты:");
            foreach (var attribute in attributes) 
            {
                Console.WriteLine(attribute.ToString()); 
            }

            var files = assembly.GetFiles();
            Console.WriteLine("\nФайлы:");
            foreach (var file in files)
            {
                Console.WriteLine(file.Name);
            }

            var types = assembly.GetTypes();
            Console.WriteLine("\nТипы:");
            foreach(var type in types)
            {
                Console.WriteLine("\n   " + type.FullName + " Aтрибуты типа:");
                foreach( var attr in type.GetCustomAttributes())
                {
                    Console.WriteLine(attr.ToString());
                }
                Console.WriteLine("\nАтрибуты всех членов типа:");
                foreach(var member in type.GetMembers())
                {
                    if (CheckVisibility(member.GetCustomAttributes(false)))
                    {
                        Console.WriteLine(member.Name);
                        foreach (var attr in member.GetCustomAttributes())
                        {
                            Console.WriteLine(attr.ToString());
                        }
                    }
                    else
                    {
                        Console.WriteLine("Отказано в доступе");
                    }
                }
            }
        }

        private static bool CheckVisibility(object[] attributes)
        {
            foreach (Attribute attr in attributes)
            {
                if (attr is VisibleAttribute visibleAttribute)
                    return visibleAttribute.isVisible;
            }
            return true;
        }
        
    }
}
