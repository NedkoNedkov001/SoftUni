using System;

namespace MathPower
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = int.Parse(Console.ReadLine());
            double power = int.Parse(Console.ReadLine());

            double result = NumberToPower(number, power);

            Console.WriteLine(result);
        }

        static double NumberToPower(double number, double power)
        {
            double result = 0d;

            result = Math.Pow(number, power);

            return result;
        }
    }
}
