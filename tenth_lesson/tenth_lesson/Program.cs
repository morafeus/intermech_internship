
using tenth_lesson.TemplateMethod;

namespace tenth_lesson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var mainReport = new MainReport();
            mainReport.GenerateReport();

            var secondaryReport = new SecondaryReport();
            secondaryReport.GenerateReport();
        }
    }
}
