using System;
using System.Linq;

namespace JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            long[][] matrix = new long[rows][];

            PopulateMatrix(rows, matrix);

            AnalyzeMatrix(rows, matrix);

            ModifyMatrix(matrix);

            PrintMatrix(rows, matrix);
        }

        private static void ModifyMatrix(long[][] matrix)
        {
            while (true)
            {
                string[] command = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (command[0].ToLower() == "end")
                {
                    break;
                }
                else if (command[0].ToLower() == "add" && command.Length == 4)
                {
                    AddElements(matrix, command[1], command[2], command[3]);
                }
                else if (command[0].ToLower() == "subtract" && command.Length == 4)
                {
                    SubtractElements(matrix, command[1], command[2], command[3]);
                }
            }
        }

        private static void PopulateMatrix(int rows, long[][] matrix)
        {
            for (int row = 0; row < rows; row++)
            {
                long[] currentRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse)
                    .ToArray();
                matrix[row] = currentRow;
            }
        }

        private static void AnalyzeMatrix(int rows, long[][] matrix)
        {
            for (int row = 0; row < rows - 1; row++)
            {
                if (matrix[row].GetLength(0) == matrix[row + 1].GetLength(0))
                {
                    MultiplyElements(matrix, row);
                }
                else
                {
                    DivideElements(matrix, row);
                }
            }
        }

        private static void PrintMatrix(int rows, long[][] matrix)
        {
            for (int row = 0; row < rows; row++)
            {
                Console.WriteLine(string.Join(' ', matrix[row]));
            }
        }

        private static void SubtractElements(long[][] matrix, string v1, string v2, string v3)
        {
            int row = int.Parse(v1);
            int col = int.Parse(v2);
            long val = long.Parse(v3);

            if (row >= 0 && row < matrix.GetLength(0) &&
                col >= 0 && col < matrix[row].GetLength(0))
            {
                matrix[row][col] -= val;
            }
        }

        private static void AddElements(long[][] matrix, string v1, string v2, string v3)
        {
            int row = int.Parse(v1);
            int col = int.Parse(v2);
            long val = long.Parse(v3);

            if (row >= 0 && row < matrix.GetLength(0) &&
                col >= 0 && col < matrix[row].GetLength(0))
            {
                matrix[row][col] += val;
            }
        }

        private static void DivideElements(long[][] matrix, int row)
        {
            for (int col = 0; col < matrix[row].GetLength(0); col++)
            {
                matrix[row][col] /= 2;
            }
            for (int col = 0; col < matrix[row+1].GetLength(0); col++)
            {
                matrix[row + 1][col] /= 2;
            }
        }

        private static void MultiplyElements(long[][] matrix, int row)
        {
            for (int col = 0; col < matrix[row].GetLength(0); col++)
            {
                matrix[row][col] *= 2;
                matrix[row+1][col] *= 2;

            }

        }
    }
}
