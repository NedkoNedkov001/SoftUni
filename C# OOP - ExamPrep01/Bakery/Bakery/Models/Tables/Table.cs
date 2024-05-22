using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        //Fields
        private List<BakedFood> foodOrders;
        private List<Drink> drinkOrders;
        private int tableNumber;
        private int capacity;
        private int numberOfPeople;
        //Ctor
        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
            this.foodOrders = new List<BakedFood>();
            this.drinkOrders = new List<Drink>();
        }
        //Properties
        public int TableNumber { get; private set; }
        public int Capacity
        {
            get => this.capacity;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                }
                this.capacity = value;
            }
        }
        public int NumberOfPeople
        {
            get => this.numberOfPeople;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }
                this.numberOfPeople = value;
            }
        }
        public decimal PricePerPerson { get; private set; }
        public bool IsReserved { get; private set; }
        public decimal Price
        {
            get
            {
                decimal totalPrice = 0;
                totalPrice += this.NumberOfPeople * this.PricePerPerson;
                foreach (var food in foodOrders)
                {
                    totalPrice += food.Price;
                }
                foreach (var drink in drinkOrders)
                {
                    totalPrice += drink.Price;
                }
                return totalPrice;
            }
        }
        //Methods
        public void Clear()
        {
            this.drinkOrders.Clear();
            this.foodOrders.Clear();
            this.numberOfPeople = 0;
            this.IsReserved = false;
        }
        public decimal GetBill()
        {
            return this.Price;
        }
        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Table: {this.TableNumber}");
            //Possible problem with next line
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Capacity: {this.Capacity}");
            sb.AppendLine($"Price per Person: {this.PricePerPerson}");

            return sb.ToString().TrimEnd();
        }
        public void OrderDrink(IDrink drink)
        {
            this.drinkOrders.Add((Drink)drink);
        }
        public void OrderFood(IBakedFood food)
        {
            this.foodOrders.Add((BakedFood)food);
        }
        public void Reserve(int numberOfPeople)
        {
            this.IsReserved = true;
            this.NumberOfPeople = numberOfPeople;
        }
    }
}
