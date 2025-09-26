

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace third_lesson
{
    public class FileFinder
    {
        public void FindByName(string name)
        {
            var path = GetFiles(@"d:\", name).FirstOrDefault();
            var zipPath = path.TrimEnd(".txt".ToCharArray()) + ".gz";
            using (FileStream fs = File.OpenRead(path))
            {
                var b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);
                int readLen;
                while ((readLen = fs.Read(b, 0, b.Length)) > 0)
                {
                    Console.WriteLine(temp.GetString(b, 0, readLen));
                }
            }
            ZipFiles(path, zipPath);

        }

        List<string> GetFiles(string path, string pattern)
        {
            var files = new List<string>();

            try
            {
                files.AddRange(Directory.GetFiles(path, pattern, SearchOption.TopDirectoryOnly));
                foreach (var directory in Directory.GetDirectories(path))
                    files.AddRange(GetFiles(directory, pattern));
            }
            catch (UnauthorizedAccessException) { }

            return files;
        }

        void ZipFiles(string source, string destination)
        {
            using (FileStream sourceStream = new FileStream(source, FileMode.Open, FileAccess.Read))
            using (FileStream targetStream = File.Create(destination))
            using (GZipStream compressionStream = new GZipStream(targetStream, CompressionMode.Compress))
            {
                sourceStream.CopyTo(compressionStream);
            }

            FileInfo fileInfo = new FileInfo(destination);
            Console.WriteLine($"Исходный размер: {new FileInfo(source).Length}  сжатый размер: {fileInfo.Length}"); ;
        }
    }
}
