using System;

namespace StrongNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int initialNumber = number;

            int sumFactorials = 0;
            int factorial = 1;

            while (number > 0)
            {
                int lastDigit = number % 10;
                for (int i = lastDigit; i >= 1; i--)
                {
                    factorial *= i;
                }
                sumFactorials += factorial;
                number /= 10;
                factorial = 1;
            }
            if (sumFactorials == initialNumber)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
