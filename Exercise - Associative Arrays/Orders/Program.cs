using System;
using System.Collections.Generic;

namespace Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> quantityByProduct = new Dictionary<string, int>();
            Dictionary<string, double> priceByProduct = new Dictionary<string, double>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "buy")
                {
                    break;
                }

                string[] command = input.Split();

                string productName = command[0];
                double productPrice = double.Parse(command[1]);
                int productQuantity = int.Parse(command[2]);

                if (quantityByProduct.ContainsKey(productName))
                {
                    quantityByProduct[productName] += productQuantity;
                    priceByProduct[productName] = productPrice;
                }
                else
                {
                    quantityByProduct.Add(productName, productQuantity);
                    priceByProduct.Add(productName, productPrice);
                }
            }

            foreach (var product in quantityByProduct)
            {
                string productName = product.Key;
                int productQuantity = product.Value;
                double productPrice = priceByProduct[productName];

                Console.WriteLine($"{product.Key} -> {product.Value * productPrice:F2}");
            }
        }
    }
}
