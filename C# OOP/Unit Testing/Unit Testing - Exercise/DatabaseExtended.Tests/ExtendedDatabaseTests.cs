namespace DatabaseExtended.Tests
{
    using System;
    using System.Text;
    using ExtendedDatabase;
    using NUnit.Framework;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database _db;

        [SetUp]
        public void SetUp()
        {
            this._db = new Database();
        }

        [TestCase(20)]
        [TestCase(17)]
        public void TestConstructorMustNotAllowToExceedMaximumCount(int count)
        {
            Person[] people = new Person[count];

            for (int i = 0; i < count; i++)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Gosho");
                sb.Append(i.ToString());

                people[i] = new Person(123 + i, sb.ToString());
            }

            Assert.Throws<ArgumentException>(() =>
            {
                Database testDb = new Database(people);
            }, "Provided data length should be in range [0..16]!");
        }

        [TestCase(15)]
        public void TestConstructorShouldAddLessOrEqualTo16Elements(int count)
        {
            Person[] people = new Person[count];

            for (int i = 0; i < count; i++)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Gosho");
                sb.Append(i.ToString());

                people[i] = new Person(123 + i, sb.ToString());
            }

            Database testDb = new Database(people);

            Assert.AreEqual(count, testDb.Count, "Constructor should add less or equal to 16 elements in the database!");
        }

        [TestCase(6)]
        public void TestCountMustReturnActualCount(int count)
        {
            Person[] data = new Person[count];

            for (int i = 0; i < count; i++)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Gosho");
                sb.Append(i.ToString());

                data[i] = new Person(123 + i, sb.ToString());
            }

            Database testDb = new Database(data);

            int actualCount = testDb.Count;
            int expectedCount = data.Length;

            Assert.AreEqual(expectedCount, actualCount, "Count must return the count of the field!");
        }


        [Test]
        public void TestCountMustReturnZeroWhenItsEmpty()
        {
            int actualCount = this._db.Count;
            int expectedCount = 0;

            Assert.AreEqual(expectedCount, actualCount, "Count must return zero if the field is empty!");
        }

        [Test]
        public void TestAddShouldThrowExceptionWhenCollectionIsFull()
        {
            Person[] people = new Person[16];

            for (int i = 0; i < 16; i++)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Iva");
                sb.Append(i.ToString());

                people[i] = new Person(1234 + i, sb.ToString());
            }

            Database testDb = new Database(people);

            Assert.Throws<InvalidOperationException>(() =>
            {
                testDb.Add(new Person(123, "Gosho"));
            }, "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void TestAddShouldThrowExceptionWhenAddingExistingPersonByUsername()
        {
            this._db.Add(new Person(123, "Gosho"));

            Assert.Throws<InvalidOperationException>(() =>
            {
                this._db.Add(new Person(133, "Gosho"));
            }, "There is already user with this username!");
        }

        [Test]
        public void TestAddShouldThrowExceptionWhenAddingExistingPersonByID()
        {
            this._db.Add(new Person(123, "Gosho"));

            Assert.Throws<InvalidOperationException>(() =>
            {
                this._db.Add(new Person(123, "Pesho"));
            }, "There is already user with this id!");
        }

        [Test]
        public void TestRemoveShouldThrowExceptionWhenIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this._db.Remove();
            }, "Remove must throw exception when the collection is empty!");
        }

        [Test]
        public void TestRemoveShouldDeleteElements()
        {
            Person[] people = new Person[16];

            for (int i = 0; i < 16; i++)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Iva");
                sb.Append(i.ToString());

                people[i] = new Person(1234 + i, sb.ToString());
            }

            Database testDb = new Database(people);

            testDb.Remove();
            testDb.Remove();
            testDb.Remove();

            Assert.AreEqual(13, testDb.Count);
        }

        [TestCase(null)]
        [TestCase("")]
        public void TestFindByUsernameMustThrowExceptionWhenParameterIsEmpty(string name)
        {
            this._db.Add(new Person(123, "Gosho"));

            Assert.Throws<ArgumentNullException>(() =>
            {
                this._db.FindByUsername(name);
            }, "Username parameter is null!");
        }

        [TestCase("Pesho")]
        [TestCase("Gosh")]
        [TestCase("Goso")]
        public void TestFindByUsernameMustThrowExceptionWhenParameterDoesNotExist(string name)
        {
            this._db.Add(new Person(123, "Gosho"));

            Assert.Throws<InvalidOperationException>(() =>
            {
                this._db.FindByUsername(name);
            }, "No user is present by this username!");
        }

        [TestCase("Pesho")]
        [TestCase("Gosho")]
        public void TestFindByUsernameMustReturnCorrectPerson(string name)
        {
            this._db.Add(new Person(143, "Pesho"));
            this._db.Add(new Person(123, "Gosho"));

            string actualName = this._db.FindByUsername(name).UserName;
            string expectedName = name;

            Assert.AreEqual(expectedName, actualName);
        }

        [TestCase(-10)]
        [TestCase(-5)]
        [TestCase(-1)]
        public void TestFindByIdMustThrowExceptionWhenParameterIsInvalid(int id)
        {
            this._db.Add(new Person(453, "Gosho"));

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                this._db.FindById(id);
            }, "Id should be a positive number!");
        }

        [TestCase(132)]
        [TestCase(213)]
        [TestCase(321)]
        public void TestFindByIDMustThrowExceptionWhenParameterDoesNotExist(int id)
        {
            this._db.Add(new Person(123, "Gosho"));

            Assert.Throws<InvalidOperationException>(() =>
            {
                this._db.FindById(id);
            }, "No user is present by this id!");
        }

        [TestCase(123)]
        [TestCase(143)]
        public void TestFindByIDMustReturnCorrectPerson(int id)
        {
            this._db.Add(new Person(143, "Pesho"));
            this._db.Add(new Person(123, "Gosho"));

            int actualID = (int)this._db.FindById(id).Id;
            int expectedID = id;

            Assert.AreEqual(expectedID, actualID);
        }
    }
}