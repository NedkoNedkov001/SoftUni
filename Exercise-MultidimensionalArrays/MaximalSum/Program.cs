using System;
using System.Linq;

namespace MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[sizes[0], sizes[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    matrix[row, column] = currentRow[column];
                }
            }


            int maxSum = int.MinValue;
            int startRow = 0;
            int startColumn = 0;




            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int column = 0; column < matrix.GetLength(1) - 2; column++)
                {
                    int currentSum = matrix[row, column] +
                        matrix[row, column + 1] +
                        matrix[row, column + 2] +
                        matrix[row + 1, column] +
                        matrix[row + 1, column + 1] +
                        matrix[row + 1, column + 2] +
                        matrix[row + 2, column] +
                        matrix[row + 2, column + 1] +
                        matrix[row + 2, column + 2];
                    if (currentSum > maxSum)
                    {
                        startRow = row;
                        startColumn = column;
                        maxSum = currentSum;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");
            for (int row = startRow; row <= startRow + 2; row++)
            {
                for (int column = startColumn; column <= startColumn + 2; column++)
                {
                    Console.Write($"{matrix[row, column]} ");
                }
                Console.WriteLine();
            }

        }
    }
}
