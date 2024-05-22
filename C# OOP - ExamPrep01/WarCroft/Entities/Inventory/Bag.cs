using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private int capacity;
        private int load;
        private IList<Item> items;

        protected Bag(int capacity)
        {
            this.Capacity = capacity;
            items = new List<Item>();
            this.Items = new ReadOnlyCollection<Item>(items);
        }

        public int Capacity { get; set; }
        public int Load
        {
            get => this.items.Sum(i => i.Weight);
        }

        public IReadOnlyCollection<Item> Items { get; }

        public void AddItem(Item item)
        {
            if ((this.Load + item.Weight) > this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }
            items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }
            Item desiredItem = items.FirstOrDefault(i => i.GetType().Name == name);
            if (desiredItem == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag, name));
            }
            items.Remove(desiredItem);
            return desiredItem;
        }
    }
}
