using NUnit.Framework;

namespace SmartphoneShop.Tests
{
    using System;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    public class SmartphoneShopTests
    {

        [Test]
        public void ConstructorSetsCorrectParameters()
        {
            Shop shop = new Shop(5);

            int actualResult = shop.Capacity;
            int expectedResult = 5;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CapacityPropertyShouldThrowExceptionWhenParameterIsLessThanZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Shop shop = new Shop(-1);
            }, "Capacity must be greater than zero.");
        }

        [Test]
        public void CountShouldReturnCorrectValue()
        {
            Shop shop = new Shop(5);

            int actualResult = shop.Count;
            int expectedResult = 0;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void AddMethodShouldWorkCorrectly()
        {
            Shop shop = new Shop(5);

            shop.Add(new Smartphone("iPhone 11", 100));

            int actualResult = shop.Count;
            int expectedResult = 1;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void AddMethodShouldThrowExceptionWhenPhoneAlreadyExists()
        {
            Shop shop = new Shop(5);

            shop.Add(new Smartphone("iPhone 11", 100));

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(new Smartphone("iPhone 11", 100));
            }, "Phone already exists!");
        }

        [Test]
        public void AddMethodShouldThrowExceptionWhenShopIsFull()
        {
            Shop shop = new Shop(2);

            shop.Add(new Smartphone("iPhone 11", 100));
            shop.Add(new Smartphone("iPhone 11 Pro", 100));

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(new Smartphone("Samsung Galaxy J5", 100));
            }, "Collection of phones must not overflow!");
        }

        [Test]
        public void RemoveMethodShouldWorkCorrectly()
        {
            Shop shop = new Shop(3);

            shop.Add(new Smartphone("iPhone 11", 100));
            shop.Add(new Smartphone("Samsung Galaxy J5", 100));
            shop.Remove("Samsung Galaxy J5");

            int actualResult = shop.Count;
            int expectedResult = 1;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void RemoveMethodShouldThrowExceptionWhenParameterIsInvalid()
        {
            Shop shop = new Shop(3);

            shop.Add(new Smartphone("iPhone 11", 100));

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Remove("iPhone 13 Pro Max");
            }, "Parameter must be valid!");
        }

        [Test]
        public void TestPhoneMethodShouldWorkCorrectly()
        {
            Shop shop = new Shop(5);
            Smartphone phone = new Smartphone("iPhone 13", 100);

            shop.Add(phone);
            shop.TestPhone("iPhone 13", 50);

            Assert.AreEqual(50, phone.CurrentBateryCharge);
        }

        [Test]
        public void TestPhoneMethodShouldThrowExceptionWhenParameterIsInvalid()
        {
            Shop shop = new Shop(5);
            Smartphone phone = new Smartphone("iPhone 13", 100);

            shop.Add(phone);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone("iPhone 11", 25);
            }, "Parameter must be valid!");
        }

        [Test]
        public void TestPhoneMethodShouldThrowExceptionWhenPhoneBatteryIsLowerThanRequirement()
        {
            Shop shop = new Shop(5);
            Smartphone phone = new Smartphone("iPhone 13", 100);

            shop.Add(phone);
            shop.TestPhone("iPhone 13", 50);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone("iPhone 13", 80);
            }, "Battery must not be lower than the requirements for the test!");
        }

        [Test]
        public void ChargePhoneMethodShouldWorkCorrectly()
        {
            Shop shop = new Shop(5);
            Smartphone phone = new Smartphone("iPhone 13", 100);

            shop.Add(phone);
            shop.TestPhone("iPhone 13", 50);
            shop.ChargePhone("iPhone 13");

            int actualResult = phone.CurrentBateryCharge;
            int expectedResult = phone.MaximumBatteryCharge;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void ChargePhoneMethodShouldThrowExceptionWhenParameterIsInvalid()
        {
            Shop shop = new Shop(5);
            Smartphone phone = new Smartphone("iPhone 13", 100);

            shop.Add(phone);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.ChargePhone("iPhone 12");
            }, "Parameter must be valid!");
        }
    }
}