

namespace first_lesson.Models
{
    internal class Student : Person
    {
        public Student(string name) : base(name)
        {
        }
        public override string ToString()
        {
            return base.ToString() + " Студент";
        }
    }
}
