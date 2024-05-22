using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Tesla : IElectricCar
    {
        public int Battery { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }

        public Tesla(int battery, string model, string color)
        {
            this.Battery = battery;
            this.Model = model;
            this.Color = color;
        }

        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }

        public override string ToString()
        {
            return $"{Color} Tesla {Model} with {Battery} Batteries";
        }
    }
}
