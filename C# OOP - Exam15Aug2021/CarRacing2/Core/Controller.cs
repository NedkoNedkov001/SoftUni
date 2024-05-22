using CarRacing.Core.Contracts;
using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Maps;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Core
{
    public class Controller : IController
    {
        private CarRepository carRepository;
        private RacerRepository racerRepository;
        private Map map;

        public Controller()
        {
            this.carRepository = new CarRepository();
            this.racerRepository = new RacerRepository();
            this.map = new Map();
        }

        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            if (type != "SuperCar" && type != "TunedCar")
            {
                throw new ArgumentException(ExceptionMessages.InvalidCarType);
            }
            ICar car = null;
            if (type == nameof(SuperCar))
            {
                car = new SuperCar(make, model, VIN, horsePower);
            }
            if (type == nameof(TunedCar))
            {
                car = new TunedCar(make, model, VIN, horsePower);
            }

            carRepository.Add(car);
            return string.Format(OutputMessages.SuccessfullyAddedCar, make, model, VIN);
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            if (type != "ProfessionalRacer" && type != "StreetRacer")
            {
                throw new ArgumentException(ExceptionMessages.InvalidRacerType);
            }
            if (carRepository.FindBy(carVIN) == null)
            {
                throw new ArgumentException(ExceptionMessages.CarCannotBeFound);
            }

            IRacer racer = null;
            if (type == nameof(ProfessionalRacer))
            {
                racer = new ProfessionalRacer(username, carRepository.FindBy(carVIN));
            }
            if (type == nameof(StreetRacer))
            {
                racer = new StreetRacer(username, carRepository.FindBy(carVIN));
            }

            racerRepository.Add(racer);
            return string.Format(OutputMessages.SuccessfullyAddedRacer, username);
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            if (racerRepository.FindBy(racerOneUsername) == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerOneUsername));
            }
            if (racerRepository.FindBy(racerTwoUsername) == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerTwoUsername));
            }
            return map.StartRace(racerRepository.FindBy(racerOneUsername), racerRepository.FindBy(racerTwoUsername));
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (IRacer racer in racerRepository.Models
                .OrderByDescending(x => x.DrivingExperience)
                .ThenBy(x => x.Username)
                .ToList())
            {
                sb.AppendLine($"{racer.GetType().Name}: {racer.Username}");
                sb.AppendLine($"--Driving behavior: {racer.RacingBehavior}");
                sb.AppendLine($"--Driving experience: {racer.DrivingExperience}");
                sb.AppendLine($"--Car: {racer.Car.Make} {racer.Car.Model} ({racer.Car.VIN})");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
