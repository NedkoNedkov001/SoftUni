using System;

namespace ArrayRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int rotations = int.Parse(Console.ReadLine());
            rotations = (rotations % array.Length);

            


            for (int i = 0; i < rotations; i++)
            {
                string firstElement = array[0];
                for (int j = 1; j <= array.Length - 1; j++)
                {
                    array[j - 1] = array[j];
                }
                array[array.Length - 1] = firstElement;

            }

            foreach (var item in array)
            {
                Console.Write($"{item} ");
            }
        }
    }
}
