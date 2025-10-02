using System;

namespace tenth_lesson.Template
{
    public abstract class Template
    {
        public void GenerateReport()
        {
            var data = GetData();
            var result = ProcessTheData(data);
            LogData(result);
            FinishReport();
        }

        public string ProcessTheData(string data)
        {
            Console.WriteLine("обработка данных сервиса: " + data);
            return "количество ошибок: 0";
        }

        public void FinishReport()
        {
            Console.WriteLine("отчет сформирован.");
        }

        public abstract string GetData();
        public abstract void LogData(string data);
    }
}
