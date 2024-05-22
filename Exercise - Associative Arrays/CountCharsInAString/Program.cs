using System;
using System.Collections.Generic;

namespace CountCharsInAString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<char, int> quantityByLetters = new Dictionary<char, int>();

            foreach (char letter in input)
            {
                if (letter == ' ')
                {
                    continue;
                }

                if (quantityByLetters.ContainsKey(letter))
                {
                    quantityByLetters[letter]++;
                }
                else
                {
                    quantityByLetters.Add(letter, 1);
                }
            }

            foreach (var letter in quantityByLetters)
            {
                Console.WriteLine($"{letter.Key} -> {letter.Value}");
            }
        }
    }
}
