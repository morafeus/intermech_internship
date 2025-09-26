
using System;
using System.IO;

namespace third_lesson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var finder = new FileFinder();

            var path = finder.FindByName("hello_world.txt");
            var zipPath = Path.ChangeExtension(path, ".gz");

            finder.FileRead(path);

            finder.ZipFiles(path, zipPath);
        }
    }
}
