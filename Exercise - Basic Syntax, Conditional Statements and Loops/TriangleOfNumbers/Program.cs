using System;

namespace TriangleOfNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int endNumber = int.Parse(Console.ReadLine());
            int startNumber = 1;

            while (startNumber <= endNumber)
            {
                for (int i = 1; i <= startNumber; i++)
                {
                    Console.Write($"{startNumber} ");
                }
                Console.WriteLine();
                startNumber++;
            }
        }
    }
}
