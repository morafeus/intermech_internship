using System;
using System.Threading;
using System.Threading.Tasks;

namespace fifteenth_lesson
{
    public class DatabaseManager
    {
        public static async Task<string> GetData()
        {
            Thread.Sleep(4000);
            return "подключен к базе данных"; 
        }
    }
}
