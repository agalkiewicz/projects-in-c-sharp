using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Filters
{
    public class LambdaFilters : IFilters
    { 
        public List<Book> GetBooksWithSpecifiedTitle(List<Book> list, string title)
        {
            return list.Where(book => book.Title == title).ToList();
        }

        public List<Book> GetBooksWithSpecifiedIssueYear
            (List<Book> list, int minYear, int maxYear)
        {
            return list.Where(book => 
                book.YearOfRelease >= minYear && book.YearOfRelease <= maxYear
            ).ToList();
        }

        public List<Author> GetAllAuthors(List<Book> list)
        {
            return list.Select(book => book.Author).ToList();
        }

        public List<Tuple<Book, Book>> CompareLists(List<Book> list1, List<Book> list2)
        {
            return list1
                .SelectMany<Book, Book, Tuple<Book, Book>>(
                    book1 => list2,
                    (book1, book2) => new Tuple<Book, Book>(book1, book2)
                )
                .Where(books => books.Item1.CompareTo(books.Item2) < 0)
                .ToList();
        }

        public Book GetMinElement(List<Book> list)
        {
            return list.Min();
        }

        public Reader[] GetReadersWithRentings(List<Renting> list)
        {
            return list.Select(renting => renting.ReaderWhoRented).Distinct().ToArray();
        }

        public List<Renting> GetDistinctRentings(List<Renting> list)
        {
            return list
                .GroupBy(
                    renting => new { renting.ReaderWhoRented, renting.RentalBook }
                )
                .Select(grouping => grouping.First())
                .ToList();
        }

        public List<BookInfo> GetBooksWithSpecifiedIssueYearAsBookInfo
            (List<Book> list, int minYear, int maxYear)
        {
            return list
                .Where(book =>
                    book.YearOfRelease >= minYear && book.YearOfRelease <= maxYear
                )
                .Select(
                    book => new BookInfo { Title = book.Title, Year = book.YearOfRelease }
                )
                .ToList();
        }
    }
}
