

namespace first_lesson.Models
{
    public class Retrie : Person
    {
        public Retrie(string name) : base(name)
        {
        }

        public override string ToString()
        {
            return base.ToString()+ " Пенсионер";
        }
    }
}
