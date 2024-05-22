using System;
using System.Linq;

namespace RoundingNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();


            string[] items = line.
                Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int[] numbers = new int[items.Length];

            for (int i = 0; i < items.Length; i++)
            {
                numbers[i] = int.Parse(items[i]);
            }

            int sumEven = 0;
            int sumOdd = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    sumEven += numbers[i];
                }
                else
                {
                    sumOdd += numbers[i];
                }
            }
            int sumFinal = sumEven - sumOdd;
            Console.WriteLine(sumFinal);
        }
    }
}
