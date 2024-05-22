using System;
using System.Collections.Generic;
using System.Linq;

namespace StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> numbersStack = new Stack<int>();
            foreach (int number in numbers)
            {
                numbersStack.Push(number);
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input.ToLower() == "end")
                {
                    break;
                }
                string[] command = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                switch (command[0].ToLower())
                {
                    case "add":
                        numbersStack.Push(int.Parse(command[1]));
                        numbersStack.Push(int.Parse(command[2]));
                        break;
                    case "remove":
                        if (int.Parse(command[1]) < numbersStack.Count)
                        {
                            for (int i = 0; i < int.Parse(command[1]); i++)
                            {
                                numbersStack.Pop();
                            }
                        }
                        break;
                    default:
                        break;
                }
            }

            int sum = 0;
            while (numbersStack.Count > 0)
            {
                sum += numbersStack.Pop();
            }

            Console.WriteLine($"Sum: {sum}");
        }
    }
}
