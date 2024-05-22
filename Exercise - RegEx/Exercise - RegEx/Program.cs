using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Exercise___RegEx
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@">>(?<name>[A-Z]+[a-z]*)<<(?<price>\d+.*\d*)!(?<quantity>\d+)");

            List<string> boughtFurniture = new List<string>();
            double totalCost = 0;
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Purchase")
                {
                    break;
                }

                Match match = regex.Match(input);

                if (!match.Success)
                {
                    continue;
                }

                string furnitureName = match.Groups["name"].Value;
                boughtFurniture.Add(furnitureName);
                double price = double.Parse(match.Groups["price"].Value);
                int quantity = int.Parse(match.Groups["quantity"].Value);

                totalCost += price * quantity;
            }

            Console.WriteLine("Bought furniture:");

            foreach (var item in boughtFurniture)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"Total money spend: {totalCost:F2}");
        }
    }
}
