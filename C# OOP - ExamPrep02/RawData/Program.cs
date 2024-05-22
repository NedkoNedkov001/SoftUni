using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] currentCar = Console.ReadLine().Split();

                string model = currentCar[0];
                int engineSpeed = int.Parse(currentCar[1]);
                int enginePower = int.Parse(currentCar[2]);
                int cargoWeight = int.Parse(currentCar[3]);
                string cargoType = currentCar[4];
                double tireOnePressure = double.Parse(currentCar[5]);
                int tireOneAge = int.Parse(currentCar[6]);
                double tireTwoPressure = double.Parse(currentCar[7]);
                int tireTwoAge = int.Parse(currentCar[8]);
                double tireThreePressure = double.Parse(currentCar[9]);
                int tireThreeAge = int.Parse(currentCar[10]);
                double tireFourPressure = double.Parse(currentCar[11]);
                int tireFourAge = int.Parse(currentCar[12]);

                cars.Add(new Car(
                    model,
                    new Engine(engineSpeed, enginePower),
                    new Cargo(cargoWeight, cargoType),
                    new Tires[]
                    {
                        new Tires(tireOnePressure, tireOneAge),
                        new Tires(tireTwoPressure, tireTwoAge),
                        new Tires(tireThreePressure, tireThreeAge),
                        new Tires(tireFourPressure, tireFourAge)
                    }));
            }

            string searchCargoType = Console.ReadLine();

            List<Car> orderedCars = cars;
            if (searchCargoType == "fragile")
            {
                orderedCars = orderedCars.
                    Where(x => x.Cargo.CargoType == "fragile").
                    Where(x => x.Tires.Any(t => t.TirePressure < 1)).
                    ToList();
            }
            else if (searchCargoType == "flamable")
            {
                orderedCars = orderedCars.
                    Where(x => x.Cargo.CargoType == "flamable").
                    Where(x => x.Engine.EnginePower > 250)
                    .ToList();
            }

            foreach (var car in orderedCars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
