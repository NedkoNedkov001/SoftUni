using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (var astronaut in astronauts)
            {
                if (astronaut.Oxygen > 0)
                {
                    List<string> takenItems = new List<string>();
                    foreach (var item in planet.Items)
                    {
                        takenItems.Add(item);
                        astronaut.Breath();
                        if (takenItems.Count == planet.Items.Count)
                        {
                            break;
                        }
                        if (astronaut.Oxygen == 0)
                        {
                            break;
                        }
                    }
                    foreach (var item in takenItems)
                    {
                        astronaut.Bag.Items.Add(item);
                        planet.Items.Remove(item);
                    }
                    takenItems.Clear();
                }
            }
        }
    }
}
