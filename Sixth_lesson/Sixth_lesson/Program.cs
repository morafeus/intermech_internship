


using System;
using System.Reflection;

namespace Sixth_lesson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var relativePath = @"..\..\..\TemperatureConverter\bin\Debug\TemperatureConverter.dll"; // Корректируйте путь при необходимости
            var assembly = Assembly.LoadFrom(relativePath);

            var type = assembly.GetType("TemperatureConverter.Converter");
            var instance = Activator.CreateInstance(type);

            var tempResult = type.GetMethod("CelsiusToFahrenheit").Invoke(instance, new object[] { 25.5});
            Console.WriteLine(tempResult);

        }
    }
}
