using System;
using System.Threading;

namespace _9_lesson
{
    internal class Program
    {
        private const int WARNINGSIZE = 21000000;
        private const int CRITICALSIZE = 31000000;

        static void Main(string[] args)
        {
            try
            {
                var monitor = new Monitoring(100);
                int[] largeArray = new int[WARNINGSIZE];
                if (monitor.CheckMemory())
                {
                    largeArray = null;
                }

                for (int i = 0; i < WARNINGSIZE; i++)
                {
                    largeArray[i] = i;
                }

                if (monitor.CheckMemory())
                {
                    largeArray = null;
                }

                largeArray = new int[CRITICALSIZE];
                for (int i = 0; i < CRITICALSIZE; i++)
                {
                    largeArray[i] = i;
                }

                if (monitor.CheckMemory())
                {
                    largeArray = null;
                }

                monitor.CheckMemory();

            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
            
        }


        
    }
}
