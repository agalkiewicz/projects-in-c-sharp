using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Library.Tests
{
    [TestClass]
    public class RandomDataProviderTests
    {

        [TestMethod]
        public void RandomDataProvider_Fill()
        {
            IDataProvider provider = new RandomDataProvider(10, 20, 30);
            DataRepository dataRepository = new DataRepository(provider);

            Assert.AreEqual(10, dataRepository.ReadAllBooks().Count);
            Assert.AreEqual(20, dataRepository.ReadAllReaders().Count);
            Assert.AreEqual(30, dataRepository.ReadAllRentings().Count);
        }

        [TestMethod]
        public void RandomDataProvider_AuthorAndPublisherHaveManyBooks()
        {
            RandomDataProvider provider = new RandomDataProvider(20, 0, 0);
            DataRepository dataRepository = new DataRepository(provider);
            Dictionary<uint, Book> books = dataRepository.ReadAllBooks();

            List<string> publishers = new List<string>();
            List<Author> authors = new List<Author>();
            foreach (Book book in books.Values)
            {
                publishers.Add(book.Publisher);
                authors.Add(book.Author);
            }

            Assert.AreNotEqual(books.Count, publishers.Distinct().Count());
            Assert.AreNotEqual(books.Count, authors.Distinct().Count());
        } 
    }
}