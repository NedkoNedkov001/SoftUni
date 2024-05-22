using System;
using System.Linq;

namespace WordFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] items = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(x => x.Length % 2 == 0)
                .ToArray();

            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
    }
}
