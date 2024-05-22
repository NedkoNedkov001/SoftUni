namespace Robots.Tests
{
    using System;
    using NUnit.Framework;


    [TestFixture]
    public class RobotsTests
    {
        [Test]
        public void TestCtorInit()
        {
            Robot robot = new Robot("Ivan", 20);
            Assert.AreEqual(robot.Name, "Ivan");
            Assert.AreEqual(robot.MaximumBattery, 20);
        }
        [Test]
        public void SetCapacityExc()
        {
            Assert.Throws<ArgumentException>(() => new RobotManager(-1));
        }
        [Test]
        public void TestGetCount()
        {
            RobotManager manager = new RobotManager(3);
            Robot robot = new Robot("Ivan", 20);
            Robot robotTwo = new Robot("Pesho", 25);
            manager.Add(robot);
            manager.Add(robotTwo);
            Assert.AreEqual(manager.Count, 2);
        }
        [Test]
        public void AddExistingRobot()
        {
            RobotManager manager = new RobotManager(3);
            Robot robot = new Robot("Ivan", 20);
            manager.Add(robot);
            Assert.Throws<InvalidOperationException>(() => manager.Add(robot));
        }
        [Test]
        public void ExceedCapacity()
        {
            RobotManager manager = new RobotManager(1);
            Robot robot = new Robot("Ivan", 20);
            Robot robotTwo = new Robot("IvanTwo", 22);
            manager.Add(robot);
            Assert.Throws<InvalidOperationException>(() => manager.Add(robotTwo));

        }
        [Test]
        public void AddSucc()
        {
            RobotManager manager = new RobotManager(3);
            Robot robot = new Robot("Ivan", 20);
            manager.Add(robot);
            Assert.AreEqual(manager.Count, 1);
        }
        [Test]
        public void RemoveInvalid()
        {
            RobotManager manager = new RobotManager(3);
            Robot robot = new Robot("Ivan", 20);
            manager.Add(robot);
            Assert.Throws<InvalidOperationException>(() => manager.Remove("Pesho"));
        }
        [Test]
        public void RemoveSucc()
        {
            RobotManager manager = new RobotManager(3);
            Robot robot = new Robot("Ivan", 20);
            manager.Add(robot);
            manager.Remove("Ivan");
            Assert.AreEqual(manager.Count, 0);
        }
        [Test]
        public void WorkInvalid()
        {
            RobotManager manager = new RobotManager(3);
            Robot robot = new Robot("Ivan", 20);
            Assert.Throws<InvalidOperationException>(() => manager.Work("Pesho", "Clean", 10));
        }
        [Test]
        public void WorkWithNoBattery()
        {
            RobotManager manager = new RobotManager(3);
            Robot robot = new Robot("Ivan", 20);
            Assert.Throws<InvalidOperationException>(() => manager.Work("Ivan", "Clean", 21));
        }
        [Test]
        public void WorkSucc()
        {
            RobotManager manager = new RobotManager(3);
            Robot robot = new Robot("Ivan", 20);
            manager.Add(robot);
            manager.Work("Ivan", "Clean", 5);
            Assert.AreEqual(robot.Battery, 15);
        }
        [Test]
        public void ChargeInvalid()
        {
            RobotManager manager = new RobotManager(3);
            Robot robot = new Robot("Ivan", 20);
            manager.Add(robot);
            Assert.Throws<InvalidOperationException>(() => manager.Charge("Pesho"));
        }
        [Test]
        public void ChargeSucc()
        {
            RobotManager manager = new RobotManager(3);
            Robot robot = new Robot("Ivan", 20);
            manager.Add(robot);
            manager.Work("Ivan", "Clean", 5);
            manager.Charge("Ivan");
            Assert.AreEqual(robot.Battery, 20);
        }
    }
}
