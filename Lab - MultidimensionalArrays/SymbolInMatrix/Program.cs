using System;

namespace SymbolInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                string currentRow = Console.ReadLine();
                for (int column = 0; column < size; column++)
                {
                    matrix[row, column] = currentRow[column];
                }
            }

            char findChar = char.Parse(Console.ReadLine());
            bool isFound = false;

            for (int row = 0; row < size; row++)
            {
                for (int column = 0; column < size; column++)
                {
                    if (matrix[row, column] == findChar)
                    {
                        isFound = true;
                        Console.WriteLine($"({row}, {column})");
                    }
                }
            }

            if (!isFound)
            {
                Console.WriteLine($"{findChar} does not occur in the matrix");
            }
        }
    }
}
