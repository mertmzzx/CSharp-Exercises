namespace Aquariums.Tests
{
    using System;
    using NUnit.Framework;

    public class AquariumsTests
    {
        [Test]
        public void ConstructorShouldWorkCorrectly()
        {
            Aquarium aq = new Aquarium("Black", 5);

            string expectedName = "Black";
            string actualName = aq.Name;

            int expectedCapacity = 5;
            int actualCapacity = aq.Capacity;

            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedCapacity, actualCapacity);
        }

        [TestCase(null)]
        [TestCase("")]
        public void NamePropertyShouldThrowExceptionWhenParametersAreNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Aquarium aq = new Aquarium(name, 5);
            }, "Aquarium name should not be null or empty!");
        }

        [TestCase(-10)]
        [TestCase(-5)]
        [TestCase(-1)]
        public void CapacityPropertyShouldThrowExceptionWhenParametersAreInvalid(int capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Aquarium aq = new Aquarium("Black", capacity);
            }, "Capacity must be greater than 0!");
        }

        [Test]
        public void CountMustReturnValidValue()
        {
            Aquarium aq = new Aquarium("Black", 5);

            int actualResult = aq.Count;
            int expectedResult = 0;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void AddMethodShouldPhysicallyWorkCorrectly()
        {
            Aquarium aq = new Aquarium("Small", 3);

            aq.Add(new Fish("Gosho"));
            aq.Add(new Fish("Pesho"));

            int actualCount = aq.Count;
            int expectedCount = 2;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddMethodShouldThrowExceptionWhenAquariumIsFull()
        {
            Aquarium aq = new Aquarium("Small", 3);

            aq.Add(new Fish("Gosho"));
            aq.Add(new Fish("Pesho"));
            aq.Add(new Fish("Ivan"));

            Assert.Throws<InvalidOperationException>(() =>
            {
                aq.Add(new Fish("Misho"));
            }, "Capacity must not overflow!");
        }

        [Test]
        public void RemoveFishShouldPhysicallyWorkCorrectly()
        {
            Aquarium aq = new Aquarium("Small", 3);

            aq.Add(new Fish("Gosho"));
            aq.Add(new Fish("Pesho"));
            aq.RemoveFish("Gosho");

            int actualCount = aq.Count;
            int expectedCount = 1;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void RemoveFishShouldThrowExceptionWhenParameterIsInvalid()
        {
            Aquarium aq = new Aquarium("Black", 5);

            aq.Add(new Fish("Gosho"));

            Assert.Throws<InvalidOperationException>(() =>
            {
                aq.RemoveFish("Pesho");
            }, "The fish does not exist!");
        }

        [Test]
        public void SellFishShouldWorkCorrectly()
        {
            Aquarium aq = new Aquarium("Black", 5);
            Fish fish = new Fish("Gosho");

            aq.Add(fish);
            aq.SellFish(fish.Name);

            bool actualResult = fish.Available;
            bool expectedResult = false;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void SellFishShouldThrowExceptionWhenParameterIsInvalid()
        {
            Aquarium aq = new Aquarium("Black", 5);
            Fish firstFish = new Fish("Gosho");
            Fish secondFish = new Fish("Pesho");

            aq.Add(firstFish);
            aq.Add(secondFish);
            aq.RemoveFish("Pesho");

            Assert.Throws<InvalidOperationException>(() =>
            {
                aq.SellFish("Pesho");

            }, "The fish can not be null!");
        }

        [Test]
        public void SellFishReturnCorrectFish()
        {
            Aquarium aq = new Aquarium("Black", 5);
            Fish fish = new Fish("Gosho");

            aq.Add(fish);

            Assert.AreEqual(fish, aq.SellFish("Gosho"));
        }

        [Test]
        public void ReportShouldWorkCorrectly()
        {
            Aquarium aq = new Aquarium("Black", 5);

            aq.Add(new Fish("Gosho"));
            aq.Add(new Fish("Pesho"));

            string actualResult = aq.Report();
            string expectedResult = "Fish available at Black: Gosho, Pesho";

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
