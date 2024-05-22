using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace MatchDate
{
    class Program
    {
        static void Main(string[] args)
        {
            var regex = @"\b(?<day>\d{2})([-.\/])(?<month>[A-Z][a-z]{2})\1(?<year>\d{4})\b";

            var dates = Console.ReadLine();

            var dateMatches = Regex.Matches(dates, regex);

            foreach (Match date in dateMatches)
            {
                var day = date.Groups["day"].Value;
                var month = date.Groups["month"].Value;
                var year = date.Groups["year"].Value;

                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }
        }
    }
}
