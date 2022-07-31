namespace FightingArena.Tests
{
    using System;
    using System.Linq;
    using System.Reflection;
    using NUnit.Framework;

    [TestFixture]
    public class WarriorTests
    {
        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            //Arrange
            string expectedName = "Pesho";
            int expectedDamage = 55;
            int expectedHp = 55;
            Warrior warrior = new Warrior(expectedName, expectedDamage, expectedHp);

            //Act
            FieldInfo nameField = this.GetField("name");
            string actualName = (string)nameField.GetValue(warrior);

            FieldInfo dmgField = this.GetField("damage");
            int actualDamage = (int)dmgField.GetValue(warrior);

            FieldInfo hpField = this.GetField("hp");
            int actualHp = (int)hpField.GetValue(warrior);

            //Assert
            Assert.AreEqual(expectedName, actualName, "Constructor should initialize the Name of the Warrior!");
            Assert.AreEqual(expectedDamage, actualDamage, "Constructor should initialize the Damage of the Warrior!");
            Assert.AreEqual(expectedHp, actualHp, "Constructor should initialize the HP of the Warrior!");
        }

        [Test]
        public void TestNameGetter()
        {
            //Arrange
            string expectedName = "Pesho";
            Warrior warrior = new Warrior(expectedName, 55, 55);

            //Act
            string actualName = warrior.Name;

            //Assert
            Assert.AreEqual(expectedName, actualName, "Getter of the property Name should return the value of name!");
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("          ")]
        public void TestNameSetterValidation(string name)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, 55, 55);
            }, "Name should not be empty or whitespace!");
        }

        [Test]
        public void TestDamageSetter()
        {
            //Arrange
            int expectedDamage = 55;
            Warrior warrior = new Warrior("Pesho", expectedDamage, 55);

            //Act
            int actualDamage = warrior.Damage;

            //Assert
            Assert.AreEqual(expectedDamage, actualDamage, "Getter of the property Damage should return the value of damage!");
        }

        [TestCase(-5)]
        [TestCase(-1)]
        [TestCase(0)]
        public void TestDamageSetterValidation(int damage)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Pesho", damage, 55);
            }, "Damage value should be positive!");
        }

        [Test]
        public void TestHPGetter()
        {
            //Arrange
            int expectedHP = 55;
            Warrior warrior = new Warrior("Pesho", 55, expectedHP);

            //Act
            int actualHP = warrior.HP;

            //Assert
            Assert.AreEqual(expectedHP, actualHP, "Getter of the property HP should return the value of HP!");
        }

        [TestCase(-5)]
        [TestCase(-1)]
        public void TestHPSetterValidation(int hp)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Pesho", 55, hp);
            }, "HP should not be negative!");
        }

        [TestCase(0)]
        [TestCase(15)]
        [TestCase(30)]
        public void TestAttackShouldThrowErrorWhenAttackingWarriorIsLow(int startHP)
        {
            //Arrange
            Warrior warriorA = new Warrior("Pesho", 70, startHP);
            Warrior warriorD = new Warrior("Gosho", 50, 45);

            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                //Act
                warriorA.Attack(warriorD);
            }, "Your HP is too low in order to attack other warriors!");
        }

        [TestCase(0)]
        [TestCase(15)]
        [TestCase(30)]
        public void TestAttackShouldThrowErrorWhenDefendingWarriorIsLow(int startHP)
        {
            //Arrange
            Warrior warriorA = new Warrior("Pesho", 70, 45);
            Warrior warriorD = new Warrior("Gosho", 50, startHP);

            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                //Act
                warriorA.Attack(warriorD);
            }, "Enemy HP must be greater than 30 in order to attack him!");
        }

        [TestCase(40, 50)]
        [TestCase(49, 50)]
        public void TestAttackShouldThrowErrorWhenDefendingWarriorIsStronger(int attackerHP, int defenderDmg)
        {
            //Arrange
            Warrior warriorA = new Warrior("Pesho", 70, attackerHP);
            Warrior warriorD = new Warrior("Gosho", defenderDmg, 70);

            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                //Act
                warriorA.Attack(warriorD);
            }, "You are trying to attack too strong enemy!");
        }

        [TestCase(70, 50)]
        [TestCase(60, 55)]
        [TestCase(50, 50)]
        public void SuccessAttackShouldDecreaseAttackerHP(int attackerHP, int defenderDmg)
        {
            //Arrange
            Warrior warriorA = new Warrior("Pesho", 50, attackerHP);
            Warrior warriorD = new Warrior("Gosho", defenderDmg, 55);

            //Act
            warriorA.Attack(warriorD);

            int actualHP = warriorA.HP;
            int expectedHP = attackerHP - defenderDmg;

            //Assert
            Assert.AreEqual(expectedHP, actualHP, "Successful attack should decrease attacker's HP!");
        }

        [TestCase(30, 50)]
        [TestCase(40, 45)]
        [TestCase(69, 70)]

        public void SuccessAttackShouldDecreaseDefenderHP(int attackerDmg, int defenderHP)
        {
            //Arrange
            Warrior warriorA = new Warrior("Pesho", attackerDmg, 100);
            Warrior warriorD = new Warrior("Gosho", 40, defenderHP);

            //Act
            warriorA.Attack(warriorD);

            int actualHP = warriorD.HP;
            int expectedHP = defenderHP - attackerDmg;

            //Assert
            Assert.AreEqual(expectedHP, actualHP, "Successful attack should decrease the defender's HP!");
        }

        [TestCase(70, 50)]
        [TestCase(60, 55)]
        [TestCase(60, 59)]
        public void SuccessAttackShouldKillDefender(int attackerDmg, int defenderHP)
        {
            //Arrange
            Warrior warriorA = new Warrior("Pesho", attackerDmg, 100);
            Warrior warriorD = new Warrior("Gosho", 40, defenderHP);

            //Act
            warriorA.Attack(warriorD);

            int actualHP = warriorD.HP;
            int expectedHP = 0;

            //Assert
            Assert.AreEqual(expectedHP, actualHP, "Successful attack should kill the defender!");
        }

        private FieldInfo GetField(string fieldName) 
            => typeof(Warrior)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(f => f.Name == fieldName);
    }
}