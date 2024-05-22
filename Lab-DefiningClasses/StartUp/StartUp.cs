using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            //Fill tires 
            List<List<Tire>> tires = new List<List<Tire>>();
            int tireIndex = 0;
            while (true)
            {
                string input = Console.ReadLine();
                string[] values = input.Split();

                if (input == "No more tires")
                {
                    break;
                }

                tires.Add(new List<Tire>());

                for (int i = 0; i < values.Length; i += 2)
                {
                    int year = int.Parse(values[i]);
                    double pressure = double.Parse(values[i + 1]);

                    tires[tireIndex].Add(new Tire(year, pressure));
                }
                tireIndex++;
            }


            //Fill engines
            List<Engine> engines = new List<Engine>();
            while (true)
            {
                string input = Console.ReadLine();
                string[] values = input.Split();
                if (input == "Engines done")
                {
                    break;
                }
                for (int i = 0; i < values.Length; i += 2)
                {
                    engines.Add(new Engine(int.Parse(values[i]), double.Parse(values[i + 1])));
                }


            }

            //Fill cars
            List<Car> cars = new List<Car>();
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Show special")
                {
                    break;
                }

                string[] currentCar = input.Split();

                string make = currentCar[0];
                string model = currentCar[1];
                int year = int.Parse(currentCar[2]);
                double fuelQuantity = double.Parse(currentCar[3]);
                double fuelConsuption = double.Parse(currentCar[4]);
                int engineIndex = int.Parse(currentCar[5]);
                int tiresIndex = int.Parse(currentCar[6]);

                cars.Add(new Car(make, model, year, fuelQuantity, fuelConsuption, engines[engineIndex], tires[tiresIndex]));
            }


            //Show specials
            foreach (var car in cars)
            {
                car.Drive(20, car.FuelConsumption);
            }

            List<Car> specialCars = cars
                .Where(c => c.Year >= 2017)
                .Where(e => e.Engine.HorsePower > 330)
                .Where(t => t.TiresTotalPressure() > 9)
                .Where(t => t.TiresTotalPressure() < 10)
                .ToList();

            foreach (var car in specialCars)
            {
                Console.WriteLine(car.WhoAmI());
            }
        }
    }
}
