namespace Database.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;

    [TestFixture]
    public class DatabaseTests
    {
        private Database _db;

        [SetUp]
        public void SetUp()
        {
            this._db = new Database();
        }

        [TestCase(new int[] {})]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3})]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void TestConstructorShouldAddLessThan16Elements(int[] elementsToAdd)
        {
            //Arange
            Database testDb = new Database(elementsToAdd);

            //Act
            int[] actualData = testDb.Fetch();
            int[] expectedData = elementsToAdd;

            int actualCount = testDb.Count;
            int expectedCount = expectedData.Length;

            //Assert
            CollectionAssert.AreEqual(expectedData, actualData, "Database constructor should initialize data field correctly!");
            Assert.AreEqual(expectedCount, actualCount, "Constructor should set initial value for count field!");
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 })]
        public void TestConstructorMustNotAllowToExceedMaximumCount(int[] elementsToAdd)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Database testDb = new Database(elementsToAdd);
            }, "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void TestCountMustReturnActualCount()
        {
            //Arange
            int[] data = new int[] { 1, 2, 3 };
            Database testDb = new Database(data);

            //Act
            int actualCount = testDb.Count;
            int expectedCount = data.Length;

            //Assert
            Assert.AreEqual(expectedCount, actualCount, "Count should return the count of the field!");
        }

        [Test]
        public void TestCountMustReturnZeroWhenItsEmpty()
        {
            int actualCount = this._db.Count;
            int expectedCount = 0;

            Assert.AreEqual(expectedCount, actualCount, "Count must return zero if the field is empty!");
        }

        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void TestAddShouldAddLessThan16Elements(int[] elementsToAdd)
        {
            //Act
            foreach (var el in elementsToAdd)
            {
                this._db.Add(el);
            }

            int[] actualData = this._db.Fetch();
            int[] expectedData = elementsToAdd;

            int actualCount = this._db.Count;
            int expectedCount = elementsToAdd.Length;


            CollectionAssert.AreEqual(expectedData, actualData, "Add should physically add the elements to the field!");
            Assert.AreEqual(expectedCount, actualCount, "Add should change the elements' count!");
        }

        [TestCase(new int[] {1, 2, 3, 4, 5})]
        [TestCase(new int[] { 1 })]
        public void TestRemoveShouldRemoveTheLastElementSuccessfullyOnce(int[] startElements)
        {
            //Act
            foreach (var el in startElements)
            {
                this._db.Add(el);
            }

            this._db.Remove();
            List<int> elList = new List<int>(startElements);
            elList.RemoveAt(elList.Count - 1);

            int[] actualData = this._db.Fetch();
            int[] expectedData = elList.ToArray();

            int actualCount = this._db.Count;
            int expectedCount = expectedData.Length;

            CollectionAssert.AreEqual(expectedData, actualData, "Remove should physically remove the element in the data field!");
            Assert.AreEqual(expectedCount, actualCount, "Remove should decrement the count of the Database!");
        }

        [Test]
        public void TestRemoveShouldRemoveTheLastElementMoreThanOnce()
        {
            //Arrange
            List<int> initData = new List<int>() { 1, 2, 3 };

            //Act
            foreach (var el in initData)
            {
                this._db.Add(el);
            }

            for (int i = 0; i < initData.Count; i++)
            {
                this._db.Remove();
            }

            int[] actualData = this._db.Fetch();
            int[] expectedData = new int[] { };

            int actualCount = this._db.Count;
            int expectedCount = expectedData.Length;

            //Assert 
            CollectionAssert.AreEqual(expectedData, actualData, "Remove should physically remove the element in the data field!");
            Assert.AreEqual(expectedCount, actualCount, "Remove should decrement the count of the Database!");
        }

        [Test]
        public void TestRemoveShouldThrowErrorWhenThereAreNoElement()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this._db.Remove();
            }, "The collection is empty!");
        }

        [TestCase(new int[] {})]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void TestFetchShouldReturnCopyArray(int[] initData)
        {
            //Act
            foreach (var el in initData)
            {
                this._db.Add(el);
            }

            int[] actualResult = this._db.Fetch();
            int[] expectedResult = initData;

            CollectionAssert.AreEqual(expectedResult, actualResult, "Fetch should return copy of the existing data!");
        }
    }
}
