using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.Drinks;
using Bakery.Models.Tables;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private List<BakedFood> bakedFoods;
        private List<Drink> drinks;
        private List<Table> tables;
        private decimal totalIncome;

        public Controller()
        {
            this.bakedFoods = new List<BakedFood>();
            this.drinks = new List<Drink>();
            this.tables = new List<Table>();
            this.totalIncome = 0;
        }
        public string AddDrink(string type, string name, int portion, string brand)
        {
            if (type == "Water")
            {
                drinks.Add(new Water(name, portion, brand));
            }
            if (type == "Tea")
            {
                drinks.Add(new Tea(name, portion, brand));
            }
            //
            //Possible wrong type
            //
            return string.Format(OutputMessages.DrinkAdded, name, brand);
        }

        public string AddFood(string type, string name, decimal price)
        {
            if (type == "Bread")
            {
                bakedFoods.Add(new Bread(name, price));
            }
            else if (type == "Cake")
            {
                bakedFoods.Add(new Cake(name, price));
            }
            //
            //Possible wrong type
            //
            return string.Format(OutputMessages.FoodAdded, name, type);
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            if (type == "InsideTable")
            {
                tables.Add(new InsideTable(tableNumber, capacity));
            }
            else if (type == "OutsideTable")
            {
                tables.Add(new OutsideTable(tableNumber, capacity));
            }
            //
            //Possible wrong type
            //
            return string.Format(OutputMessages.TableAdded, tableNumber);
        }

        public string GetFreeTablesInfo()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Table table in tables.Where(x => x.IsReserved==false))
            {
                sb.AppendLine(table.GetFreeTableInfo());
            }
            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            return $"Total income: {totalIncome:F2}lv";
        }

        public string LeaveTable(int tableNumber)
        {
            Table table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            decimal tableProfit = table.GetBill();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {tableNumber}");
            sb.AppendLine($"Bill: {tableProfit:F2}");

            totalIncome += tableProfit;
            table.Clear();

            return sb.ToString().TrimEnd();
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            Table table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            if (table == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }
            //
            //Possible issue with the predicate
            //
            Drink drink = drinks.FirstOrDefault(x => x.Name == drinkName & x.Brand == drinkBrand);
            if (drink == null)
            {
                return string.Format(OutputMessages.NonExistentDrink, drinkName, drinkBrand);
            }
            table.OrderDrink(drink);
            return string.Format(OutputMessages.DrinkOrderSuccessful, tableNumber, drinkName, drinkBrand);
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            Table table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            if (table == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            BakedFood food = bakedFoods.FirstOrDefault(x => x.Name == foodName);
            if (food == null)
            {
                return string.Format(OutputMessages.NonExistentFood, foodName);
            }
            table.OrderFood(food);
            return string.Format(OutputMessages.FoodOrderSuccessful, tableNumber, foodName);

        }

        public string ReserveTable(int numberOfPeople)
        {
            foreach (var table in tables.Where(x => x.IsReserved == false))
            {
                if (table.Capacity >= numberOfPeople)
                {
                    table.Reserve(numberOfPeople);
                    return string.Format(OutputMessages.TableReserved,table.TableNumber,numberOfPeople);
                }
            }
            return string.Format(OutputMessages.ReservationNotPossible, numberOfPeople);
        }
    }
}
