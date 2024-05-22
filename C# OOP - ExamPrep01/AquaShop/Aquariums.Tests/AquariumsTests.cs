namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class AquariumsTests
    { 
        [Test]
        public void TestCtor()
        {
            Aquarium aquarium = new Aquarium("Aquarium", 10);
            Assert.AreEqual(aquarium.Count, 0);
        }

        [Test]
        public void TestInvalidNameInit()
        {
            Assert.Throws<ArgumentNullException>(() =>  new Aquarium(null, 1));
            Assert.Throws<ArgumentNullException>(() =>  new Aquarium(string.Empty, 1));
        }
        [Test]
        public void TestInvalidCapacityInit()
        {
            Assert.Throws<ArgumentException>(() => new Aquarium("Aquarium", -1));
        }

        [Test]
        public void TestCount()
        {
            Aquarium aquarium = new Aquarium("Aqua", 10);
            Fish fish = new Fish("Ivan");
            aquarium.Add(fish);
            Assert.AreEqual(aquarium.Count, 1);
        }
        [Test]
        public void TestAddFishInFullAquarium()
        {
            Aquarium testAquarium = new Aquarium("Test", 0);
            Fish testFish = new Fish("Test");
            Assert.Throws<InvalidOperationException>(() => testAquarium.Add(testFish));
        }

        [Test]
        public void TestAddFishSuccessfully()
        {
            Aquarium aquarium = new Aquarium("Aqua", 10);
            Fish fish = new Fish("Nemo");
            Assert.AreEqual(aquarium.Count, 0);
            aquarium.Add(fish);
            Assert.AreEqual(aquarium.Count, 1);
        }

        [Test]
        public void TestRemoveInvalidFish()
        {
            Aquarium aquarium = new Aquarium("Aqua", 10);
            Fish fish = new Fish("Nemo");
            aquarium.Add(fish);
            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish("Goshko"));
        }

        [Test]
        public void TestRemoveFishSuccessfully()
        {
            Aquarium aquarium = new Aquarium("Aqua", 10);
            Fish fish = new Fish("Nemo");
            Assert.AreEqual(aquarium.Count, 0);
            aquarium.Add(fish);
            Assert.AreEqual(aquarium.Count, 1);
            aquarium.RemoveFish("Nemo");
            Assert.AreEqual(aquarium.Count, 0);
        }

        [Test]
        public void TestSellInvalidFish()
        {
            Aquarium aquarium = new Aquarium("Aqua", 10);
            Fish fish = new Fish("Nemo");
            aquarium.Add(fish);
            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish("Ivan"));
        }
        [Test]
        public void TestSellFishSuccessfully()
        {
            Aquarium aquarium = new Aquarium("Aqua", 10);
            Fish fish = new Fish("Nemo");
            aquarium.Add(fish);
            Assert.AreEqual(fish.Available, true);
            aquarium.SellFish("Nemo");
            Assert.AreEqual(fish.Available, false);
        }
        [Test]
        public void TestReport()
        {
            Aquarium aquarium = new Aquarium("Aqua", 10);
            Fish fish = new Fish("Nemo");
            aquarium.Add(fish);
            string expectedResult = "Fish available at Aqua: Nemo";
            Assert.AreEqual(aquarium.Report(), expectedResult);
        }
    }
}
