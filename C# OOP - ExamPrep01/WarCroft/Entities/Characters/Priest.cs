using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Priest : Character, IHealer
    {
        private const double BaseHeatlh = 50;
        private const double BaseArmor = 25;
        private const double InitAbilityPoints = 40;

        public Priest(string name) 
            : base(name, BaseHeatlh, BaseArmor, InitAbilityPoints, new Backpack())
        {
        }

        public void Heal(Character character)
        {
            this.EnsureAlive();
            character.EnsureAlive();
            character.Health += this.AbilityPoints;
        }
    }
}
