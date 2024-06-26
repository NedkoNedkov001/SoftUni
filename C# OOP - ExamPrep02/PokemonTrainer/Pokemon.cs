﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer
{
    public class Pokemon
    {
        public Pokemon(string name, string element, int health)
        {
            this.Name = name;
            this.Element = element;
            this.Health = health;
        }

        private string name;
        private string element;
        private int health;

        public string Name { get; set; }
        public string Element { get; set; }
        public int Health { get; set; }
    }
}
