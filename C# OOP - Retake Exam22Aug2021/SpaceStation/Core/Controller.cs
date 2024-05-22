using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Planets;
using SpaceStation.Repositories;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private AstronautRepository astronauts;
        private PlanetRepository planets;
        private Mission mission;
        private int exploredPlanets;

        public Controller()
        {
            this.astronauts = new AstronautRepository();
            this.planets = new PlanetRepository();
            this.mission = new Mission();
        }
        public string AddAstronaut(string type, string astronautName)
        {
            switch (type)
            {
                case "Biologist":
                    astronauts.Add(new Biologist(astronautName));
                    break;
                case "Geodesist":
                    astronauts.Add(new Geodesist(astronautName));
                    break;
                case "Meteorologist":
                    astronauts.Add(new Meteorologist(astronautName));
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }
            return string.Format(OutputMessages.AstronautAdded, type, astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            Planet planet = new Planet(planetName);
            foreach (var item in items)
            {
                planet.Items.Add(item);
            }
            this.planets.Add(planet);
            return string.Format(OutputMessages.PlanetAdded, planetName);

        }

        public string ExplorePlanet(string planetName)
        {
            var planet = this.planets.FindByName(planetName);

            List<IAstronaut> suitableAstronauts = this.astronauts.Models.Where(x => x.Oxygen > 60).ToList();
            if (suitableAstronauts.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }
            this.mission.Explore(planet, suitableAstronauts);
            exploredPlanets++;
            List<IAstronaut> deadAstronauts = suitableAstronauts.Where(x => x.Oxygen == 0).ToList();
            return string.Format(OutputMessages.PlanetExplored, planetName, deadAstronauts.Count);
            
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{exploredPlanets} planets were explored!");
            sb.AppendLine("Astronauts info:");
            foreach (var astronaut in astronauts.Models)
            {
                sb.AppendLine($"Name: {astronaut.Name}");
                sb.AppendLine($"Oxygen: {astronaut.Oxygen}");
                if (astronaut.Bag.Items.Count == 0)
                {
                    sb.AppendLine($"Bag items: none");
                }
                else
                {
                    sb.AppendLine($"Bag items: {string.Join(", ", astronaut.Bag.Items)}");
                }
            }
            return sb.ToString().TrimEnd();

        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astronaut = astronauts.Models.FirstOrDefault(x => x.Name == astronautName);
            if (astronaut == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }
            else
            {
                astronauts.Remove(astronaut);
                return string.Format(OutputMessages.AstronautRetired, astronautName);
            }
        }
    }
}
