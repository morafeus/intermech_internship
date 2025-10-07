using System;
namespace seventeenth_lesson.Models
{
    public class Phone
    {
        public string Model { get; set; }
        public double Price { get; set; }

        public Phone(string model, double price)
        {
            Model = model; Price = price;
        }
    }
}
