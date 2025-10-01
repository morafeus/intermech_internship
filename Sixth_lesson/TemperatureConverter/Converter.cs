
using System;
using System.Collections.Generic;

namespace TemperatureConverter
{
    public static class Converter
    {
        private const double FAHRENHEIT_SCALE = 9 / 5;
        private const double FAHRENHEIT_SCALE_REV = 5 / 9;
        private const double FAHRENHEIT_OFFSET = 32;
        private const double KELVIN_OFFSET = 273.15;

        private static Dictionary<string, double> absouluteZiro = new Dictionary<string, double>()
        {
            { "ziroCelsius", -273.15},
            { "ziroFahrenheit", -459.67 },
            { "ziroKelvin", 0 }
        };


        public static double CelsiusToFahrenheit(double celsius)
        {
            absouluteZiro.TryGetValue("ziroCelsius", out double ziro);
            if (celsius < ziro)
                throw new Exception("неверный формат температуры");
            return celsius * FAHRENHEIT_SCALE + FAHRENHEIT_OFFSET;
        }

        public static double CelsiusToKelvin(double celsius)
        {
            absouluteZiro.TryGetValue("ziroCelsius", out double ziro);
            if (celsius < ziro)
                throw new Exception("неверный формат температуры");
            return celsius + KELVIN_OFFSET;
        }

        public static double FahrenheitToCelsius(double fahrenheit)
        {
            absouluteZiro.TryGetValue("ziroFahrenheit", out double ziro);
            if (fahrenheit < ziro)
                throw new Exception("неверный формат температуры");
            return (fahrenheit - FAHRENHEIT_OFFSET) * FAHRENHEIT_SCALE_REV;
        }

        public static double FahrenheitToKelvin(double fahrenheit)
        {
            absouluteZiro.TryGetValue("ziroFahrenheit", out double ziro);
            if (fahrenheit < ziro)
                throw new Exception("неверный формат температуры");
            return ((fahrenheit - FAHRENHEIT_OFFSET) * FAHRENHEIT_SCALE_REV) + KELVIN_OFFSET;
        }

        public static double KelvinToCelsius(double kelvin)
        {
            absouluteZiro.TryGetValue("ziroKelvin", out double ziro);
            if (kelvin < ziro)
                throw new Exception("неверный формат температуры");
            return kelvin - KELVIN_OFFSET;
        }

        public static double KelvinToFahrenheit(double kelvin)
        {
            absouluteZiro.TryGetValue("ziroKelvin", out double ziro);
            if (kelvin < ziro)
                throw new Exception("неверный формат температуры");
            return (kelvin - KELVIN_OFFSET) * FAHRENHEIT_SCALE + FAHRENHEIT_OFFSET;
        }
    }
}
