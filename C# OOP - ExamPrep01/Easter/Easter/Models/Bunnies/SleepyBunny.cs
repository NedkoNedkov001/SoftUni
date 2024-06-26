﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Bunnies
{
    public class SleepyBunny : Bunny
    {
        private const int InitialEnergy = 50;
        private const int AdditionalWorkDecreaseEnergy = 5;

        public SleepyBunny(string name) 
            : base(name, InitialEnergy)
        {
        }

        public override void Work()
        {
            base.Work();
            Energy -= AdditionalWorkDecreaseEnergy;
        }
    }
}
