using System;
using System.Text.RegularExpressions;

namespace SoftUniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            double totalProfit = 0;

            Regex regex = new Regex(@"^[^|$%.]*%(?<name>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<quantity>\d+)\|[^|$%.]*?(?<price>\d+\.?\d*)[^|$%.]*\$$");


            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end of shift")
                {
                    break;
                }

                Match match = regex.Match(input);
                if (!match.Success)
                {
                    continue;
                }
                string name = match.Groups["name"].Value;
                string product = match.Groups["product"].Value;
                int quantity = int.Parse(match.Groups["quantity"].Value);
                double price = double.Parse(match.Groups["price"].Value);

                double totalPrice = quantity * price;
                totalProfit += totalPrice;

                Console.WriteLine($"{name}: {product} - {totalPrice:F2}");
            }
            Console.WriteLine($"Total income: {totalProfit:F2}");
        }
    }
}
