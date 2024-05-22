using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decorations;
        private List<Aquarium> aquariums;

        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new List<Aquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            switch (aquariumType)
            {
                case "FreshwaterAquarium":
                    this.aquariums.Add(new FreshwaterAquarium(aquariumName));
                    break;
                case "SaltwaterAquarium":
                    this.aquariums.Add(new SaltwaterAquarium(aquariumName));
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }
            return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            switch (decorationType)
            {
                case "Ornament":
                    this.decorations.Add(new Ornament());
                    break;
                case "Plant":
                    this.decorations.Add(new Plant());
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }
            return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            var aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);

            switch (fishType)
            {
                case "FreshwaterFish":
                    if (aquarium.GetType().Name == "FreshwaterAquarium")
                    {
                        aquarium.AddFish(new FreshwaterFish(fishName, fishSpecies, price));
                        return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
                    }
                    else
                    {
                        return OutputMessages.UnsuitableWater;
                    }
                case "SaltwaterFish":
                    if (aquarium.GetType().Name == "SaltwaterAquarium")
                    {
                        aquarium.AddFish(new SaltwaterFish(fishName, fishSpecies, price));
                        return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
                    }
                    else
                    {
                        return OutputMessages.UnsuitableWater;
                    }
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

        }

        public string CalculateValue(string aquariumName)
        {
            var aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);

            decimal aquariumValue = aquarium.Decorations.Sum(x => x.Price) + aquarium.Fish.Sum(x => x.Price);

            return string.Format(OutputMessages.AquariumValue, aquariumName, aquariumValue);
        }

        public string FeedFish(string aquariumName)
        {
            var aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);

            aquarium.Feed();
            return $"Fish fed: {aquarium.Fish.Count}";
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var decorationToInsert = decorations.FindByType(decorationType);
            if (decorationToInsert == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }
            decorations.Remove(decorationToInsert);
            var aquariumToInsertDecoration = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);
            aquariumToInsertDecoration.AddDecoration(decorationToInsert);
            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var aquarium in this.aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
