using System;

namespace AddAndSubtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberFirst = int.Parse(Console.ReadLine());
            int numberSecond = int.Parse(Console.ReadLine());
            int numberThird = int.Parse(Console.ReadLine());

            int sum = Sum(numberFirst, numberSecond);
            int result = Subtract(sum, numberThird);

            Console.WriteLine(result);
        }

        private static int Subtract(int numberFirst, int numberSecond)
        {
            int result = numberFirst - numberSecond;
            return result;
        }

        private static int Sum(int numberFirst, int numberSecond)
        {
            int result = numberFirst + numberSecond;
            return result;
        }
    }
}
