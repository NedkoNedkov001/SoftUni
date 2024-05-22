using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public abstract class Animal
    {
        public string Name { get; protected set; }
        public string FavoriteFood { get; protected set; }
        public Animal(string name, string favoriteFood)
        {
            this.Name = name;
            this.FavoriteFood = favoriteFood;
        }
        public virtual string ExplainSelf()
        {
            return $"I am {Name} and my favorite food is {FavoriteFood}";
        }
    }
}
