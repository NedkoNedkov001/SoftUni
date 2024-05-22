using ValidationAttributes.CustomAttributes;

namespace ValidationAttributes
{
    internal class Person
    {

        [MyRequired]
        public string Name { get; set; }

        [MyRange(12,90)]
        public int Age { get; set; }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
    }
}