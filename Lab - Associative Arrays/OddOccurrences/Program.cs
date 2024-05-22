using System;
using System.Collections.Generic;
using System.Linq;

namespace OddOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> words = new Dictionary<string, int>();

            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            foreach (var key in input)
            {
                string currentWord = key.ToLower();
                if (words.ContainsKey(currentWord))
                {
                    words[currentWord]++;
                }
                else
                {
                    words.Add(currentWord, 1);
                }
            }

            foreach (var item in words)
            {
                if (item.Value % 2 == 1)
                {
                    Console.Write($"{item.Key} ");
                }
            }
        }
    }
}
