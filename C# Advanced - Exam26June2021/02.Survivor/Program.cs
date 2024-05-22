using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace _02.Survivor
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            char[][] beach = new char[rows][];

            int myTokens = 0;
            int enemyTokens = 0;

            for (int row = 0; row < rows; row++)
            {
                char[] currentRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                beach[row] = currentRow;
            }

            while (true)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = input[0];
                if (command == "Gong")
                {
                    break;
                }

                int row = int.Parse(input[1]);
                int col = int.Parse(input[2]);

                if (command == "Find" && ValidIndices(row, col, beach))
                {
                    if (beach[row][col] == 'T')
                    {
                        myTokens++;
                        beach[row][col] = '-';
                    }
                }
                else if (command == "Opponent" && ValidIndices(row, col, beach))
                {
                    string direction = input[3];
                    enemyTokens += Move(beach, row, col, direction);
                }
            }

            foreach (var row in beach)
            {
                Console.WriteLine(string.Join(" ", row));
            }

            Console.WriteLine($"Collected tokens: {myTokens}");
            Console.WriteLine($"Opponent's tokens: {enemyTokens}");
        }

        private static int Move(char[][] matrix, int row, int col, string direction)
        {
            int collected = 0;

            if (matrix[row][col] == 'T')
            {
                collected++;
                matrix[row][col] = '-';
            }

            for (int i = 0; i < 3; i++)
            {
                if (direction == "up" && ValidIndices(row - 1, col, matrix))
                {
                    row--;
                    collected += GetToken(matrix, row, col);
                }
                else if (direction == "down" && ValidIndices(row + 1, col, matrix))
                {
                    row++;
                    collected += GetToken(matrix, row, col);
                }
                else if (direction == "left" && ValidIndices(row, col - 1, matrix))
                {
                    col--;
                    collected += GetToken(matrix, row, col);
                }
                else if (direction == "right" && ValidIndices(row, col + 1, matrix))
                {
                    col++;
                    collected += GetToken(matrix, row, col);
                }
            }

            return collected;
        }

        private static int GetToken(char[][] matrix, int row, int col)
        {
            if (matrix[row][col] == 'T')
            {
                matrix[row][col] = '-';
                return 1;
            }

            return 0;
        }

        private static bool ValidIndices(int row, int col, char[][] matrix)
        {
            return row >= 0 && row < matrix.Length &&
                   col >= 0 && col < matrix[row].Length;
        }
    }
}
