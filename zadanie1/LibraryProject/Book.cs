namespace Library
{
    public class Book
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
    }
}
