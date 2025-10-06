using System;
using System.Diagnostics;

namespace _9_lesson
{
    public class Monitoring
    {
        private static long MBSCALE = 1024 * 1024;

        private double _memoryLimit;
        private double _memoryWarning;

        public Monitoring(double memoryLimit)
        {
            if (memoryLimit <= 0)
            {
                throw new Exception("память не может быть меньше 0");
            }

            _memoryLimit = memoryLimit;
            _memoryWarning = memoryLimit * 0.9;
        }

        public long GetMemoryValue()
        {
            //long memoryUsedInBytes = GC.GetTotalMemory(false);

            Process process = Process.GetCurrentProcess();
            process.Refresh();
            long memoryUsedInBytes = process.WorkingSet64;
            return memoryUsedInBytes / MBSCALE;
        }

        public bool CheckMemory()
        {
            var memory = GetMemoryValue();

            Console.WriteLine($"расходуется {memory} Mb памяти из допустимых {_memoryLimit} Mb");

            if (memory < _memoryWarning)
            {
                Console.WriteLine($"использование памяти в норме");
                return false;
            }
            else if( memory > _memoryWarning  && memory < _memoryLimit)
            {
                Console.WriteLine($"приложение потребляет слишком много памяти");
                return false;
            }
            else
            {
                Console.WriteLine($"приложение превышает допустимый режим потребления памяти");  
                return true;
            }
        }




        
    }
}
