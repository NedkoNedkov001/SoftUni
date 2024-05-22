using System;
using System.Collections.Generic;

namespace PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            SortedSet<string> elements = new SortedSet<string>();

            FillSet(elements, lines);
            Console.WriteLine(string.Join(" ", elements));
        }

        private static SortedSet<string> FillSet(SortedSet<string> elements, int lines)
        {
            for (int line = 0; line < lines; line++)
            {
                string[] compounds = Console.ReadLine().Split();

                for (int element = 0; element<compounds.Length; element++)
                {
                    elements.Add(compounds[element]);
                }
            }

            return elements;
        }
    }
}
