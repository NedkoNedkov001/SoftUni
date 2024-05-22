using System;
using System.Collections.Generic;
using System.Linq;

namespace StacksAndQueues
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> reversedString = new Stack<char>();

            foreach (char character in input)
            {
                reversedString.Push(character);
            }

            while (reversedString.Count > 0)
            {
                Console.Write(reversedString.Pop());
            }
        }
    }
}
