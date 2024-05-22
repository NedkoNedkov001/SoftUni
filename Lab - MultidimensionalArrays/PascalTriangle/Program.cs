using System;

namespace PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            long[][] triangle = new long[rows][];
            
            for (int i = 0; i < rows; i++)
            {
                long[] row = new long[i + 1];
                row[0] = 1;
                row[i] = 1;

                for (int j = 1; j < i; j++)
                {
                    row[j] = triangle[i - 1][j - 1] + triangle[i - 1][j];
                }
                triangle[i] = row;
            }




            for (int row = 0; row < rows; row++)
            {
                Console.WriteLine(string.Join(' ', triangle[row]));
            }
        }
    }
}
