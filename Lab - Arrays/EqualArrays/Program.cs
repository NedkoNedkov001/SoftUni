using System;

namespace EqualArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputOne = Console.ReadLine();
            string[] arrOne = inputOne.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string inputTwo = Console.ReadLine();
            string[] arrTwo = inputTwo.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int sum = 0;
            bool areDifferent = false;
            for (int i = 0; i < arrOne.Length; i++)
            {
                if (arrOne[i] == arrTwo[i])
                {
                    sum += int.Parse(arrOne[i]);
                }
                else
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                    areDifferent = true;
                    break;
                }
            }
            if (areDifferent == false)
            {
                Console.WriteLine($"Arrays are identical. Sum: {sum}");
            }
        }
    }
}
