using System;
using System.Collections.Generic;
using System.Linq;

namespace PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> numbersQueue = new Queue<int>(numbers);
            Queue<int> evenNumbers = new Queue<int>();
            while (numbersQueue.Count > 0)
            {
                int currentNumber = numbersQueue.Dequeue();
                if (currentNumber % 2 == 0)
                {
                    evenNumbers.Enqueue(currentNumber);
                }
            }
            Console.WriteLine(string.Join(", ", evenNumbers));
        }
    }
}
