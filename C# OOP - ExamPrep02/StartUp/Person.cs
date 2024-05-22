using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Person
    {
        public Person()
        {
            this.Name = "No name";
            this.Age = 1;
        }

        public Person(int age)
            : this()
        {
            this.Age = age;
        }

        public Person(string name, int age)
            : this()
        {
            this.Name = name;
            this.Age = age;
        }



        private string name;
        private int age;

        

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int Age
        {
            get => this.age;
            set => this.age = value;
        }

        public override string ToString()
        {
            return $"{Name} - {Age}";
        }

    }
}
