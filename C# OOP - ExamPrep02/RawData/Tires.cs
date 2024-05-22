using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    public class Tires
    {
        public Tires()
        {

        }
        public Tires(double tirePressure, int tireAge)
        {
            this.TirePressure = tirePressure;
            this.TireAge = tireAge;
        }

        private double tirePressure;
        private int tireAge;

        public double TirePressure { get; set; }
        public int TireAge { get; set; }
    }
}
