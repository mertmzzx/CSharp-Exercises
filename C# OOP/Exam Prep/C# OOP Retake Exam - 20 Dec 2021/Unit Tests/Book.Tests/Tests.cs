namespace Book.Tests
{
    using System;

    using NUnit.Framework;

    public class Tests
    {
        [Test]
        public void ConstructorWorksCorrectly()
        {
            Book book = new Book("Winterfell", "Snow");

            Assert.IsNotNull(book);
            Assert.AreEqual("Winterfell", book.BookName);
            Assert.AreEqual("Snow", book.Author);
        }

        [Test]
        public void CountReturnsCorrectValue()
        {
            Book book = new Book("Winterfell", "Snow");

            Assert.AreEqual(0, book.FootnoteCount);
        }

        [TestCase(null)]
        [TestCase("")]
        public void BookNameThrowsExceptionWhenValueIsNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book(name, "Snow");
            }, "Book Name must not be null or empty!");
        }

        [TestCase(null)]
        [TestCase("")]
        public void AuthorPropThrowsExceptionWhenValueIsNullOrEmpty(string author)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book("Winterfell", author);
            }, "Author name must not be null or empty!");
        }

        [Test]
        public void AddFootNoteWorksCorrectly()
        {
            Book book = new Book("Winterfell", "Snow");

            book.AddFootnote(5, "Starks");

            Assert.AreEqual(1, book.FootnoteCount);
        }

        [Test]
        public void AddFootNoteThrowsExceptionWhenParameterAlreadyExists()
        {
            Book book = new Book("Winterfell", "Snow");

            book.AddFootnote(5, "Starks");

            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AddFootnote(5, "Starks");
            }, "This entity already exists!");
        }

        [Test]
        public void FindFootNoteReturnsCorrectValue()
        {
            Book book = new Book("Winterfell", "Snow");

            book.AddFootnote(5, "Starks");
            book.AddFootnote(3, "Kings");

            var footnote = book.FindFootnote(5);

            Assert.AreEqual("Footnote #5: Starks", footnote);
        }

        [Test]
        public void FindFootNoteThrowsExceptionWhenParameterIsInvalid()
        {
            Book book = new Book("Winterfell", "Snow");

            book.AddFootnote(3, "Kings");

            Assert.Throws<InvalidOperationException>(() =>
            {
                var footnote = book.FindFootnote(5);
            }, "Parameter is invalid!");
        }

        [Test]
        public void AlterFootNoteWorksCorrectly()
        {
            Book book = new Book("Winterfell", "Snow");

            book.AddFootnote(5, "Starks");
            book.AddFootnote(3, "Kings");

            var footnote = book.FindFootnote(5);
            book.AlterFootnote(5, "Boltons");
            var newFootnote = book.FindFootnote(5);

            Assert.AreNotEqual(footnote, newFootnote);
            Assert.AreEqual("Footnote #5: Boltons", newFootnote);
        }

        [Test]
        public void AlterFootNoteThrowsExceptionWhenParameterIsInvalid()
        {
            Book book = new Book("Winterfell", "Snow");

            book.AddFootnote(3, "Kings");

            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AlterFootnote(4, "Starks");
            }, "Parameter is invalid!");
        }
    }

}