using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            //Adding people
            List<Person> people = new List<Person>();
            string[] peopleInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < peopleInput.Length; i++)
            {
                string[] currentPerson = peopleInput[i].Split('=', StringSplitOptions.RemoveEmptyEntries);
                string name = currentPerson[0];
                decimal money = decimal.Parse(currentPerson[1]);

                Person person = new Person(name, money);
                people.Add(person);
            }

            //Adding products
            List<Product> products = new List<Product>();
            string[] productsInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < productsInput.Length; i++)
            {
                string[] currentProduct = productsInput[i].Split('=', StringSplitOptions.RemoveEmptyEntries);
                string name = currentProduct[0];
                decimal cost = decimal.Parse(currentProduct[1]);

                Product product = new Product(name, cost);
                products.Add(product);
            }

            //Buying products
            while (true)
            {
                string input = Console.ReadLine();
                
                if (input == "END")
                {
                    break;
                }
                string[] command = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string person = command[0];
                string product = command[1];

                people[0].Buy(product, products);

            }
        }
    }
}
