using System;
using System.Collections.Generic;

namespace SpeedRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int numberOfCars = int.Parse(Console.ReadLine());
            for (int i  = 0; i < numberOfCars; i++)
            {
                string[] newCar = Console.ReadLine().Split();

                string model = newCar[0];
                double fuelAmount = double.Parse(newCar[1]);
                double fuelConsumption = double.Parse(newCar[2]);

                cars.Add(new Car(model, fuelAmount, fuelConsumption));
            }

            while (true)
            {
                string[] input = Console.ReadLine().Split();

                if (input[0] == "End")
                {
                    break;
                }

                if (input[0] == "Drive")
                {
                    string model = input[1];
                    double distance = double.Parse(input[2]);
                    double fuelAmount = cars.Find(n => n.Model == model).FuelAmount;
                    cars.Find(n => n.Model == model).Drive(distance, fuelAmount);
                }

            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
