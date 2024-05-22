using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab___Associative_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<int, int> numbers = new SortedDictionary<int, int>();

            int[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            foreach (var key in input)
            {
                if (numbers.ContainsKey(key))
                {
                    numbers[key]++;
                }
                else
                {
                    numbers.Add(key, 1);
                }
            }

            foreach (var item in numbers)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
