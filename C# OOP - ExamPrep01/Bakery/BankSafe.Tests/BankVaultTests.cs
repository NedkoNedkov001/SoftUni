using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        [Test]
        public void TestCtor()
        {
            BankVault vault = new BankVault();
            Assert.AreEqual(vault.VaultCells.Count, 12);
        }

        [Test]
        public void AddInInexistentCell()
        {
            BankVault vault = new BankVault();
            Item item = new Item("Ivan", "01");

            Assert.Throws<ArgumentException>(() => vault.AddItem("R3", item));
        }

        [Test]
        public void AddInTakenCell()
        {
            BankVault vault = new BankVault();
            Item item = new Item("Ivan", "01");
            Item item2 = new Item("Pesho", "02");
            vault.AddItem("A3", item);
            Assert.Throws<ArgumentException>(() => vault.AddItem("A3", item2));
        }
        [Test]
        public void ItemAlreadyInCell()
        {
            BankVault vault = new BankVault();
            Item item = new Item("Ivan", "01");
            vault.AddItem("A1", item);
            Assert.Throws<InvalidOperationException>(() => vault.AddItem("A2", item));
        }
        [Test]
        public void ItemAddedSuccessfully()
        {
            BankVault vault = new BankVault();
            Item item = new Item("Ivan", "01");
            string expectedResult = "Item:01 saved successfully!";
            Assert.That(vault.AddItem("A1", item), Is.EqualTo(expectedResult));
        }
        [Test]
        public void RemoveFromInexistentCell()
        {
            BankVault vault = new BankVault();
            Item item = new Item("Ivan", "01");
            Assert.Throws<ArgumentException>(() => vault.RemoveItem("R3", item));
        }
        [Test]
        public void RemoveWrongItem()
        {
            BankVault vault = new BankVault();
            Item item = new Item("Ivan", "01");
            vault.AddItem("A1", item);
            Item item2 = new Item("Pesho", "02");
            Assert.Throws<ArgumentException>(() => vault.RemoveItem("A1", item2));
        }
        [Test]
        public void RemoveSuccessfully()
        {
            BankVault vault = new BankVault();
            Item item = new Item("Ivan", "01");
            vault.AddItem("A1", item);
            string expectedResult = "Remove item:01 successfully!";
            Assert.That(vault.RemoveItem("A1", item), Is.EqualTo(expectedResult));
        }
    }
}