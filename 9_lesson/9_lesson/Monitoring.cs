using System;
using System.Diagnostics;

namespace _9_lesson
{
    public class Monitoring
    {
        private static long MBSCALE = 1024 * 1024;

        private double _memoryLimit;
        private double _memoryWarning;

        public long GetMemoryValue()
        {
            Process process = Process.GetCurrentProcess();
            long memoryUsedInBytes = process.WorkingSet64;
            return memoryUsedInBytes * MBSCALE;
        }

        public void SetLimits(int memoryLimit)
        {
            _memoryLimit = memoryLimit;
            _memoryWarning = memoryLimit * 0.9;
        }

        public void CheckMemory()
        {
            var memory = GetMemoryValue();

            Console.WriteLine($"расходуется {memory} Mb памяти из допустимых {_memoryWarning} Mb");

            if (memory < _memoryWarning)
            {
                Console.WriteLine($"использование памяти в норме");
                return;
            }
            else if( memory > _memoryLimit  && memory < _memoryLimit)
            {
                Console.WriteLine($"приложение потребляет слишком много памяти");
            }
            else
            {
                Console.WriteLine($"приложение превышает допустимый режим потребления памяти");  
            }
        }




        
    }
}
