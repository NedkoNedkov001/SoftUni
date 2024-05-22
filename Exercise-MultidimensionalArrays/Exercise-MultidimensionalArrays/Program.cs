using System;
using System.Linq;

namespace Exercise_MultidimensionalArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            int[,] matrix = new int[matrixSize, matrixSize];

            for (int i = 0; i< matrixSize; i++)
            {
                int[] row = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < matrixSize; j++)
                {
                    matrix[i, j] = row[j];
                }
            }

            int sumPrimaryDiagonal = 0;
            int sumSecondaryDiagonal = 0;

            for (int i = 0; i < matrixSize; i++)
            {
                sumPrimaryDiagonal += matrix[i, i];
                sumSecondaryDiagonal += matrix[i, matrixSize - 1 - i];
            }
            Console.WriteLine(Math.Abs(sumPrimaryDiagonal-sumSecondaryDiagonal));
        }
    }
}
