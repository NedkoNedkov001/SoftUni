using System;
using System.Linq;

namespace AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal[] prices = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse)
                .Select(x => x = x + x * 0.20M)
                .ToArray();

            foreach (double price in prices)
            {
                Console.WriteLine($"{price:F2}");
            }
        }
    }
}
