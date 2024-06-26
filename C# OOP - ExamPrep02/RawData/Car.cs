﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    public class Car
    {
        public Car()
        {

        }
        public Car(string model, Engine engine, Cargo cargo, Tires[] tires)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tires = tires;
        }


        private string model;
        private Engine engine;
        private Cargo cargo;
        private Tires[] tires;

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public Tires[] Tires { get; set; }

        public override string ToString()
        {
            return this.Model;
        }
    }
}
