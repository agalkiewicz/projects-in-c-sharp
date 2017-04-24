using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Library.Tests
{
    [TestClass()]
    public class DataServiceTests
    {
        private DataService dataService;

        [TestInitialize]
        public void prepare()
        {
            dataService = new DataService(new DataRepository());
        }

        [TestMethod()]
        public void GetRentingsOfReader()
        {
            Reader reader1 = new Reader("Jan", "Kowalski", 1);
            Reader reader2 = new Reader("Jan", "Nowak", 2);
            Reader reader3 = new Reader("Adam", "Kowalski", 3);
            Author author = new Author("Adam", "Bąk");
            Book book1 = new Book("Książka 1", author, 2000, "pub", 1);
            Book book2 = new Book("Książka 2", author, 2000, "pub", 2);
            Book book3 = new Book("Książka 3", author, 2000, "pub", 3);

            dataService.AddReader(reader1);
            dataService.AddReader(reader2);
            dataService.AddReader(reader3);
            dataService.AddBook(book1);
            dataService.AddBook(book2);
            dataService.AddBook(book3);

            Renting renting1 = new Renting(reader1, book1, DateTime.Now);
            Renting renting2 = new Renting(reader1, book1, DateTime.Now);
            Renting renting3 = new Renting(reader2, book1, DateTime.Now);

            dataService.AddRenting(renting1);
            dataService.AddRenting(renting2);
            dataService.AddRenting(renting3);

            Assert.AreEqual(2, dataService.GetRentingsOfReader(reader1).Count);
            Assert.AreEqual(1, dataService.GetRentingsOfReader(reader2).Count);
            Assert.AreEqual(0, dataService.GetRentingsOfReader(reader3).Count);

            foreach (Renting renting in dataService.GetRentingsOfReader(reader2))
            {
                Assert.AreEqual<Renting>(renting3, renting);
            }

        }

        [TestMethod()]
        public void AddBookAndGetAllBooks()
        {
            Author author = new Author("Adam", "Bąk");
            Book book1 = new Book("Książka 1", author, 2000, "pub", 1);
            Book book2 = new Book("Książka 2", author, 2001, "pub", 2);

            dataService.AddBook(book1);
            Assert.AreEqual(1, dataService.GetAllBooks().Count);
            foreach (Book book in dataService.GetAllBooks())
            {
                Assert.AreEqual<Book>(book1, book);
            }
            
            dataService.AddBook(book2);
            Assert.AreEqual(2, dataService.GetAllBooks().Count);
        }

        [TestMethod()]
        public void AddReaderAndGetAllReaders()
        {
            Reader reader1 = new Reader("Jan", "Kowalski", 1);
            Reader reader2 = new Reader("Jan", "Nowak", 2);

            dataService.AddReader(reader1);
            Assert.AreEqual(1, dataService.GetAllReaders().Count);
            foreach (Reader reader in dataService.GetAllReaders())
            {
                Assert.AreEqual<Reader>(reader1, reader);
            }

            dataService.AddReader(reader2);
            Assert.AreEqual(2, dataService.GetAllReaders().Count);
        }

        [TestMethod()]
        public void AddRentingAndGetAllRentings()
        {
            Reader reader1 = new Reader("Jan", "Kowalski", 1);
            Reader reader2 = new Reader("Jan", "Nowak", 2);
            Reader reader3 = new Reader("Adam", "Kowalski", 3);
            Author author = new Author("Adam", "Bąk");
            Book book1 = new Book("Książka 1", author, 2000, "pub", 1);
            Book book2 = new Book("Książka 2", author, 2000, "pub", 2);
            Book book3 = new Book("Książka 3", author, 2000, "pub", 3);

            dataService.AddReader(reader1);
            dataService.AddReader(reader2);
            dataService.AddReader(reader3);
            dataService.AddBook(book1);
            dataService.AddBook(book2);
            dataService.AddBook(book3);

            Renting renting1 = new Renting(reader1, book1, DateTime.Now);
            Renting renting2 = new Renting(reader1, book1, DateTime.Now);
            Renting renting3 = new Renting(reader2, book1, DateTime.Now);

            dataService.AddRenting(renting1);
            Assert.AreEqual(1, dataService.GetAllRentings().Count);
            foreach (Renting renting in dataService.GetAllRentings())
            {
                Assert.AreEqual<Renting>(renting1, renting);
            }

            dataService.AddRenting(renting2);
            dataService.AddRenting(renting3);
            Assert.AreEqual(3, dataService.GetAllRentings().Count);
        }

        [TestMethod()]
        public void DeleteBookTest()
        {
            Author author = new Author("Adam", "Bąk");
            Book book1 = new Book("Książka 1", author, 2000, "pub", 1);
            Book book2 = new Book("Książka 2", author, 2001, "pub", 2);
            dataService.AddBook(book1);
            dataService.AddBook(book2);

            int countBeforDelete = dataService.GetAllBooks().Count;
            dataService.DeleteBook(book1);
            Assert.AreEqual(countBeforDelete - 1, dataService.GetAllBooks().Count);
        }

        [TestMethod()]
        public void DeleteReaderTest()
        {
            Reader reader1 = new Reader("Jan", "Kowalski", 1);
            Reader reader2 = new Reader("Jan", "Nowak", 2);
            Reader reader3 = new Reader("Adam", "Kowalski", 3);

            dataService.AddReader(reader1);
            dataService.AddReader(reader2);
            dataService.AddReader(reader3);

            int countBeforDelete = dataService.GetAllReaders().Count;
            dataService.DeleteReader(reader1);
            Assert.AreEqual(countBeforDelete - 1, dataService.GetAllReaders().Count);
        }

        [TestMethod()]
        public void DeleteRentingTest()
        {
            Reader reader1 = new Reader("Jan", "Kowalski", 1);
            Reader reader2 = new Reader("Jan", "Nowak", 2);
            Reader reader3 = new Reader("Adam", "Kowalski", 3);
            Author author = new Author("Adam", "Bąk");
            Book book1 = new Book("Książka 1", author, 2000, "pub", 1);
            Book book2 = new Book("Książka 2", author, 2000, "pub", 2);
            Book book3 = new Book("Książka 3", author, 2000, "pub", 3);

            dataService.AddReader(reader1);
            dataService.AddReader(reader2);
            dataService.AddReader(reader3);
            dataService.AddBook(book1);
            dataService.AddBook(book2);
            dataService.AddBook(book3);

            Renting renting1 = new Renting(reader1, book1, DateTime.Now);
            Renting renting2 = new Renting(reader1, book1, DateTime.Now);

            dataService.AddRenting(renting1);
            dataService.AddRenting(renting2);

            int countBeforDelete = dataService.GetAllRentings().Count;
            dataService.DeleteRenting(renting1);
            Assert.AreEqual(countBeforDelete - 1, dataService.GetAllRentings().Count);

        }
    }
}