using System;
using NUnit.Framework;

[TestFixture]
public class HeroRepositoryTests
{
    [Test]
    public void TestCtor()
    {
        HeroRepository repository = new HeroRepository();
        Assert.AreEqual(repository.Heroes.Count, 0);
    }
    [Test]
    public void TestGetHeroWithHighestLevel()
    {
        HeroRepository repository = new HeroRepository();
        Hero heroOne = new Hero("Ivan", 23);
        Hero heroTwo = new Hero("Ivanil", 32);
        repository.Create(heroOne);
        repository.Create(heroTwo);
        Assert.AreEqual(repository.GetHeroWithHighestLevel(), heroTwo);
    }
}