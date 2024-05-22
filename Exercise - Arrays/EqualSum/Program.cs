using System;
using System.Linq;

namespace EqualSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbersArray = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            bool equalSums = false;
            for (int i = 0; i < numbersArray.Length; i++)
            {
                int leftSum = 0;
                int rightSum = 0;
                for (int j = i - 1; j >= 0; j--)
                {
                    leftSum += numbersArray[j];
                }
                for (int k = i + 1; k < numbersArray.Length; k++)
                {
                    rightSum += numbersArray[k];
                }
                if (leftSum == rightSum)
                {
                    Console.WriteLine(i);
                    equalSums = true;
                    break;
                }
            }
            if (equalSums == false)
            {
                Console.WriteLine("no");
            }
        }
    }
}
