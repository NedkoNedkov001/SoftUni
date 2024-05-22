using System;
using System.Collections.Generic;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            int[,] matrix = new int[matrixSize, matrixSize];

            //Fill matrix
            for (int row = 0; row < matrixSize; row++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            //Fill bombs
            string[] allBombs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            //Explode bombs
            for (int i = 0; i < allBombs.Length; i++)
            {
                int[] currentBomb =
                    allBombs[i].Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int row = currentBomb[0];
                int col = currentBomb[1];

                if (row == 0)
                {
                    if (col == 0)
                    {
                        if (matrix[row, col + 1] > 0)
                        {
                            matrix[row, col + 1] -= matrix[row, col];
                        }
                        if (matrix[row + 1, col] > 0)
                        {
                            matrix[row + 1, col] -= matrix[row, col];
                        }
                        if (matrix[row + 1, col + 1] > 0)
                        {
                            matrix[row + 1, col + 1] -= matrix[row, col];
                        }
                        if (matrix[row, col] > 0)
                        {
                            matrix[row, col] -= matrix[row, col];
                        }
                    }
                    else if (col == matrix.GetLength(1) - 1)
                    {
                        if (matrix[row, col - 1] > 0)
                        {
                            matrix[row, col - 1] -= matrix[row, col];
                        }
                        if (matrix[row + 1, col - 1] > 0)
                        {
                            matrix[row + 1, col - 1] -= matrix[row, col];
                        }
                        if (matrix[row + 1, col] > 0)
                        {
                            matrix[row + 1, col] -= matrix[row, col];
                        }
                        if (matrix[row, col] > 0)
                        {
                            matrix[row, col] -= matrix[row, col];
                        }

                    }
                    else if (col > 0 && col < matrix.GetLength(1) - 1)
                    {
                        if (matrix[row, col - 1] > 0)
                        {
                            matrix[row, col - 1] -= matrix[row, col];
                        }
                        if (matrix[row, col + 1] > 0)
                        {
                            matrix[row, col + 1] -= matrix[row, col];
                        }
                        if (matrix[row + 1, col - 1] > 0)
                        {
                            matrix[row + 1, col - 1] -= matrix[row, col];
                        }
                        if (matrix[row + 1, col] > 0)
                        {
                            matrix[row + 1, col] -= matrix[row, col];
                        }
                        if (matrix[row + 1, col + 1] > 0)
                        {
                            matrix[row + 1, col + 1] -= matrix[row, col];
                        }
                        if (matrix[row, col] > 0)
                        {
                            matrix[row, col] -= matrix[row, col];
                        }

                    }
                }
                else if (row == matrix.GetLength(0) - 1)
                {
                    if (col == 0)
                    {
                        if (matrix[row - 1, col] > 0)
                        {
                            matrix[row - 1, col] -= matrix[row, col];
                        }
                        if (matrix[row - 1, col + 1] > 0)
                        {
                            matrix[row - 1, col + 1] -= matrix[row, col];
                        }
                        if (matrix[row, col + 1] > 0)
                        {
                            matrix[row, col + 1] -= matrix[row, col];
                        }
                        if (matrix[row, col] > 0)
                        {
                            matrix[row, col] -= matrix[row, col];
                        }

                    }
                    else if (col == matrix.GetLength(1) - 1)
                    {
                        if (matrix[row - 1, col - 1] > 0)
                        {
                            matrix[row - 1, col - 1] -= matrix[row, col];
                        }
                        if (matrix[row - 1, col] > 0)
                        {
                            matrix[row - 1, col] -= matrix[row, col];
                        }
                        if (matrix[row, col - 1] > 0)
                        {
                            matrix[row, col - 1] -= matrix[row, col];
                        }
                        if (matrix[row, col] > 0)
                        {
                            matrix[row, col] -= matrix[row, col];
                        }

                    }
                    else if (col > 0 && col < matrix.GetLength(1) - 1)
                    {
                        if (matrix[row - 1, col - 1] > 0)
                        {
                            matrix[row - 1, col - 1] -= matrix[row, col];
                        }
                        if (matrix[row - 1, col] > 0)
                        {
                            matrix[row - 1, col] -= matrix[row, col];
                        }
                        if (matrix[row - 1, col + 1] > 0)
                        {
                            matrix[row - 1, col + 1] -= matrix[row, col];
                        }
                        if (matrix[row, col - 1] > 0)
                        {
                            matrix[row, col - 1] -= matrix[row, col];
                        }
                        if (matrix[row, col + 1] > 0)
                        {
                            matrix[row, col + 1] -= matrix[row, col];
                        }            
                        if (matrix[row, col] > 0)
                        {
                            matrix[row, col] -= matrix[row, col];
                        }

                    }
                }
                else if (row > 0 && row < matrix.GetLength(0) - 1)
                {
                    if (col == 0)
                    {
                        if (matrix[row - 1, col] > 0)
                        {
                            matrix[row - 1, col] -= matrix[row, col];
                        }
                        if (matrix[row - 1, col + 1] > 0)
                        {
                            matrix[row - 1, col + 1] -= matrix[row, col];
                        }
                        if (matrix[row, col + 1] > 0)
                        {
                            matrix[row, col + 1] -= matrix[row, col];
                        }
                        if (matrix[row + 1, col] > 0)
                        {
                            matrix[row + 1, col] -= matrix[row, col];
                        }
                        if (matrix[row + 1, col + 1] > 0)
                        {
                            matrix[row + 1, col + 1] -= matrix[row, col];
                        }
                        if (matrix[row, col] > 0)
                        {
                            matrix[row, col] -= matrix[row, col];
                        }
                    }
                    else if (col == matrix.GetLength(1) - 1)
                    {
                        if (matrix[row - 1, col - 1] > 0)
                        {
                            matrix[row - 1, col - 1] -= matrix[row, col];
                        }
                        if (matrix[row - 1, col] > 0)
                        {
                            matrix[row - 1, col] -= matrix[row, col];
                        }
                        if (matrix[row, col - 1] > 0)
                        {
                            matrix[row, col - 1] -= matrix[row, col];
                        }
                        if (matrix[row + 1, col - 1] > 0)
                        {
                            matrix[row + 1, col - 1] -= matrix[row, col];
                        }
                        if (matrix[row + 1, col] > 0)
                        {
                            matrix[row + 1, col] -= matrix[row, col];
                        }
                        if (matrix[row, col] > 0)
                        {
                            matrix[row, col] -= matrix[row, col];
                        }

                    }

                    else if (col > 0 && col < matrix.GetLength(1) - 1)
                    {
                        if (matrix[row - 1, col - 1] > 0)
                        {
                            matrix[row - 1, col - 1] -= matrix[row, col];
                        }
                        if (matrix[row - 1, col] > 0)
                        {
                            matrix[row - 1, col] -= matrix[row, col];
                        }
                        if (matrix[row - 1, col + 1] > 0)
                        {
                            matrix[row - 1, col + 1] -= matrix[row, col];
                        }
                        if (matrix[row, col - 1] > 0)
                        {
                            matrix[row, col - 1] -= matrix[row, col];
                        }
                        if (matrix[row, col + 1] > 0)
                        {
                            matrix[row, col + 1] -= matrix[row, col];
                        }
                        if (matrix[row + 1, col - 1] > 0)
                        {
                            matrix[row + 1, col - 1] -= matrix[row, col];
                        }
                        if (matrix[row + 1, col] > 0)
                        {
                            matrix[row + 1, col] -= matrix[row, col];
                        }
                        if (matrix[row + 1, col + 1] > 0)
                        {
                            matrix[row + 1, col + 1] -= matrix[row, col];
                        }
                        if (matrix[row, col] > 0)
                        {
                            matrix[row, col] -= matrix[row, col];
                        }
                    }
                }
            }

            //Find alive cells and their sum
            int aliveCells = 0;
            int sumAliveCells = 0;
            foreach (var item in matrix)
            {
                if (item > 0)
                {
                    aliveCells++;
                    sumAliveCells += item;
                }
            }

            //Print alive cells, their sum and the final matrix
            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sumAliveCells}");
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }

        }
    }
}
