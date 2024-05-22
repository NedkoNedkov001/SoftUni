using System;
using System.Linq;

namespace Lab___MultidimensionalArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());


            int[,] matrix = new int[size,size];

            for (int row = 0; row < size; row++)
            {
                int[] currentRow = GetArrayFromConsole();

                for (int column = 0; column < size; column++)
                {
                    matrix[row, column] = currentRow[column];
                }
            }

            int sum = 0;
            for (int i = 0; i < size; i++)
            {
                sum += matrix[i, i];
            }

            Console.WriteLine(sum);
        }

        private static int[] GetArrayFromConsole()
        {
            return Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
