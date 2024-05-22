using System;
using System.Linq;

namespace SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            char[,] matrix = new char[size[0],size[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] currentRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    matrix[row, column] = currentRow[column];
                }
            }

            int count = 0;

            for (int row = 0; row < matrix.GetLength(0) -1 ; row++)
            {
                for (int column = 0; column < matrix.GetLength(1) - 1; column++)
                {
                    if (matrix[row, column] == matrix[row, column+1] &&
                        matrix[row, column] == matrix[row+1, column] &&
                        matrix[row, column] == matrix[row+1, column + 1])
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine(count);

        }
    }
}
