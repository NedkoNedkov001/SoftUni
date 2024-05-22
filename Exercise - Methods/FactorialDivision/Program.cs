using System;

namespace FactorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            double numberFirst = double.Parse(Console.ReadLine());
            double numberSecond = double.Parse(Console.ReadLine());

            double factorialNumberFirst = GetFactorial(numberFirst);
            double factorialNumberSecond = GetFactorial(numberSecond);

            Console.WriteLine($"{factorialNumberFirst / factorialNumberSecond:F2}");
        }

        private static double GetFactorial(double numberFirst)
        {
            double result = 1;
            for (int i = 1; i <= numberFirst; i++)
            {
                result *= i;
            }
            return result;
        }
    }
}
