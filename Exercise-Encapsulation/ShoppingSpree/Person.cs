using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<string> products;
        public string Name
        {
            get => this.name;
            private set
            {
                if (value == "" ||
                    value == " " ||
                    value == null)
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name = value;
            }
        }
        public decimal Money
        {
            get => this.money;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.money = value;
            }
        }
        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.products = new List<Product>();
        }
        public void Buy(string product, List<Product> products)
        {
            if (this.Money >= products[0].Cost)
                if (this.Money >= product[products.Find(x => x.Name = product)])
            {
                this.products.Add(product);
            }
            else
            {
                Console.WriteLine($"{this.Name} can't afford {product}");
            }
        }
    }
}
