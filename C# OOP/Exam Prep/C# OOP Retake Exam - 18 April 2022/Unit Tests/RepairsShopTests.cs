using NUnit.Framework;

namespace RepairShop.Tests
{
    using System;

    public class Tests
    {
        public class RepairsShopTests
        {
            [TestCase(null)]
            [TestCase("")]
            public void TestGarageNameShouldThrowExceptionWithEmptyAndNullValues(string name)
            {
                Assert.Throws<ArgumentNullException>(() =>
                {
                    var garage = new Garage(name, 10);
                }, "Invalid garage name.");
            }

            [Test]
            public void TestGarageNNamePropertyShouldWorksCorrectly()
            {
                var garage = new Garage("RaceMonkey", 10);

                Assert.AreEqual("RaceMonkey", garage.Name);
            }

            [TestCase(0)]
            [TestCase(-5)]
            public void TestGarageMechanicsShouldThrowExceptionWithNoMechanics(int mechanics)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    var garage = new Garage("RaceMonkey", mechanics);
                }, "At least one mechanic must work in the garage.");
            }

            [TestCase(10)]
            [TestCase(5)]
            public void TestGarageMechanicsPropertyShouldWorkCorrectly(int mechanics)
            {
                var garage = new Garage("RaceMonkey", mechanics);

                int expectedResult = mechanics;
                int actualResult = garage.MechanicsAvailable;

                Assert.AreEqual(expectedResult, actualResult);
            }

            [Test]
            public void TestGarageCountMustReturnCorrectValue()
            {
                var garage = new Garage("RaceMonkey", 10);

                int expectedResult = 0;
                int actualResult = garage.CarsInGarage;

                Assert.AreEqual(expectedResult, actualResult);
            }

            [Test]
            public void TestGarageAddCarShouldThrowExceptionWithNoAvailableMechanics()
            {
                var garage = new Garage("RaceMonkey", 1);
                var firstCar = new Car("BMW", 10);
                var secondCar = new Car("Audi", 15);

                garage.AddCar(firstCar);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.AddCar(secondCar);
                }, "No mechanics available.");
            }

            [Test]
            public void TestGarageAddCarShouldIncrementCorrectCarCount()
            {
                var garage = new Garage("RaceMonkey", 10);
                var firstCar = new Car("BMW", 10);
                var secondCar = new Car("Audi", 15);

                garage.AddCar(firstCar);
                garage.AddCar(secondCar);

                int expectedResult = 2;
                int actualResult = garage.CarsInGarage;

                Assert.AreEqual(expectedResult, actualResult);
            }

            [Test]
            public void TestGarageFixCarShouldThrowExceptionIfCarDoesNotExist()
            {
                var garage = new Garage("RaceMonkey", 10);
                var firstCar = new Car("BMW", 10);
                var secondCar = new Car("Audi", 15);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.FixCar("Mercedes");
                }, "The car does not exist.");
            }

            [TestCase("BMW")]
            [TestCase("Mercedes")]
            public void TestGarageFixCarShouldFixCarCorrectly(string carModel)
            {
                var garage = new Garage("RaceMonkey", 10);
                var firstCar = new Car(carModel, 10);

                garage.AddCar(firstCar);
                var fixedCar = garage.FixCar(carModel);
                
                Assert.That(fixedCar.IsFixed, Is.True);
                Assert.That(fixedCar.CarModel, Is.EqualTo(carModel));
                Assert.That(fixedCar.NumberOfIssues, Is.EqualTo(0));
            }

            [Test]
            public void TestGarageRemoveFixedCarShouldThrowExceptionIfThereAreNoCarsAvailable()
            {
                var garage = new Garage("RaceMonkey", 10);
                var firstCar = new Car("BMW", 10);
                var secondCar = new Car("Audi", 15);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.RemoveFixedCar();
                }, "No fixed cars available.");
            }

            [Test]
            public void TestGarageRemoveFixedCarShouldRemoveAllFixedCars()
            {
                var garage = new Garage("RaceMonkey", 10);
                var firstCar = new Car("BMW", 10);
                var secondCar = new Car("Audi", 15);

                garage.AddCar(firstCar);
                garage.AddCar(secondCar);
                garage.FixCar(secondCar.CarModel);

                int fixedCars = garage.RemoveFixedCar();

                Assert.That(fixedCars, Is.EqualTo(1));
                Assert.That(garage.CarsInGarage, Is.EqualTo(1));
            }

            [Test]
            public void TestGarageReportShouldWorkCorrectly()
            {
                var garage = new Garage("RaceMonkey", 10);
                var firstCar = new Car("BMW", 10);
                var secondCar = new Car("Audi", 15);
                var thirdCar = new Car("Mercedes", 5);

                garage.AddCar(firstCar);
                garage.AddCar(secondCar);
                garage.AddCar(thirdCar);
                garage.FixCar(secondCar.CarModel);
                var report = garage.Report();

                Assert.That(report, Is.Not.Null);
                Assert.That(report, Is.EqualTo($"There are 2 which are not fixed: BMW, Mercedes."));
            }
        }
    }
}