using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Reverse()
                .ToArray();

            Stack<string> numbers = new Stack<string>(input);
            while (numbers.Count > 1)
            {
                int a = int.Parse(numbers.Pop());
                char op = char.Parse(numbers.Pop());
                int b = int.Parse(numbers.Pop());


                if (op == '+')
                {
                    numbers.Push((a + b).ToString());
                }
                else
                {
                    numbers.Push((a-b).ToString());
                }
            }

            Console.WriteLine(numbers.Pop());
        }
    }
}
