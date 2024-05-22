using System;

namespace PoundsToDollars
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal GBP = decimal.Parse(Console.ReadLine());
            decimal USD = GBP * 1.31M;

            Console.WriteLine($"{USD:F3}");
        }
    }
}
