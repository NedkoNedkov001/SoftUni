using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string line = Console.ReadLine();

                if (line == "end")
                {
                    break;
                }

                string reversedLine = string.Empty;

                for (int i = line.Length -1; i >= 0; i--)
                {
                    reversedLine += line[i];
                }

                Console.WriteLine($"{line} = {reversedLine}");
            }
        }
    }
}
