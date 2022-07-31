namespace CarManager.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class CarManagerTests
    {
        [TestCase("bmw", "m5", "5.70", "80.00")]
        public void TestConstructorShouldCreateInstance(params string[] data)
        {
            string make = data[0];
            string model = data[1];
            double fuelConsumption = double.Parse(data[2]);
            double fuelCapacity = double.Parse(data[3]);

            Car testCar = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.AreEqual(make, testCar.Make);
            Assert.AreEqual(model, testCar.Model);
            Assert.AreEqual(fuelConsumption, testCar.FuelConsumption);
            Assert.AreEqual(fuelCapacity, testCar.FuelCapacity);
        }

        [TestCase(null)]
        [TestCase("")]
        public void TestPropertyMakeMustThrowExceptionWhenIsEmpty(string make)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car testCar = new Car(make, "m5", 5.70, 80.00);
            }, "Property Make cannot be null or empty!");
        }

        [TestCase(null)]
        [TestCase("")]
        public void TestPropertyModelMustThrowExceptionWhenIsEmpty(string model)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car testCar = new Car("bmw", model, 5.70, 80.00);
            }, "Property Model cannot be null or empty!");
        }

        [TestCase(-5)]
        [TestCase(-1)]
        [TestCase(0)]
        public void TestPropertyFuelConsumptionMustThrowExceptionWhenParameterIsInvalid(double fuelCons)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car testCar = new Car("bmw", "m5", fuelCons, 80.00);
            }, "Fuel consumption cannot be zero or negative!");
        }

        [TestCase(-5)]
        [TestCase(-1)]
        [TestCase(0)]
        public void TestPropertyFuelCapacityMustThrowExceptionWhenParameterIsInvalid(double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car testCar = new Car("bmw", "m5", 5.70, fuelCapacity);
            }, "Fuel capacity cannot be zero or negative!");
        }

        [TestCase(-5)]
        [TestCase(-1)]
        [TestCase(0)]
        public void TestRefuelMustThrowExceptionWhenParameterIsInvalid(double fuel)
        {
            Car testCar = new Car("bmw", "m5", 5.70, 80.00);

            Assert.Throws<ArgumentException>(() =>
            {
                testCar.Refuel(fuel);
            }, "Fuel amount cannot be zero or negative!");
        }

        [TestCase(50)]
        [TestCase(79)]
        [TestCase(80)]
        public void TestRefuelShouldWorkCorrectly(double fuel)
        {
            Car testCar = new Car("bmw", "m5", 5.70, 80.00);

            testCar.Refuel(fuel);

            Assert.AreEqual(fuel, testCar.FuelAmount);
        }

        [TestCase(90)]
        [TestCase(81)]
        public void TestRefuelShouldNotOverflow(double fuel)
        {
            Car testCar = new Car("bmw", "m5", 5.70, 80.00);

            testCar.Refuel(fuel);

            Assert.AreEqual(testCar.FuelCapacity, testCar.FuelAmount);
        }

        [TestCase(10)]
        [TestCase(5)]
        [TestCase(1)]
        public void TestDriveMustThrowExceptionWhenFuelIsNotEnough(int distance)
        {
            Car testCar = new Car("bmw", "m5", 5.70, 80.00);

            Assert.Throws<InvalidOperationException>(() =>
            {
                testCar.Drive(distance);
            }, "Car does not have enough fuel to drive!");
        }

        [Test]
        public void TestDriveShouldReduceFuelAmountIfEnoughFuel()
        {
            Car testCar = new Car("bmw", "m5", 7, 60);

            testCar.Refuel(60);
            testCar.Drive(50);

            Assert.AreEqual(56.5, testCar.FuelAmount);
        }
    }
}