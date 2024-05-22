using System;
using System.Collections.Generic;
using System.Linq;

namespace SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] lengths = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();
            FillSets(firstSet, lengths[0]);
            FillSets(secondSet, lengths[1]);
            CheckSets(firstSet, secondSet);
        }
        private static void CheckSets(HashSet<int> firstSet, HashSet<int> secondSet)
        {
            List<int> nums = new List<int>();
            foreach (int number in firstSet)
            {
                if (secondSet.Contains(number))
                {
                    nums.Add(number);
                }
            }
            Console.WriteLine(string.Join(" ", nums));
        }
        private static HashSet<int> FillSets(HashSet<int> set, int length)
        {
            for (int i =0; i < length; i++)
            {
                set.Add(int.Parse(Console.ReadLine()));
            }
            return set;
        }
    }
}
