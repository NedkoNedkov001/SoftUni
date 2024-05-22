using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    public class Cargo
    {
        public Cargo()
        {

        }
        public Cargo(int cargoWeight, string cargoType)
        {
            this.CargoWeight = cargoWeight;
            this.CargoType = cargoType;
        }

        private int cargoWeight;
        private string cargoType;

        public int CargoWeight { get; set; }
        public string CargoType { get; set; }
    }
}
