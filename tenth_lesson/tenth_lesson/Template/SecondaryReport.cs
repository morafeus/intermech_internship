using System;
namespace tenth_lesson.Template
{
    internal class SecondaryReport : Template
    {
        public override string GetData()
        {
            Console.WriteLine("получаем данные со второстепенного сервиса");
            return "очень второстепенные данные";
        }

        public override void LogData(string data)
        {
            Console.WriteLine("работа второстепенного сервиса: " +  data);
        }
    }
}
