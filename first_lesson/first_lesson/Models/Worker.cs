

namespace first_lesson.Models
{
    public class Worker : Person
    {
        public Worker(string name) : base(name)
        {
        }

        public override string ToString()
        {
            return base.ToString() + " Рабочий";
        }
    }
}
