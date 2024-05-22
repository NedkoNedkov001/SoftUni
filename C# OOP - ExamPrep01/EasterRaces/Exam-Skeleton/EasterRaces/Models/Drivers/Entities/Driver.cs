using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Utilities;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Drivers.Entities
{
    public class Driver : IDriver
    {
        //Const
        private const int NameMinLen = 5;

        //Fields
        private string name;

        //Constructor
        public Driver(string name)
        {
            this.Name = name;
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

        public ICar Car { get; private set; }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate => this.Car != null;


        //Methods
        public void AddCar(ICar car)
        {
            if (car == null)
            {
                throw new ArgumentException(ExceptionMessages.CarInvalid);
            }
            this.Car = car;
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }
    }
}
