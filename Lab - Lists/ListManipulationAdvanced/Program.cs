using System;
using System.Collections.Generic;
using System.Linq;

namespace ListManipulationAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbersCurrent = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> numbersOriginal = new List<int>(numbersCurrent.Count);
            for (int i = 0; i < numbersCurrent.Count; i++)
            {
                numbersOriginal.Add(numbersCurrent[i]);
            }

            bool isChanged = false;

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
                    AddNumber(command[1], numbersCurrent);
                    isChanged = true;
                }
                else if (command[0] == "Remove")
                {
                    RemoveNumber(command[1], numbersCurrent);
                    isChanged = true;
                }
                else if (command[0] == "RemoveAt")
                {
                    RemoveIndex(command[1], numbersCurrent);
                    isChanged = true;
                }
                else if (command[0] == "Insert")
                {
                    InsertNumber(command[1], command[2], numbersCurrent);
                    isChanged = true;
                }
                else if (command[0] == "Contains")
                {
                    Contains(command[1], numbersCurrent);
                }
                else if (command[0] == "PrintEven")
                {
                    PrintEven(numbersCurrent);
                }
                else if (command[0] == "PrintOdd")
                {
                    PrintOdd(numbersCurrent);
                }
                else if (command[0] == "GetSum")
                {
                    GetSum(numbersCurrent);
                }
                else if (command[0] == "Filter")
                {
                    FilterNumbers(command[1], command[2], numbersCurrent);
                }
            }
            if (isChanged)
            {
                foreach (var item in numbersCurrent)
                {
                    Console.Write($"{item} ");
                }
            }
        }

        private static void Contains(string value, List<int> numbersCurrent)
        {
            bool containsNumber = false;
            foreach (var item in numbersCurrent)
            {
                if (item == int.Parse(value))
                {
                    containsNumber = true;
                    Console.WriteLine("Yes");
                }
            }
            if (containsNumber == false)
            {
                Console.WriteLine("No such number");
            }

        }
        private static void FilterNumbers(string condition, string value, List<int> numbersCurrent)
        {
            if (condition == "<")
            {
                foreach (var item in numbersCurrent)
                {
                    if (item < int.Parse(value))
                    {
                        Console.Write($"{item} ");
                    }
                }
                Console.WriteLine();
            }
            else if (condition == ">")
            {
                foreach (var item in numbersCurrent)
                {
                    if (item > int.Parse(value))
                    {
                        Console.Write($"{item} ");
                    }
                }
                Console.WriteLine();
            }
            else if (condition == ">=")
            {
                foreach (var item in numbersCurrent)
                {
                    if (item >= int.Parse(value))
                    {
                        Console.Write($"{item} ");
                    }
                }
                Console.WriteLine();
            }
            else if (condition == "<=")
            {
                foreach (var item in numbersCurrent)
                {
                    if (item <= int.Parse(value))
                    {
                        Console.Write($"{item} ");
                    }
                }
                Console.WriteLine();
            }
        }
        private static void GetSum(List<int> numbersCurrent)
        {
            int sum = 0;
            foreach (var item in numbersCurrent)
            {
                sum += item;
            }
            Console.WriteLine(sum);
        }
        private static void PrintOdd(List<int> numbersCurrent)
        {
            foreach (var item in numbersCurrent)
            {
                if (item % 2 == 1)
                {
                    Console.Write($"{item} ");
                }
            }
            Console.WriteLine();
        }
        private static void PrintEven(List<int> numbersCurrent)
        {
            foreach (var item in numbersCurrent)
            {
                if (item % 2 == 0)
                {
                    Console.Write($"{item} ");
                }
            }
            Console.WriteLine();
        }
        private static void InsertNumber(string value, string index, List<int> numbersCurrent)
        {
            numbersCurrent.Insert(int.Parse(index), int.Parse(value));
        }
        private static void RemoveIndex(string index, List<int> numbersCurrent)
        {
            numbersCurrent.RemoveAt(int.Parse(index));
        }
        private static void RemoveNumber(string value, List<int> numbersCurrent)
        {
            numbersCurrent.RemoveAll(n => n == int.Parse(value));
        }
        private static void AddNumber(string value, List<int> numbersCurrent)
        {
            numbersCurrent.Add(int.Parse(value));
        }
    }
}
