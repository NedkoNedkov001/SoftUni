using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Interfaces
{
    public interface ISoldier
    {
        public int ID { get; }

        public string FirstName { get; }

        public string LastName { get; }
    }
}
