using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Filters.Tests
{
    abstract public class FiltersTests
    {
        protected IFilters filters;
        protected DataRepository repository;

        abstract protected void setFilters();

        [TestInitialize()]
        public void init()
        {
            Reader reader1 = new Reader("Jan", "Kowalski", 1);
            Reader reader2 = new Reader("Jan", "Nowak", 2);
            Reader reader3 = new Reader("Adam", "Kowalski", 3);
            Author author = new Author("Adam", "Bąk");
            Book book1 = new Book("Książka1", author, 2001, "pub", 1);
            Book book2 = new Book("Książka2", author, 2004, "pub", 2);
            Book book3 = new Book("Książka3", author, 2005, "pub", 3);
            Book book4 = new Book("Książka3", author, 2010, "pub", 4);
            Renting renting1 = new Renting(reader1, book1, new DateTime(2014, 1, 1));
            Renting renting2 = new Renting(reader1, book1, new DateTime(2014, 1, 21));
            Renting renting3 = new Renting(reader2, book1, new DateTime(2014, 2, 4));

            repository = new DataRepository();
            repository.AddReader(reader1);
            repository.AddReader(reader2);
            repository.AddReader(reader3);
            repository.AddBook(book1);
            repository.AddBook(book2);
            repository.AddBook(book3);
            repository.AddBook(book4);
            repository.AddRenting(renting1);
            repository.AddRenting(renting2);
            repository.AddRenting(renting3);

            this.setFilters();
        }

        private void GetBooksWithSpecifiedTitleTest_GetBookN_CountN
            (string title, int count)
        {
            List<Book> found = filters.GetBooksWithSpecifiedTitle(
                list: repository.ReadAllBooks().Values.ToList(),
                title: title
                );
            Assert.AreEqual(count, found.Count);
        }

        [TestMethod()]
        public void GetBooksWithSpecifiedTitleTest_GetBook1_Count1()
        {
            GetBooksWithSpecifiedTitleTest_GetBookN_CountN("Książka1", 1);
        }

        [TestMethod()]
        public void GetBooksWithSpecifiedTitleTest_GetBook3_Count2()
        {
            GetBooksWithSpecifiedTitleTest_GetBookN_CountN("Książka3", 2);
        }

        [TestMethod()]
        public void GetBooksWithSpecifiedTitleTest_GetBook5_Count0()
        {
            GetBooksWithSpecifiedTitleTest_GetBookN_CountN("Książka5", 0);
        }

        private void GetBooksWithSpecifiedIssueYearTest_BetweenXandY_CountN
            (int minYear, int maxYear, int count)
        {
            List<Book> found = filters.GetBooksWithSpecifiedIssueYear(
               list: repository.ReadAllBooks().Values.ToList(),
               minYear: minYear,
               maxYear: maxYear
               );
            Assert.AreEqual(count, found.Count);
        }

        [TestMethod()]
        public void GetBooksWithSpecifiedIssueYearTest_Between1000and3000_Count4()
        {
            GetBooksWithSpecifiedIssueYearTest_BetweenXandY_CountN(1000, 3000, 4);
        }

        [TestMethod()]
        public void GetBooksWithSpecifiedIssueYearTest_Between2002and2006_Count2()
        {
            GetBooksWithSpecifiedIssueYearTest_BetweenXandY_CountN(2002, 2006, 2);
        }

        [TestMethod()]
        public void GetBooksWithSpecifiedIssueYearTest_Between2004and2006_Count2()
        {
            GetBooksWithSpecifiedIssueYearTest_BetweenXandY_CountN(2004, 2006, 2);
        }

        [TestMethod()]
        public void GetBooksWithSpecifiedIssueYearTest_Between2008and2010_Count1()
        {
            GetBooksWithSpecifiedIssueYearTest_BetweenXandY_CountN(2008, 2010, 1);
        }

        [TestMethod()]
        public void GetAllAuthorsTest()
        {
            Author expectedAuthor = repository.GetBook(1).Author;
            Author actualAuthor = 
                filters
                .GetAllAuthors(repository.ReadAllBooks().Values.ToList())
                .First();

            Assert.AreEqual<Author>(expectedAuthor, actualAuthor);
        }

        [TestMethod()]
        public void CompareListsTest()
        {
            List<Book> list1 = repository.ReadAllBooks().Values.ToList();

            List<Book> list2 = new List<Book>();
            Author author = new Author("Adam", "Bąk");
            Book book = new Book("Książka11", author, 2016, "pub", 100);
            list2.Add(book);

            List<Tuple<Book, Book>> pairs = filters.CompareLists(list1, list2);

            Assert.AreEqual(1, pairs.Count);
            Assert.AreEqual<Book>(book, pairs.First().Item2);
        }

        [TestMethod()]
        public void GetMinElementTest()
        {
            Book expectedBook = repository.GetBook(1);
            List<Book> list = repository.ReadAllBooks().Values.ToList();
            Book actualBook = filters.GetMinElement(list);
            Assert.AreEqual<Book>(expectedBook, actualBook);
        }

        [TestMethod()]
        public void GetReadersWithRentingsTest()
        {
            List<Renting> list = repository.ReadAllRentings().ToList();
            Reader[] readers = filters.GetReadersWithRentings(list);
            Assert.AreEqual(2, readers.Length);
        }

        [TestMethod()]
        public void GetDistinctRentingsTest()
        {
            List<Renting> list = repository.ReadAllRentings().ToList();
            List<Renting> distinctRentings = filters.GetDistinctRentings(list);
            Assert.AreEqual(2, distinctRentings.Count);
        }

        private void GetBooksWithSpecifiedIssueYearAsBookInfoTest_BetweenXandY_CountN
            (int minYear, int maxYear, int count)
        {
            List<BookInfo> found = filters.GetBooksWithSpecifiedIssueYearAsBookInfo(
               list: repository.ReadAllBooks().Values.ToList(),
               minYear: minYear,
               maxYear: maxYear
               );
            Assert.AreEqual(count, found.Count);
        }

        [TestMethod()]
        public void GetBooksWithSpecifiedIssueYearAsBookInfoTest_Between1000and3000_Count4()
        {
            GetBooksWithSpecifiedIssueYearAsBookInfoTest_BetweenXandY_CountN(1000, 3000, 4);
        }

        [TestMethod()]
        public void GetBooksWithSpecifiedIssueYearAsBookInfoTest_Between2002and2006_Count2()
        {
            GetBooksWithSpecifiedIssueYearAsBookInfoTest_BetweenXandY_CountN(2002, 2006, 2);
        }

        [TestMethod()]
        public void GetBooksWithSpecifiedIssueYearAsBookInfoTest_Between2004and2006_Count2()
        {
            GetBooksWithSpecifiedIssueYearAsBookInfoTest_BetweenXandY_CountN(2004, 2006, 2);
        }

        [TestMethod()]
        public void GetBooksWithSpecifiedIssueYearAsBookInfoTest_Between2008and2010_Count1()
        {
            GetBooksWithSpecifiedIssueYearAsBookInfoTest_BetweenXandY_CountN(2008, 2010, 1);
        }
        
        [TestMethod()]
        private void GetBooksWithSpecifiedIssueYearAsBookInfoTest_Between2010and2011_CheckTitleAndYear
            (int minYear, int maxYear, int count)
        {
            List<BookInfo> found = filters.GetBooksWithSpecifiedIssueYearAsBookInfo(
               list: repository.ReadAllBooks().Values.ToList(),
               minYear: 2010,
               maxYear: 2011
               );
            BookInfo info = found.First();

            Assert.AreEqual(2010, info.Year);
            Assert.AreEqual("Książka3", info.Title);
        }
    }
}