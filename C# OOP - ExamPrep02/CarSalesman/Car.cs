using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    public class Car
    {

        //Constructors
        public Car(string model, Engine engine, int weight, string color)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = weight;
            this.Color = color;
        }
        public Car(string model, Engine engine, int weight)
            : this()
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = weight;
        }
        public Car(string model, Engine engine, string color)
            : this()
        {
            this.Model = model;
            this.Engine = engine;
            this.Color = color;
        }
        public Car(string model, Engine engine)
            : this()
        {
            this.Model = model;
            this.Engine = engine;
        }
        public Car()
        {
            this.Weight = 0;
            this.Color = "n/a";
        }

        //Fields
        private string model;
        private Engine engine;
        private int weight;
        private string color;

        //Properties
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.Model}:");
            sb.AppendLine($"  {this.Engine.Model}:");
            sb.AppendLine($"    Power: {this.Engine.Power}");
            sb.AppendLine(this.Engine.Displacement == 0 ? "    Displacement: n/a" : $"    Displacement: {this.Engine.Displacement}");
            sb.AppendLine(string.IsNullOrEmpty(this.Engine.Efficiency) ? "    Efficiency: n/a" : $"    Efficiency: {this.Engine.Efficiency}");
            sb.AppendLine(this.Weight == 0 ? "  Weight: n/a" : $"  Weight: {this.Weight}");
            sb.AppendLine($"  Color: {this.Color}");

            return sb.ToString().TrimEnd();
        }   
    }
}
