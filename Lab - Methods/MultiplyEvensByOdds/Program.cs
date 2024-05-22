using System;

namespace MultiplyEvensByOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            number = Math.Abs(number);

            int sumEvenDigits = GetSumOfEvenDigits(number);
            int sumOddDigits = GetSumOfOddDigits(number);
            int multipleOfEvenAndOdds = GetMultipleOfEvenAndOdds(sumEvenDigits, sumOddDigits);

            Console.WriteLine(multipleOfEvenAndOdds);
        }
        static int GetSumOfEvenDigits(int number)
        {
            int sum = 0;

            while (number > 0)
            {
                if (number % 2 == 0)
                {
                    sum += number % 10;
                }
                number /= 10;
            }
            return sum;
        }
        static int GetSumOfOddDigits(int number)
        {
            int sum = 0;

            while (number > 0)
            {
                if (number % 2 == 1)
                {
                    sum += number % 10;
                }
                number /= 10;
            }
            return sum;
        }
        
        static int GetMultipleOfEvenAndOdds(int sumEvenDigits, int sumOddDigits)
        {
            int result = sumEvenDigits * sumOddDigits;
            return result;
        }
    }
}