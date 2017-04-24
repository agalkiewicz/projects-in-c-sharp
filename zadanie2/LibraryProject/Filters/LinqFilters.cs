using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Filters
{
    public class LinqFilters : IFilters
    { 
        public List<Book> GetBooksWithSpecifiedTitle(List<Book> list, string title)
        {
            return
                (
                from book in list
                where book.Title == title
                select book
                ).ToList();
        }

        public List<Book> GetBooksWithSpecifiedIssueYear
            (List<Book> list, int minYear, int maxYear)
        {
            return
                (
                from book in list
                where book.YearOfRelease >= minYear 
                   && book.YearOfRelease <= maxYear
                select book
                ).ToList();
        }

        public List<Author> GetAllAuthors(List<Book> list)
        {
            return
                (
                from book in list
                select book.Author
                ).ToList();
        }

        public List<Tuple<Book,Book>> CompareLists(List<Book> list1, List<Book> list2)
        {
            return
                (
                from book1 in list1
                from book2 in list2
                where book1.CompareTo(book2) < 0
                select new Tuple<Book, Book>(book1, book2)
                ).ToList();
        }

        public Book GetMinElement(List<Book> list)
        {
            return
                (
                from book in list
                orderby book ascending
                select book
                )
                .First();
        }

        public Reader[] GetReadersWithRentings(List<Renting> list)
        {
            return
                (
                from renting in list
                select renting.ReaderWhoRented
                ).Distinct().ToArray();
        }

        public List<Renting> GetDistinctRentings(List<Renting> list)
        { 
            return
                (
                from renting in list
                group renting 
                    by new { renting.ReaderWhoRented, renting.RentalBook } 
                    into rentingGroup
                select rentingGroup.First()
                ).ToList();
        }

        public List<BookInfo> GetBooksWithSpecifiedIssueYearAsBookInfo
            (List<Book> list, int minYear, int maxYear)
        {
            return
                (
                from book in list
                where book.YearOfRelease >= minYear
                   && book.YearOfRelease <= maxYear
                select new BookInfo { Title = book.Title, Year = book.YearOfRelease }
                ).ToList();
        }
    }
}
