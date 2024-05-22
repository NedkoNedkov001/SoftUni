using System;
using System.Linq;

namespace TopIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbersArray = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            
            for (int i = 0; i < numbersArray.Length; i++)
            {
                bool isTopInteger = true;
                for (int j = i+1; j < numbersArray.Length; j++)
                {
                    if (numbersArray[i] <= numbersArray[j])
                    {
                        isTopInteger = false;
                    }
                }
                if (isTopInteger)
                {
                    Console.Write($"{numbersArray[i]} ");
                }
            }
        }
    }
}
