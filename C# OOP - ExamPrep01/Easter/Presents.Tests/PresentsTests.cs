namespace Presents.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Collections.Generic;

    [TestFixture]
    public class PresentsTests
    {
        [Test]
        public void TestCtor()
        {
            Bag bag = new Bag();
        }
        [Test]
        public void CreateNull()
        {
            Bag bag = new Bag();
            Present present = null;
            Assert.Throws<ArgumentNullException>(() => bag.Create(present));
        }
        [Test]
        public void CreateExist()
        {
            Bag bag = new Bag();
            Present present = new Present("Toy", 0.1);
            bag.Create(present);
            Assert.Throws<InvalidOperationException>(() => bag.Create(present));

        }
        [Test]
        public void CreateSuccess()
        {
            Bag bag = new Bag();
            Present present = new Present("Toy", 0.1);
            string expectedResult = "Successfully added present Toy.";
            Assert.That(bag.Create(present), Is.EqualTo(expectedResult));
        }
        [Test]
        public void RemoveSuccess()
        {
            Type myType = typeof(Bag);
            FieldInfo field = myType.GetField("presents");

            Bag bag = new Bag();
            Present present = new Present("Toy", 0.1);
            bag.Create(present);
            bag.Remove(present);
            List<Present> presents = new List<Present>();
            Assert.That(bag.GetPresents(), Is.EqualTo(presents));
        }
        [Test]
        public void GetPresentWithLeastMagic()
        {
            Bag bag = new Bag();
            Present present = new Present("Toy", 0.1);
            Present present1 = new Present("Unicorn", 1000);
            bag.Create(present);
            bag.Create(present1);
            Assert.That(bag.GetPresentWithLeastMagic(), Is.EqualTo(present));
        }
        [Test]
        public void GetPresent()
        {
            Bag bag = new Bag();
            Present present = new Present("Toy", 0.1);
            Present present1 = new Present("Unicorn", 1000);
            bag.Create(present);
            bag.Create(present1);
            Assert.That(bag.GetPresent("Toy"), Is.EqualTo(present));
        }
        [Test]
        public void GetAllPresents()
        {
            Bag bag = new Bag();
            Present present = new Present("Toy", 0.1);
            Present presentTwo = new Present("Unicorn", 100);
            bag.Create(present);
            bag.Create(presentTwo);

            List<Present> presents = new List<Present> { present, presentTwo };
            Assert.That(bag.GetPresents(), Is.EqualTo(presents));
        }
    }
}
