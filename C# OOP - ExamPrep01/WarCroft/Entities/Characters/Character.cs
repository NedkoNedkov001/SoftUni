using System;
using System.Linq;
using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        // TODO: Implement the rest of the class.

        //Potential problem with "double" instead of "float" for fields and properties
        private string name;
        private double baseHealth;
        private double health;
        private double baseArmor;
        private double armor;
        private double abilityPoints;

        public Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.Health = health;
            this.BaseArmor = armor;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
        }


        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }
                this.name = value;
            }
        }
        public double BaseHealth
        {
            get => this.baseHealth;
            private set => this.baseHealth = value;
        }
        public double Health
        {
            get => this.health;
            set
            {
                if (value > BaseHealth)
                {
                    this.health = BaseHealth;
                }
                if (value <= 0)
                {
                    this.health = 0;
                    IsAlive = false;
                }
                this.health = value;
            }
        }
        public double BaseArmor
        {
            get => this.baseArmor;
            private set => this.baseArmor = value;
        }
        public double Armor
        {
            get => this.armor;
            set
            {
                if (value < 0)
                {
                    this.armor = 0;
                }
                this.armor = value;
            }
        }
        public double AbilityPoints
        {
            get => this.abilityPoints;
            private set => this.abilityPoints = value;
        }
        public Bag Bag { get; set; }
        public bool IsAlive { get; set; } = true;
        public void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }
        public void TakeDamage(double hitPoints)
        {
            this.EnsureAlive();

            if (this.Armor >= hitPoints)
            {
                this.Armor -= hitPoints;
                hitPoints = 0;
            }
            else
            {
                hitPoints -= this.Armor;
                this.Armor = 0;
                this.Health = this.Health - hitPoints;
                if (this.Health < 0)
                {
                    this.Health = 0;
                }
                hitPoints = 0;
            }
        }
        public void UseItem(Item item)
        {
            this.EnsureAlive();

            //Item itemExists = this.Bag.Items.FirstOrDefault(x => x == item);
            //if (itemExists == null)
            //{
            //    throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag, item.GetType().Name);
            //}
            item.AffectCharacter(this);
        }
    }
}