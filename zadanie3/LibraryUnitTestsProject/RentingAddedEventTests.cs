using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Library.Tests
{
    [TestClass]
    public class RentingAddedEventTests
    {
        private Renting rentingToAdd;
        private DataService dataService;
        private int invokedCounter = 0;
        
        public void prepare()
        {
            dataService = new DataService(new DataRepository());
            dataService.RentingAdded += 
                new RentingAddedEventHandler(this.testEventHandler);

            Reader reader = new Reader("Jan", "Nowak", 1);
            Author author = new Author("Adam", "Kowalski");
            Book book = new Book("Książka", author, 2000, "pub", 1);
            dataService.AddBook(book);
            dataService.AddReader(reader);

            rentingToAdd = new Renting(reader, book, DateTime.Now);
        }

        [TestMethod]
        public void RentingAddedEventTest()
        {
            prepare();
            dataService.AddRenting(rentingToAdd);
            Assert.AreEqual(1, invokedCounter);
        }

        private void testEventHandler(DataService sender, RentingAddedEventArgs e)
        {
            Assert.AreEqual<Renting>(rentingToAdd, e.Renting);
            invokedCounter++;
        }
    }
}
