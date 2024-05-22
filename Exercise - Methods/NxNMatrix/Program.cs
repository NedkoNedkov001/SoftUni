using System;

namespace NxNMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixNumber = int.Parse(Console.ReadLine());

            PrintMatrix(matrixNumber);
        }

        private static void PrintMatrix(int matrixNumber)
        {
            for (int i = 0; i < matrixNumber; i++)
            {
                for (int j = 0; j < matrixNumber; j++)
                {
                    Console.Write($"{matrixNumber} ");
                }
                Console.WriteLine();
            }
        }
    }
}
