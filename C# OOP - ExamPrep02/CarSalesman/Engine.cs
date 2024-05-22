using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    public class Engine
    {
        //Constructors
        public Engine(string model, int power, int displacement, string efficiency)
            : this()
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = displacement;
            this.Efficiency = efficiency;
        }
        public Engine(string model, int power, int displacement)
            : this()
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = displacement;
        }
        public Engine(string model, int power, string efficiency)
            : this()
        {
            this.Model = model;
            this.Power = power;
            this.Efficiency = efficiency;
        }
        public Engine(string model, int power)
            : this()
        {
            this.Model = model;
            this.Power = power;
        }
        public Engine()
        {
            this.Displacement = 0;
            this.Efficiency = null;
        }


        //Fields
        private string model;
        private int power;
        private int displacement;
        private string efficiency;


        //Properties
        public string Model { get; set; }
        public int Power { get; set; }
        public int Displacement { get; set; }
        public string Efficiency { get; set; }

    }
}
