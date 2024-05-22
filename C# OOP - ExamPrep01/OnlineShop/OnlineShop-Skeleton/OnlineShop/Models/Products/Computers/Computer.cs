using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private List<IComponent> components;
        private List<IPeripheral> peripherals;
        private double overallPerformance;
        private decimal price;

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components { get => this.components; }

        public IReadOnlyCollection<IPeripheral> Peripherals { get => this.peripherals; }

        public void AddComponent(IComponent component)
        {
            if (components.Contains(component))
            {
                string componentType = component.GetType().Name;
                string computerType = this.GetType().Name;
                int id = components[components.IndexOf(component)].Id;

                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComponent, componentType, computerType, id));
            }
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            throw new NotImplementedException();
        }

        public IComponent RemoveComponent(string componentType)
        {
            throw new NotImplementedException();
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($"Components ({this.components.Count})");
            foreach (var component in components)
            {
                sb.AppendLine(component.ToString());
            }
            sb.AppendLine($"Peripherals ({peripherals.Count}); Average Overall Performance ():");
            foreach (var peripheral in peripherals)
            {
                sb.AppendLine(peripheral.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
