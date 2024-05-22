using System;
using System.Linq;

namespace CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> predicate = str => str[0] == str.ToUpper()[0];

            Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(predicate)
                .ToList()
                .ForEach(w => Console.WriteLine(w));
        }
    }
}
