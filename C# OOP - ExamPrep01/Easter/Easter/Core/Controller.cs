using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Dyes;
using Easter.Models.Eggs;
using Easter.Repositories;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Easter.Models.Workshops;

namespace Easter.Core
{
    public class Controller : IController
    {
        private BunnyRepository bunnies;
        private EggRepository eggs;
        private Workshop workshop;
        private int coloredEggs;

        public Controller()
        {
            this.bunnies = new BunnyRepository();
            this.eggs = new EggRepository();
            this.workshop = new Workshop();
        }

        public string AddBunny(string bunnyType, string bunnyName)
        {
            if (bunnyType == "HappyBunny")
            {
                bunnies.Add(new HappyBunny(bunnyName));

                return string.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);
            }
            else if (bunnyType == "SleepyBunny")
            {
                bunnies.Add(new SleepyBunny(bunnyName));
                return string.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType);
            }
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            if (bunnies.FindByName(bunnyName) == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentBunny);
            }
            bunnies.FindByName(bunnyName).AddDye(new Dye(power));
            return string.Format(OutputMessages.DyeAdded, power, bunnyName);
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            eggs.Add(new Egg(eggName, energyRequired));
            return string.Format(OutputMessages.EggAdded, eggName);
        }

        public string ColorEgg(string eggName)
        {
            if (bunnies.Models.Where(x => x.Energy >= 50) == null)
            {
                throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);
            }

            foreach (var bunny in bunnies.Models
                .OrderByDescending(x => x.Energy)
                .Where(x => x.Energy >= 50))
            {
                workshop.Color(eggs.FindByName(eggName), bunny);

                if (bunny.Energy == 0)
                {
                    bunnies.Remove(bunny);
                }
                if (eggs.FindByName(eggName).IsDone())
                {
                    coloredEggs++;
                    break;
                }
            }
            if (eggs.FindByName(eggName).IsDone())
            {
                return string.Format(OutputMessages.EggIsDone, eggName);
            }
            else
            {
                return string.Format(OutputMessages.EggIsNotDone, eggName);
            }
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{coloredEggs} eggs are done!");
            sb.AppendLine("Bunnies info:");
            foreach (var bunny in bunnies.Models)
            {
                sb.AppendLine($"Name: {bunny.Name}");
                sb.AppendLine($"Energy: {bunny.Energy}");
                sb.AppendLine($"Dyes: {bunny.Dyes.Where(x=>x.Power > 0).ToList().Count} not finished");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
