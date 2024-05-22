using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class SportCar : Car
    {
        public SportCar(int horsePower, double fuel) : base(horsePower, fuel)
        {
        }

        //Override fuel consumption = 10
        public override double FuelConsumption => 10;


    }
}
