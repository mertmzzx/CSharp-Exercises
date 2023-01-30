using NUnit.Framework;
using System;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            [Test]
            public void WeaponConstructorWorksCorrectly()
            {
                Weapon weapon = new Weapon("Deagle", 100, 5);

                Assert.AreEqual("Deagle", weapon.Name);
                Assert.AreEqual(100, weapon.Price);
                Assert.AreEqual(5, weapon.DestructionLevel);
            }

            [TestCase(-5)]
            [TestCase(-1)]
            public void WeaponPricePropertyShouldThrowExceptionWhenValueIsLessThanZero(double price)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Weapon weapon = new Weapon("Deagle", price, 5);
                }, "Price value must be greater than zero!");
            }

            [Test]
            public void WeaponIncreaseDestructionLevelMethodShouldIncreaseCorrectly()
            {
                Weapon weapon = new Weapon("Deagle", 100, 5);

                weapon.IncreaseDestructionLevel();

                Assert.AreEqual(6, weapon.DestructionLevel);
            }

            [Test]
            public void WeaponIsNuclear()
            {
                Weapon weapon = new Weapon("Nuclear Bomb", 100, 12);

                Assert.AreEqual(true, weapon.IsNuclear);
            }

            [Test]
            public void PlanetConstructorWorksCorrectly()
            {
                Planet planet = new Planet("Mars", 5.2);

                Assert.AreEqual("Mars", planet.Name);
                Assert.AreEqual(5.2, planet.Budget);
            }

            [TestCase(null)]
            [TestCase("")]
            public void PlanetNamePropertyShouldThrowExceptionWhenValueIsNullOrEmpty(string name)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Planet planet = new Planet(name, 5.2);
                }, "Name must not be null or empty!");
            }

            [TestCase(-5)]
            [TestCase(-1)]
            public void PlanetBudgetPropertyShouldThrowExceptionWhenValueIsLessThanZero(double budget)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Planet planet = new Planet("Mars", budget);
                }, "Budget value must be greater than zero!");
            }

            [Test]
            public void PlanetMilitaryPowerRatioReturnCorrectValue()
            {
                Planet planet = new Planet("Mars", 5.2);

                planet.AddWeapon(new Weapon("Deagle", 2, 2));
                planet.AddWeapon(new Weapon("RPG", 8, 6));

                Assert.AreEqual(8, planet.MilitaryPowerRatio);
            }

            [Test]
            public void PlanetProfitMethodShouldIncreaseTheBudget()
            {
                Planet planet = new Planet("Mars", 5.2);

                planet.Profit(5.2);

                Assert.AreEqual(10.4, planet.Budget);
            }

            [Test]
            public void PlanetSpendFundsMethodShouldDecreaseTheBudget()
            {
                Planet planet = new Planet("Mars", 10);

                planet.SpendFunds(8);

                Assert.AreEqual(2, planet.Budget);
            }

            [Test]
            public void PlanetSpendFundsMethodShouldThrowExceptionWhenValueIsGreaterThanTheBudget()
            {
                Planet planet = new Planet("Mars", 5);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.SpendFunds(8);
                }, "Not enough money!");
            }

            [Test]
            public void PlanetAddWeaponMethodShouldAddWeaponToTheCollection()
            {
                Planet planet = new Planet("Mars", 5);
                Weapon weapon = new Weapon("Deagle", 2, 2);

                planet.AddWeapon(weapon);

                Assert.AreEqual(1, planet.Weapons.Count);
            }

            [Test]
            public void PlanetAddWeaponMethodShouldThrowExceptionIfWeaponAlreadyExistsInTheCollection()
            {
                Planet planet = new Planet("Mars", 5);
                Weapon weapon = new Weapon("Deagle", 2, 2);

                planet.AddWeapon(weapon);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.AddWeapon(weapon);
                }, "Weapon already exist!");
            }

            [Test]
            public void PlanetRemoveWeaponMethodShouldRemoveWeaponFromCollection()
            {
                Planet planet = new Planet("Mars", 5);
                Weapon weapon = new Weapon("Deagle", 2, 2);

                planet.AddWeapon(weapon);
                planet.RemoveWeapon("Deagle");

                Assert.AreEqual(0, planet.Weapons.Count);
            }

            [Test]
            public void PlanetUpgradeWeaponMethodShouldUpdateWeaponsDestructionLevel()
            {
                Planet planet = new Planet("Mars", 5);
                Weapon weapon = new Weapon("Deagle", 2, 2);

                planet.AddWeapon(weapon);
                planet.UpgradeWeapon("Deagle");

                Assert.AreEqual(3, weapon.DestructionLevel);
            }

            [Test]
            public void PlanetUpgradeWeaponMethodShouldThrowExceptionIfWeaponsDoesntExist()
            {
                Planet planet = new Planet("Mars", 5);
                Weapon weapon = new Weapon("Deagle", 2, 2);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.UpgradeWeapon("Deagle");
                }, "Weapon does not exist");
            }

            [Test]
            public void PlanetDestructOponentWithWeakerPlanet()
            {
                Planet planet = new Planet("Mars", 5);
                planet.AddWeapon(new Weapon("Deagle", 2, 2));

                Planet planet2 = new Planet("Jupiter", 2);
                planet2.AddWeapon(new Weapon("Glock", 1, 1));

                Assert.AreEqual("Jupiter is destructed!", planet.DestructOpponent(planet2));
            }

            [Test]
            public void PlanetDestructOpponentWithStrongerPlanet()
            {
                Planet planet = new Planet("Mars", 5);
                planet.AddWeapon(new Weapon("Deagle", 2, 2));

                Planet planet2 = new Planet("Jupiter", 15);
                planet2.AddWeapon(new Weapon("RPG", 8, 6));

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.DestructOpponent(planet2);
                }, "Opponent is too strong!");
            }
        }
    }
}
