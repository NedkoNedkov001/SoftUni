using System;

namespace SmallestOfThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberFirst = int.Parse(Console.ReadLine());
            int numberSecond = int.Parse(Console.ReadLine());
            int numberThird = int.Parse(Console.ReadLine());

            int numberSmallest = GetSmallestNum(numberFirst, numberSecond, numberThird);

            Console.WriteLine(numberSmallest);
        }

        static int GetSmallestNum(int numberFirst, int numberSecond, int numberThird)
        {
            int numberSmallest = Math.Min(Math.Min(numberFirst, numberSecond), numberThird);

            return numberSmallest;
        }
    }
}
