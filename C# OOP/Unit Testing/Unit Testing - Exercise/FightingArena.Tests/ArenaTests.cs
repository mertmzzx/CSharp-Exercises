namespace FightingArena.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;

    [TestFixture]
    public class ArenaTests
    {
        private Arena _arena;

        [SetUp]
        public void SetUp()
        {
            this._arena = new Arena();
        }

        [Test]
        public void TestConstructorInitializesEmptyCollectionOfWarrior()
        {
            Arena testArenna = new Arena();

            List<Warrior> actualCollection = testArenna.Warriors.ToList();
            List<Warrior> expectedCollection = new List<Warrior>();

            CollectionAssert.AreEqual(expectedCollection, actualCollection, "Arena constructor should initialize an empty collection of Warriors!");
        }

        [Test]
        public void TestWarriorsCollectionEncapsulatesProperly()
        {
            string actualType = typeof(Arena)
                .GetProperties()
                .First(pi => pi.Name == "Warriors")
                .PropertyType
                .Name;
            string expectedType = typeof(IReadOnlyCollection<Warrior>).Name;

            Assert.AreEqual(expectedType, actualType, "Property for the enrolled Warriors should be of type IReadOnlyCollection<Warrior>!");
        }

        [Test]
        public void TestCountShouldReturnZeroOnEmptyArena()
        {
            int actualCount = this._arena.Count;
            int expectedCount = 0;

            Assert.AreEqual(expectedCount, actualCount, "Count should return zero when there are no enrolled Warriors!");
        }

        [Test]
        public void TestCountShouldReturnValidValue()
        {
            Warrior warrior = new Warrior("Pesho", 30, 100);

            this._arena.Enroll(warrior);

            int actualCount = this._arena.Count;
            int expectedCounnt = 1;

            Assert.AreEqual(expectedCounnt, actualCount, "Count should return the count of the enrolled warriors!");
        }

        [Test]
        public void TestEnrollAddsWarriorsToArena()
        {
            Warrior pesho = new Warrior("Pesho", 30, 100);
            Warrior gosho = new Warrior("Gosho", 35, 85);

            this._arena.Enroll(pesho);
            this._arena.Enroll(gosho);

            List<Warrior> actualCollection = this._arena.Warriors.ToList();
            List<Warrior> expectedCollection = new List<Warrior>()
            {
                pesho,
                gosho
            };

            CollectionAssert.AreEqual(expectedCollection, actualCollection, "Warriors collection getter should return enrolled warriors!");
        }

        [Test]
        public void TestEnrollShouldThrowErrorWhenEnrollingExistingWarrior()
        {
            Warrior warrior = new Warrior("Pesho", 30, 100);

            this._arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this._arena.Enroll(warrior);
            }, "Warrior is already enrolled for the fights!");
        }

        [Test]
        public void TestEnrollFightWithInExistingAttackedShouldThrowError()
        {
            Warrior warrior = new Warrior("Pesho", 30, 100);

            this._arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this._arena.Fight("Invalid", "Pesho");
            }, "There is no fighter with the name Invalid enrolled for the fights!");
        }

        [Test]
        public void TestEnrollFightWithInExistingDefenderShouldThrowError()
        {
            Warrior warrior = new Warrior("Pesho", 30, 100);

            this._arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this._arena.Fight("Pesho", "Invalid");
            }, "There is no fighter with the name Invalid enrolled for the fights!");
        }

        [Test]
        public void TestFightBetweenExistingWarriorsShouldProceed()
        {
            Warrior warriorA = new Warrior("Pesho", 40, 100);
            Warrior warriorD = new Warrior("Gosho", 55, 100);

            this._arena.Enroll(warriorA);
            this._arena.Enroll(warriorD);
            
            this._arena.Fight(warriorA.Name, warriorD.Name);

            int attackerActualHP = warriorA.HP;
            int attackerExpectedHP = 100 - warriorD.Damage;

            int defenderActualHP = warriorD.HP;
            int defenderExpectedHP = 100 - warriorA.Damage;

            Assert.AreEqual(attackerExpectedHP, attackerActualHP, "Fight between existing warriors should decrease Attacker's HP!");

            Assert.AreEqual(defenderExpectedHP, defenderActualHP, "Fight between existing warriors should decrease Defender's HP!");
        }
    }
}
