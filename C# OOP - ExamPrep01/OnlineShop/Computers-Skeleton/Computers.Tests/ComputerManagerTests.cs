using NUnit.Framework;
using System;

namespace Computers.Tests
{
    public class Tests
    {
        [Test]
        public void TestCtor()
        {
            ComputerManager manager = new ComputerManager();
            Assert.AreEqual(manager.Computers.Count, 0);
        }

        [Test]
        public void AddNullComputer()
        {
            ComputerManager manager = new ComputerManager();
            Computer computer = null;
            Assert.Throws<ArgumentNullException>(() => manager.AddComputer(computer));
        }
        [Test]
        public void AddExistingComputer()
        {
            ComputerManager manager = new ComputerManager();
            Computer computer = new Computer("Acer", "Nitro 5", 2100);
            manager.AddComputer(computer);
            Assert.Throws<ArgumentException>(() => manager.AddComputer(computer));
        }
        [Test]
        public void AddComputerSuccessfully()
        {
            ComputerManager manager = new ComputerManager();
            Computer computer = new Computer("Acer", "Nitro 5", 2100);
            manager.AddComputer(computer);
            Assert.AreEqual(manager.Count, 1);
        }
        [Test]
        public void RemoveComputerSuccessfully()
        {
            ComputerManager manager = new ComputerManager();
            Computer computer = new Computer("Acer", "Nitro 5", 2100);
            manager.AddComputer(computer);
            manager.RemoveComputer("Acer", "Nitro 5");
            Assert.AreEqual(manager.Count, 0);
        }
        [Test]
        public void GetNullComputerManufacturer()
        {
            ComputerManager manager = new ComputerManager();
            Assert.Throws<ArgumentNullException>(() => manager.GetComputer(null, "Nitro 5"));
        }
        [Test]
        public void GetNullComputerModel()
        {
            ComputerManager manager = new ComputerManager();
            Assert.Throws<ArgumentNullException>(() => manager.GetComputer("Acer", null));
        }
        [Test]
        public void GetInexistentComputer()
        {
            ComputerManager manager = new ComputerManager();
            Assert.Throws<ArgumentException>(() => manager.GetComputer("Acer", "Nitro 5"));
        
        }
        [Test]
        public void GetComputerSuccessfully()
        {
            ComputerManager manager = new ComputerManager();
            Computer computer = new Computer("Acer", "Nitro 5", 2100);
            manager.AddComputer(computer);
            Assert.AreEqual(manager.GetComputer("Acer", "Nitro 5"), computer);
        }
        [Test]
        public void GetComputersByNullManufacturer()
        {
            ComputerManager manager = new ComputerManager();
            Assert.Throws<ArgumentNullException>(() => manager.GetComputersByManufacturer(null));
        }
        [Test]
        public void GetComputersByManufacturer()
        {
            ComputerManager manager = new ComputerManager();
            Computer computer = new Computer("Acer", "Nitro 5", 2100);
            Computer computerTwo = new Computer("Acer", "Nitro 3", 1500);
            manager.AddComputer(computer);
            manager.AddComputer(computerTwo);
            Assert.AreEqual(manager.GetComputersByManufacturer("Acer").Count, 2);
        }
    }
}