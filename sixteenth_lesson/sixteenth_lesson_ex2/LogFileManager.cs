using System;
using System.IO;
using System.Threading.Tasks;

namespace sixteenth_lesson_ex2
{
    public class LogFileManager
    {
        private const string PATH = @"D:\internship\file_system\filesystemLog.txt";

        public static async Task<string> GetDataAsync()
        {
            return await Task.Run<string>(() =>
            {
                var file = File.ReadAllText(PATH);
                return file;
            });
        }
    }
}
