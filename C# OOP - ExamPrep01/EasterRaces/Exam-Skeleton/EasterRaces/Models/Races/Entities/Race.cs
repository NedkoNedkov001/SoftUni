using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Utilities;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Models.Races.Entities
{
    public class Race : IRace
    {
        //Constants
        private const int NameMinLen = 5;
        private const int MinLaps = 1;

        //Fields
        private string name;
        private int laps;
        private readonly IDictionary<string, IDriver> driversByName;

        //Constructor
        public Race(string name, int laps)
        {
            this.Name = name;
            this.Laps = laps;

            this.driversByName = new Dictionary<string, IDriver>();
        }

        //Properties
        public string Name
        {
            get => this.name;
            private set
            {
                Validator.ThrowIfStringIsNullEmptyOrLessThan(
                    value,
                    NameMinLen,
                    string.Format(ExceptionMessages.InvalidName, value, NameMinLen));
                this.name = value;
            }
        }
        public int Laps
        {
            get => this.laps;
            private set
            {
                if (value < MinLaps)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidNumberOfLaps, MinLaps));
                }
                this.laps = value;
            }
        }

        //Methods
        public IReadOnlyCollection<IDriver> Drivers => this.driversByName.Values.ToList();
        public void AddDriver(IDriver driver)
        {
            if (driver == null)
            {
                throw new ArgumentException(ExceptionMessages.DriverInvalid);
            }
            if (!driver.CanParticipate)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriverNotParticipate, driver.Name));
            }
            if (this.driversByName.ContainsKey(driver.Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriverAlreadyAdded, driver.Name, this.Name));
            }

            this.driversByName.Add(driver.Name, driver);
        }
    }
}
