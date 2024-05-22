using System;
using System.Linq;

namespace ArrayModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] integers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                string[] command = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "swap")
                {
                    SwapElements(integers, command[1], command[2]);
                }
                else if (command[0] == "multiply")
                {
                    MultiplyElements(integers, command[1], command[2]);
                }
                else if (command[0] == "decrease")
                {
                    DecreaseElements(integers);
                }
            }

            Console.WriteLine(string.Join(", ", integers));
        }

        private static void DecreaseElements(int[] integers)
        {
            for (int i = 0; i < integers.Length; i++)
            {
                integers[i]--;
            }
        }

        private static void MultiplyElements(int[] integers, string v1, string v2)
        {
            int idx1 = int.Parse(v1);
            int idx2 = int.Parse(v2);

            integers[idx1] *= integers[idx2];
        }

        private static void SwapElements(int[] integers, string v1, string v2)
        {
            int idx1 = int.Parse(v1);
            int idx2 = int.Parse(v2);

            int placeholder = integers[idx1];

            integers[idx1] = integers[idx2];
            integers[idx2] = placeholder;
        }
    }
}
