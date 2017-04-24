using System;

namespace Library
{
    public class Book : IComparable<Book>
    {
        public string Title { get; set; }
        public Author Author { get; set; }
        public uint YearOfRelease { get; set; }
        public string Publisher { get; set; }
        public uint Id { get; set; }

        public Book(string title, Author author, uint yearOfRelease, string publisher, uint id)
        {
            Title = title;
            Author = author;
            YearOfRelease = yearOfRelease;
            Publisher = publisher;
            Id = id;
        }

        public override string ToString()
        {
            return Title + " " + Author.ToString() + " " + YearOfRelease + " " + Publisher
                   + " " + Id;
        }

        public int CompareTo(Book other)
        {
            int authorCompare = this.Author.CompareTo(other.Author);
            if (authorCompare != 0)
            {
                return authorCompare;
            }
            else
            {
                return this.Title.CompareTo(other.Title);
            }
        }

    }
}
