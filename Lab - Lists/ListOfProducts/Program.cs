using System;
using System.Collections.Generic;

namespace ListOfProducts
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> products = new List<string>(n);

            for (int i = 0; i < products.Capacity; i++)
            {
                products.Add(Console.ReadLine());
            }

            products.Sort();
            for (int i = 1; i <= products.Count; i++)
            {
                Console.WriteLine($"{i}.{products[i-1]}");
            }
        }
    }
}
