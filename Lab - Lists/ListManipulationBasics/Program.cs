using System;
using System.Collections.Generic;
using System.Linq;

namespace ListManipulationBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                string[] command = input.
                    Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "Add")
                {
                    AddNumber(command[1], numbers);
                }
                else if (command[0] == "Remove")
                {
                    RemoveNumber(command[1], numbers);
                }
                else if (command[0] == "RemoveAt")
                {
                    RemoveIndex(command[1], numbers);
                }
                else if (command[0] == "Insert")
                {
                    InsertNumber(command[1], command[2], numbers);
                }
            }
            foreach (var item in numbers)
            {
                Console.Write($"{item} ");
            }
        }

        private static void InsertNumber(string value, string index, List<int> numbers)
        {
            numbers.Insert(int.Parse(index), int.Parse(value));
        }

        private static void RemoveIndex(string index, List<int> numbers)
        {
            numbers.RemoveAt(int.Parse(index));
        }

        private static void RemoveNumber(string value, List<int> numbers)
        {
            numbers.RemoveAll(n => n == int.Parse(value));
        }

        private static void AddNumber(string value, List<int> numbers)
        {
            numbers.Add(int.Parse(value));
        }
    }
}
