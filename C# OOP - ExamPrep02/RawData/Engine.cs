using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    public class Engine
    {
        public Engine()
        {

        }
        public Engine(int engineSpeed, int enginePower)
        {
            this.EngineSpeed = engineSpeed;
            this.EnginePower = enginePower;
        }

        private int engineSpeed;
        private int enginePower;

        public int EngineSpeed { get; set; }
        public int EnginePower { get; set; }
    }
}
