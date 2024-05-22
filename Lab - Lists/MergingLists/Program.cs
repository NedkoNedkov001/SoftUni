using System;
using System.Collections.Generic;
using System.Linq;

namespace MergingLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> listOne = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> listTwo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> listsMerged = new List<int>(listOne.Count+listTwo.Count);

            while (Math.Min(listOne.Count, listTwo.Count) > 0)
            {
                listsMerged.Add(listOne[0]);
                listOne.RemoveAt(0);
                listsMerged.Add(listTwo[0]);
                listTwo.RemoveAt(0);
            }

            if (listOne.Count >= 1)
            {
                while (listOne.Count >= 1)
                {
                    listsMerged.Add(listOne[0]);
                    listOne.RemoveAt(0);
                }
            }
            else if (listTwo.Count >= 1)
            {
                while (listTwo.Count >= 1)
                {
                    listsMerged.Add(listTwo[0]);
                    listTwo.RemoveAt(0);
                }
            }

            foreach (var number in listsMerged)
            {
                Console.Write($"{number} ");
            }
        }
    }
}
