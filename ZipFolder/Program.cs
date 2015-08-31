using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZipFolder
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args == null || args.Count() == 0)
            {
                Console.WriteLine("Error: Source directory and archive filename not given.");
                Console.ReadLine();
                return;
            }

            var source = args[0];
            if (string.IsNullOrEmpty(source))
            {
                Console.WriteLine("Error: Source directory path is empty.");
                Console.ReadLine();
                return;
            }

            if (!Directory.Exists(source))
            {
                Console.WriteLine("Error: Source directory path not exists: " + source);
                Console.WriteLine("May be you missed enclosing path with \", for example \"C:\\Some folder\" ");
                Console.ReadLine();
                return;
            }

            if (args != null && args.Count() == 1)
            {
                Console.WriteLine("Error: Archive file path not given.");
                Console.ReadLine();
                return;
            }

            var archiveFilePath = args[1];

            if (File.Exists(archiveFilePath))
            {
                File.Delete(archiveFilePath);
            }

            ZipFile.CreateFromDirectory(source, archiveFilePath);
        }
    }
}
