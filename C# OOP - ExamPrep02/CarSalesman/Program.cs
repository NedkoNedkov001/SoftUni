using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Fill Engines

            List<Engine> engines = new List<Engine>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                FillEngines(engines);

            }

            //Fill Cars
            List<Car> cars = new List<Car>();
            int m = int.Parse(Console.ReadLine());
            for (int i = 0; i < m; i++)
            {
                FillCars(engines, cars);

            }

            //Print Cars
            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }

        private static void FillCars(List<Engine> engines, List<Car> cars)
        {
            string[] currentCar = Console.ReadLine().Split();
            string model = currentCar[0];
            Engine engine = engines.Find(e => e.Model == currentCar[1]);
            if (currentCar.Length == 2)
            {
                cars.Add(new Car(model, engine));
            }
            //3 parameters
            else if (currentCar.Length == 3)
            {
                if (IsDigit(currentCar[2]))
                {
                    int weight = int.Parse(currentCar[2]);
                    cars.Add(new Car(model, engine, weight));
                }
                else
                {
                    string color = currentCar[2];
                    cars.Add(new Car(model, engine, color));
                }
            }

            //4 parameters
            else if (currentCar.Length == 4)
            {
                int weight;
                string color;

                if (IsDigit(currentCar[2]))
                {
                    weight = int.Parse(currentCar[2]);
                    color = currentCar[3];
                }
                else
                {
                    weight = int.Parse(currentCar[3]);
                    color = currentCar[2];
                }

                
                cars.Add(new Car(model, engine, weight, color));
            }
        }

        private static void FillEngines(List<Engine> engines)
        {
            string[] currentEngine = Console.ReadLine().Split();
            string model = currentEngine[0];
            int power = int.Parse(currentEngine[1]);
            if (currentEngine.Length == 2)
            {
                engines.Add(new Engine(model, power));
            }

            //3 parameters
            else if (currentEngine.Length == 3)
            {
                if (IsDigit(currentEngine[2]))
                {
                    int displacement = int.Parse(currentEngine[2]);
                    engines.Add(new Engine(model, power, displacement));
                }
                else
                {
                    string efficiency = currentEngine[2];
                    engines.Add(new Engine(model, power, efficiency));
                }

            }

            //4 paramaters
            else if (currentEngine.Length == 4)
            {
                int displacement;
                string efficiency;

                if (IsDigit(currentEngine[2]))
                {
                    displacement = int.Parse(currentEngine[2]);
                    efficiency = currentEngine[3];
                }
                else
                {
                    displacement = int.Parse(currentEngine[3]);
                    efficiency = currentEngine[2];
                }

                engines.Add(new Engine(model, power, displacement, efficiency));
            }
        }

        private static bool IsDigit(string v)
        {
            bool isDigit = int.TryParse(v, out int displacement);

            return isDigit;
        }
    }
}
