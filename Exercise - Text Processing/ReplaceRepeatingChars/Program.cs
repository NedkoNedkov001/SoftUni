using System;
using System.Collections.Generic;

namespace ReplaceRepeatingChars
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();

            List<string> result = new List<string> { line[0].ToString() };

            for (int i = 1; i < line.Length; i++)
            {
                if (line[i] != line[i - 1])
                {
                    result.Add(line[i].ToString());
                }
            }

            Console.WriteLine(string.Concat(result));
        }
    }
}
