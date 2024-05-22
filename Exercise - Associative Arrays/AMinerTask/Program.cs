using System;
using System.Collections.Generic;

namespace AMinerTask
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, int> materials = new Dictionary<string, int>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "stop")
                {
                    break;
                }

                string material = input;
                int quantity = int.Parse(Console.ReadLine());

                if (materials.ContainsKey(material))
                {
                    materials[material] += quantity;
                }
                else
                {
                    materials.Add(material, quantity);
                }
            }

            foreach (var material in materials)
            {
                Console.WriteLine($"{material.Key} -> {material.Value}");
            }
        }
    }
}
