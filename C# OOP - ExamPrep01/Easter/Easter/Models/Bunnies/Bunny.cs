﻿using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Bunnies
{
    public abstract class Bunny : IBunny

    {
        private string name;
        private int energy;

        public Bunny(string name, int energy)
        {
            this.Name = name;
            this.Energy = energy;
            this.Dyes = new List<IDye>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBunnyName);
                }
                this.name = value;
            }
        }

        public int Energy
        {
            get => this.energy;
            protected set
            {
                if (value < 0)
                {
                    this.energy = 0;
                }
                this.energy = value;
            }
        }

        public ICollection<IDye> Dyes { get; private set; }

        public void AddDye(IDye dye)
        {
            this.Dyes.Add(dye);
        }
        public virtual void Work()
        {
            this.Energy -= 10;
        }
    }
}
