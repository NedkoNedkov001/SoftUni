using System;
using System.Collections.Generic;
using System.Linq;

namespace LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> legendaryItems = new Dictionary<string, int>
            {
                {"shards", 0 },
                {"fragments", 0 },
                {"motes", 0 }
            };

            Dictionary<string, int> junkItems = new Dictionary<string, int>();

            bool legendaryObtained = false;
            string legendaryItemName = "";

            while (!legendaryObtained)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);


                for (int i = 0; i < input.Length; i += 2)
                {
                    string item = input[i + 1].ToLower();
                    int quantity = int.Parse(input[i]);

                    if (legendaryItems.ContainsKey(item))
                    {
                        legendaryItems[item] += quantity;

                        if (legendaryItems[item] >= 250)
                        {
                            legendaryItemName = item;
                            legendaryItems[item] -= 250;
                            legendaryObtained = true;
                            break;
                        }
                    }
                    else
                    {
                        if (junkItems.ContainsKey(item))
                        {
                            junkItems[item] += quantity;
                        }
                        else
                        {
                            junkItems.Add(item, quantity);
                        }
                    }
                }
            }

            switch (legendaryItemName)
            {
                case "shards":
                    Console.WriteLine("Shadowmourne obtained!");
                    break;
                case "fragments":
                    Console.WriteLine("Valanyr obtained!");
                    break;
                case "motes":
                    Console.WriteLine("Dragonwrath obtained!");
                    break;
                default:
                    break;
            }

            Dictionary<string, int> sortedLegendaryItems = legendaryItems
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);
            Dictionary<string, int> sortedJunkItems = junkItems
                .OrderBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var item in sortedLegendaryItems)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
            foreach (var item in sortedJunkItems)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
