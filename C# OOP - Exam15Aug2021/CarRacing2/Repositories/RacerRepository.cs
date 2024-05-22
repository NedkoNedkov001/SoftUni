using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace CarRacing.Repositories
{
    public class RacerRepository : IRepository<IRacer>
    {
        private List<IRacer> racers;

        public RacerRepository()
        {
            racers = new List<IRacer>();
        }

        public IReadOnlyCollection<IRacer> Models
        {
            get
            {
                return this.racers;
            }
            set
            {
                this.racers = (List<IRacer>)Models;
            }
        }

        public void Add(IRacer model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddRacerRepository);
            }
            racers.Add(model);
        }

        public IRacer FindBy(string property)
        {
            IRacer racer = racers.FirstOrDefault(x => x.Username == property);
            return racer;
        }

        public bool Remove(IRacer model)
        {
            return racers.Remove(model);
        }
    }
}
