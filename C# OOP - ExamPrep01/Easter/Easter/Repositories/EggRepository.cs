using Easter.Models.Eggs.Contracts;
using Easter.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Repositories
{
    public class EggRepository : IRepository<IEgg>
    {
        private List<IEgg> eggs;

        public EggRepository()
        {
            eggs = new List<IEgg>();
        }

        public IReadOnlyCollection<IEgg> Models
        {
            get => this.eggs;
            private set
            {
                this.eggs = (List<IEgg>)Models;
            }
        }

        public void Add(IEgg model)
        {
            eggs.Add(model);
        }

        public IEgg FindByName(string name)
        {
            IEgg egg = eggs.FirstOrDefault(x => x.Name == name);
            return egg;
        }

        public bool Remove(IEgg model)
        {
            return eggs.Remove(model);
        }
    }
}
