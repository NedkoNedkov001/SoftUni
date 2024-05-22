using System;
using System.Linq;

namespace ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] fileLocation = Console.ReadLine()
                .Split("\\", StringSplitOptions.RemoveEmptyEntries);

            string[] currentFile = fileLocation[fileLocation.Length - 1]
                .Split(".", StringSplitOptions.RemoveEmptyEntries);

            string extension = currentFile[currentFile.Length - 1];
            string fileName = currentFile[0];

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {extension}");
        }
    }
}
