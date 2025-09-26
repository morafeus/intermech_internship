
namespace third_lesson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var finder = new FileFinder();
            finder.FindByName("hello_world.txt");
        }
    }
}
