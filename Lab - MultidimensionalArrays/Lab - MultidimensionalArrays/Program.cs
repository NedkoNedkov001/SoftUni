using System;
using System.Linq;

namespace Lab___MultidimensionalArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = GetArrayFromConsole();

            int rows = sizes[0];
            int columns = sizes[1];

            int[,] matrix = new int[rows, columns];

            for (int row = 0; row < rows; row++)
            {
                int[] currentRow = GetArrayFromConsole();

                for (int column = 0; column < columns; column ++)
                {
                    matrix[row, column] = currentRow[column];
                }
            }

            int sum = 0;
            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    sum += matrix[row, column];
                }
            }


            Console.WriteLine(rows);
            Console.WriteLine(columns);
            Console.WriteLine(sum);
        }

        private static int[] GetArrayFromConsole()
        {
            return Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
