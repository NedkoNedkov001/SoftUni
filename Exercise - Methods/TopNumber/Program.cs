using System;

namespace TopNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            GetTopNumbers(number);
        }

        private static void GetTopNumbers(int number)
        {
            for (int i = 1; i <= number; i++)
            {
                int currentNumber = i;
                int sumDigits = 0;
                bool hasOddDigit = false;
                bool divisibleByEight = false;
                while (currentNumber > 0)
                {
                    if (currentNumber % 2 == 1)
                    {
                        hasOddDigit = true;
                    }
                    sumDigits += currentNumber % 10;
                    currentNumber /= 10;
                }
                if (sumDigits % 8 == 0)
                {
                    divisibleByEight = true;
                }
                if (divisibleByEight == true &&
                    hasOddDigit == true)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
