using System;
using System.Threading;
using System.Threading.Tasks;

namespace fifteenth_lesson
{
    public class DatabaseManager
    {

        public static async Task<string> GetDataAsync()
        {
            return await Task.Run<string>(() => 
            {
                Thread.Sleep(4000);
                return "подключение к базе данных успешно.";
            }); 
        }

        public static async Task<string> SetDataAsync()
        {
            return await Task.Run<string>(() =>
            {
                Thread.Sleep(4000);
                return "подключение к базе данных закрыто.";
            });
        }

    }
}
