using System;

namespace RefactorSpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            for (int i = 1; i <= number; i++)
            {
                int currentNum = i;
                bool isSpecial = false;
                int sum = 0;
                while (currentNum > 0)
                {
                    sum += currentNum % 10;
                    currentNum = currentNum / 10;
                }
                if (sum == 5 || sum == 7 || sum == 11) isSpecial = true;
                Console.WriteLine($"{i} -> {isSpecial}");
            }
        }
    }
}
