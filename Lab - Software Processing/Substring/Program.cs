using System;

namespace Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string removeWord = Console.ReadLine().ToLower();
            string input = Console.ReadLine();

            while (input.Contains(removeWord))
            {
               input = input.Replace(removeWord, string.Empty);
            }

            Console.WriteLine(input);
        }
    }
}
