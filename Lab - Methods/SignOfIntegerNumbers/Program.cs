using System;

namespace SignOfIntegerNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            NumberSign(num);
        }

        static void NumberSign(int num)
        {
            string result = null;
            if (num > 0)
            {
                result = $"The number {num} is positive.";
            }
            else if (num < 0)
            {
                result = $"The number {num} is negative.";
            }
            else
            {
                result = $"The number {num} is zero.";
            }
            Console.WriteLine(result);

        }
    }
}
