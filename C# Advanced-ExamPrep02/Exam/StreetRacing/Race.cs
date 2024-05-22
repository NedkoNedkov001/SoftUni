using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            this.Participants = new List<Car>();
            this.Name = name;
            this.Type = type;
            this.Laps = laps;
            this.Capacity = capacity;
            this.MaxHorsePower = maxHorsePower;
        }
        public List<Car> Participants { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }

        public int Count()
        {
            return this.Participants.Count();
        }

        public void Add(Car car)
        {
            string currLicensePlate = car.LicensePlate;
            Car carWithSameLicensePlate = this.Participants.FirstOrDefault(x => x.LicensePlate == currLicensePlate);
            if (carWithSameLicensePlate == null &&
                this.Participants.Count < this.Capacity &&
                car.HorsePower <= this.MaxHorsePower)
            {
                this.Participants.Add(car);
            }
        }
        public bool Remove(string licensePlate)
        {
            Car carToRemove = this.Participants.FirstOrDefault(x => x.LicensePlate == licensePlate);
            return this.Participants.Remove(carToRemove);
        }

        public Car FindParticipant(string licensePlate)
        {
            Car car = this.Participants.FirstOrDefault(x => x.LicensePlate == licensePlate);
            return car;
        }

        public Car GetMostPowerfulCar()
        {
            Car mostPowerfulCar =  this.Participants.OrderByDescending(x => x.HorsePower).FirstOrDefault();
            return mostPowerfulCar;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Race: {this.Name} - Type: {this.Type} (Laps: {this.Laps})");
            foreach (var car in this.Participants)
            {
                sb.AppendLine(car.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
