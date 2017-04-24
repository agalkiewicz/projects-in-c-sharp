using System;
using System.Collections.Generic;

namespace Library.Filters
{
    public interface IFilters
    {
        List<Tuple<Book, Book>> CompareLists(List<Book> list1, List<Book> list2);
        List<Author> GetAllAuthors(List<Book> list);
        List<Book> GetBooksWithSpecifiedIssueYear(List<Book> list, int minYear, int maxYear);
        List<BookInfo> GetBooksWithSpecifiedIssueYearAsBookInfo(List<Book> list, int minYear, int maxYear);
        List<Book> GetBooksWithSpecifiedTitle(List<Book> list, string title);
        List<Renting> GetDistinctRentings(List<Renting> list);
        Book GetMinElement(List<Book> list);
        Reader[] GetReadersWithRentings(List<Renting> list);
    }
}