using System;
using System.Linq;

namespace RoundingNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputLine = Console.ReadLine();

            string[] stringArr = inputLine.
                Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = stringArr.Length-1; i >= 0; i--)
            {
                Console.Write($"{stringArr[i]} ");
            }
        }
    }
}
