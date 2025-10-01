


using System;
using System.Reflection;

namespace Sixth_lesson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string relativePath = @"..\..\..\TemperatureConverter\bin\Debug\TemperatureConverter.dll";
            AssemblyName name = AssemblyName.GetAssemblyName(relativePath);
            var assembly = Assembly.Load(name);

            var type = assembly.GetType("TemperatureConverter.Converter");

            try
            {
                var tempResult = type.GetMethod("CelsiusToFahrenheit").Invoke(null, new object[] { -25.5 });
                Console.WriteLine(tempResult);
            }
            catch (TargetInvocationException ex) { Console.WriteLine(ex.InnerException.Message); }

        }
    }
}
