using System;

namespace Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());

            CalculatePrice(product, quantity);
        }

        static void CalculatePrice(string product, int quantity)
        {
            double totalPrice = 0;
            switch (product)
            {
                case "coffee":
                    totalPrice += 1.5;
                    break;
                case "water":
                    totalPrice += 1;
                    break;
                case "coke":
                    totalPrice += 1.4;
                    break;
                case "snacks":
                    totalPrice += 2;
                    break;
            }
            totalPrice *= quantity;
            Console.WriteLine($"{totalPrice:F2}");
        }
    }
}
