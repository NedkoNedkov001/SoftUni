using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        private const double InitialOxygen = 70;
        private const int OxygenReduction = 5;
        public Biologist(string name)
            : base(name, InitialOxygen)
        {
        }
        public override void Breath()
        {
            this.Oxygen -= OxygenReduction;
            if (this.Oxygen < 0)
            {
                this.Oxygen = 0;
            }
        }
    }
}
