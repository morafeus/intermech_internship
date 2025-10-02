using System;
using System.IO;

namespace tenth_lesson.Template
{
    public class MainReport : Template
    {
        private const string FILEPATH = "log.txt";

        public override string GetData()
        {
            Console.WriteLine("получаем данные с основного сервиса");
            return "очень основные данные";
        }

        public override void LogData(string data)
        {
            using (StreamWriter writer = new StreamWriter(FILEPATH, false))
            {
                writer.WriteLine("работа основного сервиса: " + data);
            }
        }
    }
}
