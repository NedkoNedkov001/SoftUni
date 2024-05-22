using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Race
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> racers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToDictionary(x => x, x => 0);

            Regex nameRegex = new Regex(@"[A-Za-z]+");
            Regex digitsRegex = new Regex(@"\d");


            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end of race")
                {
                    break;
                }

                MatchCollection letterMatches = nameRegex.Matches(input);
                MatchCollection digitsMatches = digitsRegex.Matches(input);

                string name = GetName(letterMatches);

                if (racers.ContainsKey(name))
                {
                    racers[name] += GetSum(digitsMatches);
                }
            }

            string[] winners = racers
                .OrderByDescending(x => x.Value)
                .Take(3)
                .Select(r => r.Key)
                .ToArray();

            Console.WriteLine($"1st place: {winners[0]}");
            Console.WriteLine($"2nd place: {winners[1]}");
            Console.WriteLine($"3rd place: {winners[2]}");
        }

        private static int GetSum(MatchCollection digitsMatches)
        {
            int sum = 0;

            foreach (Match match in digitsMatches)
            {
                sum += int.Parse(match.Value);
            }

            return sum;
        }

        private static string GetName(MatchCollection letterMatches)
        {

            StringBuilder name = new StringBuilder();

            foreach (Match match in letterMatches)
            {
                name.Append(match);
            }
            return name.ToString();
        }
    }
}
