using System;
using System.Collections.Generic;
using System.IO;
using System.Linq; 
using System.Text;
using System.Threading.Tasks;

namespace SeekAndArchive
{
    class Program
    {
        private static List<FileInfo> _foundFiles;

        static void Main(string[] args)
        {
            string fileName = args[0];
            string directoryName = args[1];
            _foundFiles = new List<FileInfo>();

            // Examine if the given directory exists at all 
            DirectoryInfo rootDir = new DirectoryInfo(directoryName);
            if (!rootDir.Exists)
            {
                Console.WriteLine("The specified directory does not exist.");
                return;
            }

            // Search recursively for the mathing files 
            RecursiveSearch(_foundFiles, fileName, rootDir);

            // List the found files 
            Console.WriteLine("Found {0} files.", _foundFiles.Count);

            foreach (FileInfo fil in _foundFiles)
            {
                Console.WriteLine("{0}", fil.FullName);
            }
        }

        static void RecursiveSearch(List<FileInfo> foundFiles, string fileName, DirectoryInfo currentDirectory)
        {
            foreach (FileInfo fil in currentDirectory.GetFiles())
            {
                if (fil.Name == fileName)
                    foundFiles.Add(fil);
            }

            // Continue the search recursively 
            foreach (DirectoryInfo dir in currentDirectory.GetDirectories())
            {
                RecursiveSearch(foundFiles, fileName, dir);
            }
        }

    }
}
