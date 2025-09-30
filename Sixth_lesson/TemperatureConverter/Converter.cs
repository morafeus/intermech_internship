
using System;

namespace TemperatureConverter
{
    public class Converter
    {
        public double CelsiusToFahrenheit(double celsius)
        {
            if (celsius < -273.15)
                throw new Exception("неверный формат температуры");
            return celsius * 9 / 5 + 32;
        }

        public double CelsiusToKelvin(double celsius)
        {
            if (celsius < -273.15)
                throw new Exception("неверный формат температуры");
            return celsius + 273.15;
        }

        public double FahrenheitToCelsius(double fahrenheit)
        {
            if (fahrenheit < -459.67)
                throw new Exception("неверный формат температуры");
            return (fahrenheit - 32) * 5 / 9;
        }

        public double FahrenheitToKelvin(double fahrenheit)
        {
            if (fahrenheit < -459.67)
                throw new Exception("неверный формат температуры");
            return ((fahrenheit - 32) * 5 / 9) + 273.15;
        }

        public double KelvinToCelsius(double kelvin)
        {
            if (kelvin < 0)
                throw new Exception("неверный формат температуры");
            return kelvin - 273.15;
        }

        public double KelvinToFahrenheit(double kelvin)
        {
            if (kelvin < 0)
                throw new Exception("неверный формат температуры");
            return (kelvin - 273.15)* 9 / 5 + 32;
        }
    }
}
