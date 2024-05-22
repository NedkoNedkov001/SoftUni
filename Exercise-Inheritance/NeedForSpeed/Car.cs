using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        public Car(int horsePower, double fuel) : base(horsePower, fuel)
        {
        }

        //Override fuel consumption = 3
        public override double FuelConsumption => 3;

    }
}
