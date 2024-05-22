using System;
using System.Linq;

namespace JaggedArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] jaggedMatrix = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int column = 0; column < currentRow.Length; column++)
                {
                    jaggedMatrix[row] = currentRow;
                }
            }

            while (true)
            {
                string[] command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (command[0].ToLower() == "end")
                {
                    break;
                }
                else if (command[0].ToLower() == "add")
                {
                    AddElement(jaggedMatrix, command[1], command[2], command[3]);
                }
                else if (command[0].ToLower() == "subtract")
                {
                    SubtractElement(jaggedMatrix, command[1], command[2], command[3]);
                }
            }

            for(int row = 0; row < rows; row++)
            {
                for (int column = 0; column < jaggedMatrix[row].Length; column++)
                {
                    Console.Write($"{jaggedMatrix[row][column]} ");
                }
                Console.WriteLine();

            }

        }

        private static void SubtractElement(int[][] jaggedMatrix, string parameterOne, string parameterTwo, string parameterThree)
        {
            int row = int.Parse(parameterOne);
            int column = int.Parse(parameterTwo);
            int value = int.Parse(parameterThree);

            if (row < jaggedMatrix.GetLength(0) &&
                row >= 0 &&
                column < jaggedMatrix[row].Length &&
                column >= 0)
            {
                jaggedMatrix[row][column] -= value;
            }
            else
            {
                Console.WriteLine("Invalid coordinates");
            }
        }

        private static void AddElement(int[][] jaggedMatrix, string parameterOne, string parameterTwo, string parameterThree)
        {
            int row = int.Parse(parameterOne);
            int column = int.Parse(parameterTwo);
            int value = int.Parse(parameterThree);

            if (row <= jaggedMatrix.GetLength(0)-1 &&
                row >= 0 &&
                column <= jaggedMatrix[row].Length &&
                column >= 0)
            {
                jaggedMatrix[row][column] += value;
            }
            else
            {
                Console.WriteLine("Invalid coordinates");
            }
        }
    }
}
