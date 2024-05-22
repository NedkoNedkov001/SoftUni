using System;
using System.Collections.Generic;
using System.Linq;

namespace RemoveNegativesAndReverse
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(n => n >= 0)
                .ToList();

            if (numbers.Count > 0)
            {
                numbers.Reverse();
                foreach (var item in numbers)
                {
                    Console.Write($"{item} ");
                }
            }
            else
            {
                Console.WriteLine("empty");
            }
        }
    }
}
