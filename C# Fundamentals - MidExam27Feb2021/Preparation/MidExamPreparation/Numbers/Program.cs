using System;
using System.Linq;

namespace Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] integers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            double averageValue = integers.Average();

            int[] result = integers
                .Where(n => n > averageValue)
                .OrderByDescending(n => n)
                .Take(5)
                .ToArray();

            if (result.Length == 0)
            {
                Console.WriteLine("No");
            }
            else
            {
                Console.WriteLine(string.Join(" ", result));
            }
        }
    }
}
