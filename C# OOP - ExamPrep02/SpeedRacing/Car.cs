using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
    class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumption)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumption = fuelConsumption;
            this.TravelledDistance = 0;
        }
        private string model;
        private double fuelAmount;
        private double fuelConsumption;
        private double travelledDistance;

        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumption { get; set; }
        public double TravelledDistance { get; set; }

        public void Drive(double distance, double fuelAmount)
        {
            double fuelNeeded = FuelConsumption * distance;
            if (fuelAmount - fuelNeeded >= 0)
            {
                this.FuelAmount -= fuelNeeded;
                this.TravelledDistance += distance;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

        public override string ToString()
        {
            return $"{this.Model} {this.FuelAmount:F2} {this.TravelledDistance}";
        }
    }
}
