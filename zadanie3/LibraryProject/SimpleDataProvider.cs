using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class SimpleDataProvider : IDataProvider
    {
        public void Fill(DataRepository repository)
        {
            Reader reader1 = new Reader("Jan", "Kowalski", 1);
            Reader reader2 = new Reader("Jan", "Nowak", 2);
            Reader reader3 = new Reader("Adam", "Kowalski", 3);
            Author author = new Author("Adam", "Bąk");
            Book book1 = new Book("Książka1", author, 2000, "pub", 1);
            Book book2 = new Book("Książka2", author, 2000, "pub", 2);
            Book book3 = new Book("Książka3", author, 2000, "pub", 3);
            Renting renting1 = new Renting(reader1, book1, new DateTime(2014, 1, 1));
            Renting renting2 = new Renting(reader1, book1, new DateTime(2014, 1, 21));
            Renting renting3 = new Renting(reader2, book1, new DateTime(2014, 2, 4));

            repository.AddReader(reader1);
            repository.AddReader(reader2);
            repository.AddReader(reader3);
            repository.AddBook(book1);
            repository.AddBook(book2);
            repository.AddBook(book3);
            repository.AddRenting(renting1);
            repository.AddRenting(renting2);
            repository.AddRenting(renting3);
        }
    }
}
