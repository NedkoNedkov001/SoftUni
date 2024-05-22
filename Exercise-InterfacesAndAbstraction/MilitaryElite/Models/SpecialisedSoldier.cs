using MilitaryElite.Enumerations;
using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        protected SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, SoldierCorpEnum corp) 
            : base(id, firstName, lastName, salary)
        {
            this.Corp = corp;
        }

        public SoldierCorpEnum Corp { get; }

        public override string ToString()
        {
            return (base.ToString());
        }
    }
}
