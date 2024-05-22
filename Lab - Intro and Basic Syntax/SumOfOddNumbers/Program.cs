using System;

namespace SumOfOddNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int oddNums = 0;
            int sum = 0;

            //for (int i = 1; i<=n; i++)
            //{
            //
            //}

            for (int i = 1; i < 100; i++)
            {
                if (i % 2 == 1)
                {
                    sum += i;
                    oddNums++;
                    Console.WriteLine(i);
                }
                if (oddNums == n)
                {
                    break;
                }
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
