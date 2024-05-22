using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {
        //Const
        private const int ModelMinLen = 4;

        //Fields
        private string model;
        private int horsePower;
        private int minHorsePower;
        private int maxHorsePower;

        protected Car(string model, int horsePower, int minHorsePower, int maxHorsePower, double cubicCentimeters)
        {
            Model = model;
            this.minHorsePower = minHorsePower;
            this.maxHorsePower = maxHorsePower;

            HorsePower = horsePower;
            CubicCentimeters = cubicCentimeters;
        }


        //Properties
        public string Model
        {
            get => this.model;
            private set
            {
                Validator.ThrowIfStringIsNullEmptyOrLessThan(
                    value, 
                    ModelMinLen, 
                    string.Format(ExceptionMessages.InvalidModel, value, ModelMinLen));

                this.model = value;
            }
        }

        public int HorsePower
        {
            get => this.horsePower;
            private set
            {
                if (value < this.minHorsePower || value > this.maxHorsePower)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }
                this.horsePower = value;
            }
        }

        public double CubicCentimeters { get; private set; }

        //Methods
        public double CalculateRacePoints(int laps)
        {
            return this.CubicCentimeters / this.horsePower * laps;
        }
    }
}
