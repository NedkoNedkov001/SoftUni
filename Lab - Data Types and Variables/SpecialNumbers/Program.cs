using System;

namespace SpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                int currentNum = i;
                int currentSum = 0;
                while (currentNum > 0)
                {
                    currentSum = currentSum + (currentNum % 10);
                    currentNum = currentNum / 10;
                }
                if (currentSum == 5 || currentSum == 7 || currentSum == 11)
                {
                    Console.WriteLine($"{i} -> True");
                }
                else
                {
                    Console.WriteLine($"{i} -> False");
                }
            }


            
        }
    }
}
