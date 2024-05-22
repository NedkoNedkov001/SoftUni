using System;

namespace ZigZagArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int arraysNumber = int.Parse(Console.ReadLine());
            string[] firstArray = new string[arraysNumber];
            string[] secondArray = new string[arraysNumber];

            for (int i = 0; i < arraysNumber; i++)
            {
                string[] currentArray = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (i % 2 == 0)
                {
                    firstArray[i] = currentArray[0];
                    secondArray[i] = currentArray[1];
                }
                else
                {
                    firstArray[i] = currentArray[1];
                    secondArray[i] = currentArray[0];
                }
            }

            foreach (var number in firstArray)
            {
                Console.Write($"{number} ");
            }
            Console.WriteLine();

            foreach (var number in secondArray)
            {
                Console.Write($"{number} ");
            }
            Console.WriteLine();

        }
    }
}
