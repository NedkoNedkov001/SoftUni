using System;
using System.Collections.Generic;
using System.Linq;

namespace RadioactiveMutantVampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            //Define matrix
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            char[,] matrix = new char[rows, cols];

            //Fill matrix
            for (int row = 0; row < rows; row++)
            {
                char[] input = Console.ReadLine()
                    .ToCharArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            //Find player
            int playerRow = -1;
            int playerCol = -1;
            int finalRow = -1;
            int finalCol = -1;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            //Find bunnies
            List<int[]> bunnies = FindBunnies(matrix);

            //Get moves
            char[] moves = Console.ReadLine()
                .ToCharArray();

            bool playerWon = false;
            bool playerLost = false;

            //Move player
            for (int move = 0; move < moves.Length; move++)
            {
                switch (moves[move])
                {
                    case 'U':
                        if (playerRow == 0)
                        {
                            finalRow = playerRow;
                            finalCol = playerCol;
                        }
                        matrix[playerRow, playerCol] = '.';
                        if (playerRow > 0)
                        {
                            if (!playerWon)
                            {
                                if (CheckLose(matrix, playerRow-1, playerCol))
                                {
                                    playerLost = true;
                                    finalRow = playerRow-1;
                                    finalCol = playerCol;
                                }
                                else
                                {
                                    matrix[playerRow-1, playerCol] = 'P';
                                }
                            }
                        }
                        playerRow--;
                        //Check if player won
                        playerWon = CheckWin(matrix, playerRow, playerCol, playerWon);
                        break;

                    case 'D':
                        if (playerRow == matrix.GetLength(0) - 1)
                        {
                            finalRow = playerRow;
                            finalCol = playerCol;
                        }
                        matrix[playerRow, playerCol] = '.';
                        if (playerRow < matrix.GetLength(0) - 1)
                        {
                            if (!playerWon)
                            {
                                if (CheckLose(matrix, playerRow + 1, playerCol))
                                {
                                    playerLost = true;
                                    finalRow = playerRow + 1;
                                    finalCol = playerCol;
                                }
                                else
                                {
                                    matrix[playerRow + 1, playerCol] = 'P';
                                }
                            }
                        }
                        playerRow++;
                        //Check if player won
                        playerWon = CheckWin(matrix, playerRow, playerCol, playerWon);
                        break;
                    case 'L':
                        if (playerCol == 0)
                        {
                            finalRow = playerRow;
                            finalCol = playerCol;
                        }
                        matrix[playerRow, playerCol] = '.';
                        if (playerCol > 0)
                        {
                            if (!playerWon)
                            {
                                if (CheckLose(matrix, playerRow, playerCol - 1))
                                {
                                    playerLost = true;
                                    finalRow = playerRow;
                                    finalCol = playerCol - 1;
                                }
                                else
                                {
                                    matrix[playerRow, playerCol - 1] = 'P';
                                }
                            }
                        }
                        playerCol--;
                        //Check if player won
                        playerWon = CheckWin(matrix, playerRow, playerCol, playerWon);
                        break;
                    //Go Right
                    case 'R':
                        //If player is right-most
                        if (playerCol == matrix.GetLength(1) - 1)
                        {
                            finalRow = playerRow;
                            finalCol = playerCol;
                        }
                        //Replace player's position with empty space
                        matrix[playerRow, playerCol] = '.';
                        //If player is not right-most
                        if (playerCol < matrix.GetLength(1) - 1)
                        {
                            //If player hasn't won
                            if (!playerWon)
                            {
                                //See if player's next position contains a rabbit
                                if (CheckLose(matrix, playerRow, playerCol + 1))
                                {
                                    playerLost = true;
                                    finalRow = playerRow;
                                    finalCol = playerCol+ 1;
                                }
                                //If it does not contain a rabbit
                                else
                                {
                                    //Set player's next position
                                    matrix[playerRow, playerCol + 1] = 'P';
                                }
                            }
                        }
                        playerCol++;
                        //Check if player won
                        playerWon = CheckWin(matrix, playerRow, playerCol, playerWon);
                        break;
                    default:
                        break;
                }
                //Multiply bunnies
                MultiplyBunnies(matrix, bunnies);
                bunnies = FindBunnies(matrix);
                //If a bunny killed player
                if (!playerWon && matrix[playerRow, playerCol] == 'B')
                {
                    playerLost = true;
                    finalRow = playerRow;
                    finalCol = playerCol;
                    break;
                }
            }
            //Print matrix
            PrintMatrix(rows, cols, matrix);
            //Print win or lose
            PrintResult(finalRow, finalCol, playerWon, playerLost);
        }
        private static void PrintResult(int finalRow, int finalCol, bool playerWon, bool playerLost)
        {
            if (playerWon)
            {
                Console.WriteLine($"won: {finalRow} {finalCol}");
            }
            else if (playerLost)
            {
                Console.WriteLine($"dead: {finalRow} {finalCol}");
            }
        }

        private static void PrintMatrix(int rows, int cols, char[,] matrix)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static void MultiplyBunnies(char[,] matrix, List<int[]> bunnies)
        {
            for (int i = 0; i < bunnies.Count; i++)
            {
                int bunnyRow = bunnies[i][0];
                int bunnyCol = bunnies[i][1];

                if (bunnyRow > 0)
                {
                    matrix[bunnyRow - 1, bunnyCol] = 'B';
                }
                if (bunnyRow < matrix.GetLength(0) - 1)
                {
                    matrix[bunnyRow + 1, bunnyCol] = 'B';
                }
                if (bunnyCol > 0)
                {
                    matrix[bunnyRow, bunnyCol - 1] = 'B';
                }
                if (bunnyCol < matrix.GetLength(1) - 1)
                {
                    matrix[bunnyRow, bunnyCol + 1] = 'B';
                }
            }
        }

        private static bool CheckLose(char[,] matrix, int playerRow, int playerCol)
        {
            bool playerLost = false;
            if (matrix[playerRow, playerCol] == 'B')
            {
                playerLost = true;
            }
            return playerLost;
        }

        private static bool CheckWin(char[,] matrix, int playerRow, int playerCol, bool playerWon)
        {
            if (playerRow < 0 ||
                playerRow > matrix.GetLength(0) - 1 ||
                playerCol < 0 ||
                playerCol > matrix.GetLength(0) - 1)
            {
                playerWon = true;
            }
            return playerWon;
        }

        private static void MovePlayer(char[,] matrix, int playerRow, int playerCol, char move)
        {

        }

        private static List<int[]> FindBunnies(char[,] matrix)
        {
            List<int[]> bunnies = new List<int[]>();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        bunnies.Add(new int[] { row, col });
                    }
                }
            }

            return bunnies;
        }
    }
}
