using System;
using System.Linq;

namespace SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = GetArray();

            int rows = sizes[0];
            int columns = sizes[1];

            int[,] matrix = new int[rows, columns];

            for (int row = 0; row < rows; row++)
            {
                int[] currentRow = GetArray();
                for (int column = 0; column < columns; column++)
                {
                    matrix[row, column] = currentRow[column];
                }
            }

            int maxSum = 0;
            int[] startIndex = { 0, 0 };

            for (int row = 0; row < rows - 1; row++)
            {
                for (int column = 0; column < columns - 1; column++)
                {
                    int currentSum = matrix[row, column] + 
                        matrix[row + 1, column] + 
                        matrix[row, column + 1] + 
                        matrix[row + 1, column + 1];

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        startIndex[0] = row;
                        startIndex[1] = column;
                    }
                }
            }

            Console.WriteLine($"{matrix[startIndex[0],startIndex[1]]} {matrix[startIndex[0], startIndex[1]+1]}");
            Console.WriteLine($"{matrix[startIndex[0]+1, startIndex[1]]} {matrix[startIndex[0]+1, startIndex[1] + 1]}");
            Console.WriteLine(maxSum);
        }

        private static int[] GetArray()
        {
            return Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
