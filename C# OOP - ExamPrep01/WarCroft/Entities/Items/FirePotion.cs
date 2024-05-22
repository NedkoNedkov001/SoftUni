using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    public class FirePotion : Item
    {
        private const int FirePotionWeight = 5;
        public FirePotion() 
            : base(FirePotionWeight)
        {
        }
        public override void AffectCharacter(Character character)
        {
            character.EnsureAlive();
                character.Health -= 20;
            
        }
    }
}
