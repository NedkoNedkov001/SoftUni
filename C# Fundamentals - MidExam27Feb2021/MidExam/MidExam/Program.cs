using System;
using System.Linq;

namespace MidExam
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] values = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int entryPoint = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();


            long leftTotalCost = 0;
            long rightTotalCost = 0;
            for (int i = 0; i < values.Length; i ++)
            {
                if (command == "cheap" &&
                     values[i] < values[entryPoint])
                {
                    if (i < entryPoint)
                    {
                        leftTotalCost += values[i];
                    }
                    else if (i >= entryPoint)
                    {
                        rightTotalCost += values[i];
                    }
                }
                else if (command == "expensive" &&
                    values[i] >= values[entryPoint])
                {
                    if (i < entryPoint)
                    {
                        leftTotalCost += values[i];
                    }
                    else if (i >= entryPoint)
                    {
                        rightTotalCost += values[i];
                    }
                }
            }

            if (leftTotalCost >= rightTotalCost)
            {
                Console.WriteLine($"Left - {leftTotalCost}");
            }
            else
            {
                Console.WriteLine($"Right - {rightTotalCost}");
            }
        }
    }
}
