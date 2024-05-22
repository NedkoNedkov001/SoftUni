using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products.Peripherals
{
    public abstract class Peripheral : Product, IPeripheral
    {
        protected Peripheral(int id, string manufacturer, string model, decimal price, double overallPerformance, string connectionType) 
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.ConnectionType = connectionType;
        }
        public string ConnectionType { get; private set; }

        public override string ToString()
        {
            //Potential problem (Might have to replace base.ToString() with the actual message
            return base.ToString() + $" Connection Type: {ConnectionType}";
        }
    }
}
