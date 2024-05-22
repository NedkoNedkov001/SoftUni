using System;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double coin = 0;
            double coinsSum = 0;

            while (input != "Start")
            {

                coin = double.Parse(input);
                if (coin == 0.1 || coin == 0.2 || coin == 0.5 || coin == 1 || coin == 2)
                {
                    coinsSum += coin;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {coin}");
                }
                input = Console.ReadLine();
            }
            input = Console.ReadLine();
            while (input != "End")
            {
                if (input != "Nuts" && input != "Water" && input != "Crisps" && input != "Soda" && input != "Coke")
                {
                    Console.WriteLine("Invalid product");
                }
                else if (input == "Nuts" && coinsSum >= 2)
                {
                    Console.WriteLine("Purchased nuts");
                    coinsSum -= 2;
                }
                else if (input == "Water" && coinsSum >= 0.7)
                {
                    Console.WriteLine("Purchased water");
                    coinsSum -= 0.7;
                }
                else if (input == "Crisps" && coinsSum >= 1.5)
                {
                    Console.WriteLine("Purchased crisps");
                    coinsSum -= 1.5;
                }
                else if (input == "Soda" && coinsSum >= 0.8)
                {
                    Console.WriteLine("Purchased soda");
                    coinsSum -= 0.8;
                }
                else if (input == "Coke" && coinsSum >= 1)
                {
                    Console.WriteLine("Purchased coke");
                    coinsSum -= 1;
                }
                else
                {
                    Console.WriteLine("Sorry, not enough money");
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Change: {coinsSum:F2}");
        }
    }
}
