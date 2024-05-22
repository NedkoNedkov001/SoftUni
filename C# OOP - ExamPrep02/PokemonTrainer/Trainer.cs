using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer
{
    public class Trainer
    {
        //Constructors
        public Trainer(string name)
        {
            this.Name = name;
            this.Badges = 0;
            this.Pokemon = new List<Pokemon>();
        }


        //Fields
        private string name;
        private int badges;
        private List<Pokemon> pokemon;


        //Properties
        public string Name { get; set; }
        public int Badges { get; set; }
        public List<Pokemon> Pokemon { get; set; }

    }
}
