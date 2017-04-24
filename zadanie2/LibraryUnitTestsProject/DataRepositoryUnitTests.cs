using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library;
using System;

namespace Library.Tests
{
    [TestClass]
    public class DataRepositoryUnitTests
    {

        [TestMethod]
        public void AddReader_AddingReader_ChangesReadersListSize()
        {
            int sizeAtFirst = 0;
            int sizeAfterMethodInvoking = 1;
            DataRepository data = new DataRepository();
            Reader reader = new Reader("Ala", "Makota", 122318);
            Assert.AreEqual(sizeAtFirst, data.ReadAllReaders().Count);
            data.AddReader(reader);
            Assert.AreEqual(sizeAfterMethodInvoking, data.ReadAllReaders().Count);
        }

        [TestMethod]
        public void ReadAllReaders_ValidMethod_ReturnsRightNumberOfElements()
        {
            int number = 3;
            DataRepository data = new DataRepository();
            Reader reader1 = new Reader("Ala", "Makota", 122318);
            Reader reader2 = new Reader("Ala", "Makota", 122318);
            Reader reader3 = new Reader("Ala", "Makota", 122318);
            data.AddReader(reader1);
            data.AddReader(reader2);
            data.AddReader(reader3);
            Assert.AreEqual(number, data.ReadAllReaders().Count);
        }

        [TestMethod]
        public void GetReader_ValidMethod_ReturnsRightReader()
        {
            int index = 0;
            Reader reader = new Reader("Ala", "Mała", 123876);
            DataRepository data = new DataRepository();
            data.AddReader(reader);
            Assert.AreEqual(reader, data.GetReader(index));
        }

        [TestMethod]
        public void DeleteReader_DeletingReaderFromListViaIndex_ChangesReadersListSize()
        {
            int index = 0;
            int sizeAfterMethodInvoking = 0;
            Reader reader = new Reader("Ala", "Mała", 1273);
            DataRepository data = new DataRepository();
            data.AddReader(reader);
            data.DeleteReader(index);
            Assert.AreEqual(sizeAfterMethodInvoking, data.ReadAllReaders().Count);
        }

        [TestMethod]
        public void DeleteReader_DeletingReaderFromListViaIndex_DeletesThisReaderRentings()
        {
            Reader reader = new Reader("Ala", "Mała", 12987);
            Reader reader1 = new Reader("Ala", "Mała", 37);
            DataRepository data = new DataRepository();
            Author author1 = new Author("Adam", "Mickiewicz");
            Author author2 = new Author("Nicholas", "Evans");
            Book book1 = new Book("Pan Tadeusz", author1, 1834, "Znak", 256);
            Book book2 = new Book("Zaklinacz Koni", author2, 1995, "Znak", 257);
            Renting renting1 = new Renting(reader, book1, new DateTime(2016, 04, 14));
            Renting renting2 = new Renting(reader, book2, new DateTime(2016, 02, 12));
            Renting renting3 = new Renting(reader1, book2, new DateTime(2016, 02, 12));
            data.AddReader(reader);
            data.AddRenting(renting1);
            data.AddRenting(renting2);
            data.AddRenting(renting3);
            data.DeleteReader(0);
            Assert.AreEqual(false, data.ReadAllRentings().Contains(renting1));
            Assert.AreEqual(false, data.ReadAllRentings().Contains(renting2));
            Assert.AreEqual(true, data.ReadAllRentings().Contains(renting3));
        }

        [TestMethod]
        public void DeleteReader_DeletingReaderFromListViaObject_ChangesReadersListSize()
        {
            int sizeAfterMethodInvoking = 0;
            Reader reader = new Reader("Ala", "Mała", 12987);
            DataRepository data = new DataRepository();
            data.AddReader(reader);
            data.DeleteReader(reader);
            Assert.AreEqual(sizeAfterMethodInvoking, data.ReadAllReaders().Count);
        }

        [TestMethod]
        public void DeleteReader_DeletingReaderFromListViaObject_DeletesThisReaderRentings()
        {
            Reader reader = new Reader("Ala", "Mała", 12987);
            Reader reader1 = new Reader("Ala", "Mała", 37);
            DataRepository data = new DataRepository();
            Author author1 = new Author("Adam", "Mickiewicz");
            Author author2 = new Author("Nicholas", "Evans");
            Book book1 = new Book("Pan Tadeusz", author1, 1834, "Znak", 256);
            Book book2 = new Book("Zaklinacz Koni", author2, 1995, "Znak", 257);
            Renting renting1 = new Renting(reader, book1, new DateTime(2016, 04, 14));
            Renting renting2 = new Renting(reader, book2, new DateTime(2016, 02, 12));
            Renting renting3 = new Renting(reader1, book2, new DateTime(2016, 02, 12));
            data.AddReader(reader);
            data.AddRenting(renting1);
            data.AddRenting(renting2);
            data.AddRenting(renting3);
            data.DeleteReader(reader);
            Assert.AreEqual(false, data.ReadAllRentings().Contains(renting1));
            Assert.AreEqual(false, data.ReadAllRentings().Contains(renting2));
            Assert.AreEqual(true, data.ReadAllRentings().Contains(renting3));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteReader_DeletingNonExistingReaderFromList_ThrowsException()
        {
            Reader reader = new Reader("Alicja", "Gałkiewicz", 1983);
            DataRepository data = new DataRepository();
            data.DeleteReader(reader);
        }

        [TestMethod]
        public void FilterReaders_FilteringEmptyList_ReturnsNothing()
        {
            int sizeAfterMethodInvoking = 0;
            DataRepository repo = new DataRepository();
            Assert.AreEqual(sizeAfterMethodInvoking, repo.FilterReaders(x => true).Count);
        }

        [TestMethod]
        public void FilterReaders_AlwaysFalseCondition_ReturnsNothing()
        {
            int sizeAfterMethodInvoking = 0;
            DataRepository repo = new DataRepository();
            Predicate<Reader> condition = new Predicate<Reader>(x => false);
            repo.AddReader(new Reader("Abc", "def", 12387));
            repo.AddReader(new Reader("AAAAA", "RER", 1237));
            repo.AddReader(new Reader("rrrrrrrrr", "aaaaaaaa", 87621));
            Assert.AreEqual(sizeAfterMethodInvoking, repo.FilterReaders(condition).Count);
        }

        [TestMethod]
        public void FilterReaders__SingleReaderInCondition_ReturnsThisReaderFromList()
        {
            int sizeAfterMethodInvoking = 1;
            DataRepository repo = new DataRepository();
            Reader importantReader = new Reader("Abc", "def", 254);
            Reader reader = new Reader("kaosk", "koaksoa", 1987);
            Predicate<Reader> condition = new Predicate<Reader>(x => x == importantReader);
            repo.AddReader(importantReader);
            repo.AddReader(reader);
            Assert.AreEqual(sizeAfterMethodInvoking, repo.FilterReaders(condition).Count);
        }

        [TestMethod]
        public void AddBook_AddingBook_ChangesBooksDictionarySize()
        {
            int sizeAtFirst = 0;
            int sizeAfterMethodInvoking = 1;
            DataRepository data = new DataRepository();
            Author author = new Author("J.K.", "Rowling");
            Book book = new Book("Harry Potter", author, 1998, "kaksoaks", 98);
            Assert.AreEqual(sizeAtFirst, data.ReadAllBooks().Count);
            data.AddBook(book);
            Assert.AreEqual(sizeAfterMethodInvoking, data.ReadAllBooks().Count);
        }

        [TestMethod]
        public void ReadAllBooks_ValidMethod_ReturnsRightNumberOfElements()
        {
            int number = 3;
            DataRepository data = new DataRepository();
            Author author = new Author("J.K.", "Rowling");
            Book book1 = new Book("Harry Potter", author, 1998, "kaksoaks", 98);
            Book book2 = new Book("Harry Potter", author, 1998, "kaksoaks", 99);
            Book book3 = new Book("Harry Potter", author, 1998, "kaksoaks", 100);
            data.AddBook(book1);
            data.AddBook(book2);
            data.AddBook(book3);
            Assert.AreEqual(number, data.ReadAllBooks().Count);
        }

        [TestMethod]
        public void GetBook_ValidMethod_ReturnsRightBook()
        {
            DataRepository data = new DataRepository();
            Author author = new Author("J.K.", "Rowling");
            Book book = new Book("Harry Potter", author, 1998, "kaksoaks", 98);
            data.AddBook(book);
            Assert.AreEqual(book, data.GetBook(book.Id));
        }

        [TestMethod]
        public void DeleteBook_DeletingBookFromDictionary_DeletesThisBookRentings()
        {
            Reader reader = new Reader("Ala", "Mała", 12987);
            Reader reader1 = new Reader("Ala", "Mała", 37);
            DataRepository data = new DataRepository();
            Author author1 = new Author("Adam", "Mickiewicz");
            Author author2 = new Author("Nicholas", "Evans");
            Book book1 = new Book("Pan Tadeusz", author1, 1834, "Znak", 256);
            Book book2 = new Book("Zaklinacz Koni", author2, 1995, "Znak", 257);
            Renting renting1 = new Renting(reader, book1, new DateTime(2016, 04, 14));
            Renting renting2 = new Renting(reader, book2, new DateTime(2016, 02, 12));
            Renting renting3 = new Renting(reader1, book2, new DateTime(2016, 02, 12));
            data.AddBook(book2);
            data.AddRenting(renting1);
            data.AddRenting(renting2);
            data.AddRenting(renting3);
            data.DeleteBook(book2.Id);
            Assert.AreEqual(true, data.ReadAllRentings().Contains(renting1));
            Assert.AreEqual(false, data.ReadAllRentings().Contains(renting2));
            Assert.AreEqual(false, data.ReadAllRentings().Contains(renting3));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteBook_DeletingNonExistingBookFromDictionary_ThrowsException()
        {
            DataRepository data = new DataRepository();
            Author author = new Author("asoiajs", "aosdaus");
            Book book = new Book("sdjsa", author, 1987, "asdaus", 12877);
            data.DeleteBook(book.Id);
        }

        [TestMethod]
        public void FilterBooks_FilteringEmptyDictionary_ReturnsNothing()
        {
            int sizeAfterMethodInvoking = 0;
            DataRepository repo = new DataRepository();
            Predicate<Book> condition = new Predicate<Book>(x => true);
            Assert.AreEqual(sizeAfterMethodInvoking, repo.FilterBooks(condition).Count);
        }

        [TestMethod]
        public void FilterBooks_AlwaysFalseCondition_ReturnsNothing()
        {
            int sizeAfterMethodInvoking = 0;
            DataRepository repo = new DataRepository();
            Predicate<Book> condition = new Predicate<Book>(x => false);
            Author author = new Author("sdcsdocx", "aidhusd");
            repo.AddBook(new Book("dsicnd", author, 1983, "iduhs", 1342));
            repo.AddBook(new Book("dsiasadcdsccnd", author, 1873, "iduhs", 142));
            repo.AddBook(new Book("asj", author, 1567, "iduhs", 42));
            Assert.AreEqual(sizeAfterMethodInvoking, repo.FilterBooks(condition).Count);
        }

        [TestMethod]
        public void FilterBooks_ConditionWithSingleBook_ReturnsThisBookFromDictionary()
        {
            int sizeAfterMethodInvoking = 1;
            DataRepository repo = new DataRepository();
            Author author = new Author("sdcsdocx", "aidhusd");
            Book importantBook = new Book("ashscajsn", author, 1987, "ajdna", 675);
            Book book = new Book("aygssaaaaaaacajsn", author, 1957, "ajdna", 75);
            Predicate<Book> condition = new Predicate<Book>(x => x == importantBook);
            repo.AddBook(importantBook);
            repo.AddBook(book);
            Assert.AreEqual(sizeAfterMethodInvoking, repo.FilterBooks(condition).Count);
        }

        [TestMethod]
        public void AddRenting_AddingRenting_ChangesRentingsCollectionSize()
        {
            int sizeAtFirst = 1;
            int sizeAfterMethodInvoking = 2;
            DataRepository data = new DataRepository();
            Reader reader = new Reader("Ala", "Makota", 122318);
            DateTime date = new DateTime(1987, 04, 23);
            Author author = new Author("asoiajs", "aosdaus");
            Book book = new Book("sdjsa", author, 1987, "asdaus", 12877);
            Renting renting = new Renting(reader, book, date);
            Renting renting1 = new Renting(reader, book, date);
            data.AddRenting(renting);
            Assert.AreEqual(sizeAtFirst, data.ReadAllRentings().Count);
            data.AddRenting(renting1);
            Assert.AreEqual(sizeAfterMethodInvoking, data.ReadAllRentings().Count);
        }

        [TestMethod]
        public void ReadAllRentings_ValidMethod_ReturnsRightNumberOfElements()
        {
            int number = 3;
            DataRepository data = new DataRepository();
            Reader reader = new Reader("Ala", "Makota", 122318);
            DateTime date = new DateTime(1987, 04, 23);
            Author author = new Author("asoiajs", "aosdaus");
            Book book = new Book("sdjsa", author, 1987, "asdaus", 12877);
            Renting renting1 = new Renting(reader, book, date);
            Renting renting2 = new Renting(reader, book, date);
            Renting renting3 = new Renting(reader, book, date);
            data.AddRenting(renting1);
            data.AddRenting(renting2);
            data.AddRenting(renting3);
            Assert.AreEqual(number, data.ReadAllRentings().Count);
        }

        [TestMethod]
        public void GetRenting_ValidMethod_ReturnsRightRenting()
        {
            int index = 0;
            DataRepository data = new DataRepository();
            Reader reader = new Reader("Ala", "Makota", 122318);
            DateTime date = new DateTime(1987, 04, 23);
            Author author = new Author("asoiajs", "aosdaus");
            Book book = new Book("sdjsa", author, 1987, "asdaus", 12877);
            Renting renting = new Renting(reader, book, date);
            data.AddRenting(renting);
            Assert.AreEqual(renting, data.GetRenting(index));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteRenting_DeletingNonExistingRentingFromCollection_ThrowsException()
        {
            DataRepository data = new DataRepository();
            Reader reader = new Reader("Ala", "Makota", 122318);
            DateTime date = new DateTime(1987, 04, 23);
            Author author = new Author("asoiajs", "aosdaus");
            Book book = new Book("sdjsa", author, 1987, "asdaus", 12877);
            Renting renting = new Renting(reader, book, date);
            data.DeleteRenting(renting);
        }

        [TestMethod]
        public void FilterRentings_ConditionWithSingleRenting_ReturnsThisRentingFromCollection()
        {
            int sizeAfterMethodInvoking = 1;
            DataRepository repo = new DataRepository();
            Reader reader = new Reader("oaisja", "asodja", 2147483656);
            Author author = new Author("asdja", "aosjda");
            DateTime date = new DateTime(1987, 03, 8);
            Book book = new Book("asoidaj", author, 1987, "asoidja", 11876);
            Book book1 = new Book("aygssaaaaaaacajsn", author, 1957, "ajdna", 75);
            Renting renting = new Renting(reader, book, date);
            Renting importantRenting = new Renting(reader, book1, date);
            Predicate<Renting> condition = new Predicate<Renting>(x => x == importantRenting);
            repo.AddRenting(importantRenting);
            repo.AddRenting(renting);
            Assert.AreEqual(sizeAfterMethodInvoking, repo.FilterRentings(condition).Count);
        }

        [TestMethod]
        public void FilterRentings_FilteringEmptyCollection_ReturnsNothing()
        {
            int sizeAfterMethodInvoking = 0;
            DataRepository repo = new DataRepository();
            Predicate<Renting> condition = new Predicate<Renting>(x => true);
            Assert.AreEqual(sizeAfterMethodInvoking, repo.FilterRentings(condition).Count);
        }

        [TestMethod]
        public void FilterRentings_AlwaysFalseCondition_ReturnsNothing()
        {
            int sizeAfterMethodInvoking = 0;
            DataRepository repo = new DataRepository();
            Predicate<Renting> condition = new Predicate<Renting>(x => false);
            Reader reader = new Reader("Ala", "Makota", 122318);
            DateTime date = new DateTime(1987, 04, 23);
            Author author = new Author("asoiajs", "aosdaus");
            Book book = new Book("sdjsa", author, 1987, "asdaus", 12877);
            Renting renting = new Renting(reader, book, date);
            repo.AddRenting(renting);
            Assert.AreEqual(sizeAfterMethodInvoking, repo.FilterRentings(condition).Count);
        }

        [TestMethod]
        public void FilterRentings_ConditionWithSingleRenting_ReturnsThisRentingFromDictionary()
        {
            int sizeAfterMethodInvoking = 1;
            DataRepository repo = new DataRepository();
            Reader reader = new Reader("Ala", "Makota", 122318);
            DateTime date = new DateTime(1987, 04, 23);
            Author author = new Author("asoiajs", "aosdaus");
            Book book = new Book("sdjsa", author, 1987, "asdaus", 12877);
            Renting importantRenting = new Renting(reader, book, date);
            Renting renting = new Renting(reader, book, date);
            Predicate<Renting> condition = new Predicate<Renting>(x => x == importantRenting);
            repo.AddRenting(importantRenting);
            repo.AddRenting(renting);
            Assert.AreEqual(sizeAfterMethodInvoking, repo.FilterRentings(condition).Count);
        }
    }
}
