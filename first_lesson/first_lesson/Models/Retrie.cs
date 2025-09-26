

namespace first_lesson.Models
{
    public class Retriee : Person
    {
        public Retriee(string name) : base(name)
        {
        }

        public override string ToString()
        {
            return base.ToString()+ " Пенсионер";
        }
    }
}
