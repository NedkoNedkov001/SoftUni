using System;
using System.Collections.Generic;
using System.Linq;

namespace GaussTrick
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToList();


            int limit = numbers.Count / 2;

                for (int i = 0; i < limit; i++)
                {
                    numbers[i] += numbers[numbers.Count - 1];
                    numbers.RemoveAt(numbers.Count - 1);
                }

            foreach (var number in numbers)
            {
                Console.Write($"{number} ");
            }
        }
    }
}
