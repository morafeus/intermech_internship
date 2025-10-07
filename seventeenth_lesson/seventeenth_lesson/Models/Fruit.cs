using System;

namespace seventeenth_lesson.Models
{
    public class Fruit
    {
        public string Name { get; set; }
        public double Weight { get; set; }

        public Fruit(string name, double weight)
        {
            Name = name; Weight = weight;
        }
    }
}
