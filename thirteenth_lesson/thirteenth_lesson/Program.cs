using System;

namespace thirteenth_lesson
{
    internal class Program
    {
        public delegate string MyDelegate(string name);

        static void Main(string[] args)
        {
            var handler = new MyDelegate(DoSomething);

            var result = handler.BeginInvoke("Alexey", AsyncDoSomething, handler);

            Console.ReadLine();
        }

        static string DoSomething(string name)
        {
            if (name != null)
            {

                return "hello, " + name;
            }
            else
                return null;
        }

        static void AsyncDoSomething(IAsyncResult result)
        {
            var handler = (MyDelegate)result.AsyncState;
            var finalResult = handler.EndInvoke(result);
            if(finalResult != null)
            {
                Console.WriteLine(finalResult + ", and good luck to you");
            }
        }
    }
}
