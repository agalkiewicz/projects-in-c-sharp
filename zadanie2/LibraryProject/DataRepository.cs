using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Library
{
    public class DataRepository
    {
        private List<Reader> readers;
        private Dictionary<uint, Book> books;
        private ObservableCollection<Renting> rentings;

        private IDataProvider dataProvider;
        
        public DataRepository(IDataProvider provider = null)
        {
            readers = new List<Reader>();
            books = new Dictionary<uint, Book>();
            rentings = new ObservableCollection<Renting>();
            dataProvider = provider ?? new NullDataProvider();

            dataProvider.Fill(this);
        }

        public void AddReader(Reader newReader)
        {
            if (!readers.Contains(newReader))
                readers.Add(newReader);
        }
        public List<Reader> ReadAllReaders()
        {
            return readers;
        }
        public Reader GetReader(int index)
        {
            return readers[index];
        }
        public void DeleteReader(int index)
        {
            var itemsToRemove = rentings.Where(x => x.ReaderWhoRented == readers[index]).ToList();
            foreach (var itemToRemove in itemsToRemove)
                rentings.Remove(itemToRemove);
            readers.RemoveAt(index);
        }
        public void DeleteReader(Reader readerToDelete)
        {
            if (!readers.Contains(readerToDelete))
                throw new ArgumentException
                ("The object is not in the list. It is not possible to delete it.", "readerToDelete");
            else
            {
                var itemsToRemove = rentings.Where(x => x.ReaderWhoRented == readerToDelete).ToList();
                foreach (var itemToRemove in itemsToRemove)
                    rentings.Remove(itemToRemove);
                readers.Remove(readerToDelete);
            }
        }
        public List<Reader> FilterReaders(Predicate<Reader> condition)
        {
            List<Reader> tmpList = readers.FindAll(condition);
            return tmpList;
        }

        public void AddBook(Book newBook)
        {
            if (!books.ContainsKey(newBook.Id))
                books.Add(newBook.Id, newBook);
        }
        public Dictionary<uint, Book> ReadAllBooks()
        {
            return books;
        }
        public Book GetBook(uint id)
        {
            return books[id];
        }
        public void DeleteBook(uint id)
        {
            if (!books.ContainsKey(id))
                throw new ArgumentException("The book is not in the list. Cannot be deleted.");
            else
            {
                var itemsToRemove = rentings.Where(x => x.RentalBook == books[id]).ToList();
                foreach (var itemToRemove in itemsToRemove)
                    rentings.Remove(itemToRemove);
                books.Remove(id);
            }
                
        }    
        public List<Book> FilterBooks(Predicate<Book> condition)
        {
            List<Book> tmpList = new List<Book>();
            foreach(KeyValuePair<uint, Book> pair in books)
                if (condition(pair.Value))
                    tmpList.Add(pair.Value);
            return tmpList;
        }

        public void AddRenting(Renting newRenting)
        {
            if (!rentings.Contains(newRenting))
                    rentings.Add(newRenting);
        }
        public ObservableCollection<Renting> ReadAllRentings()
        {
            return rentings;
        }
        public Renting GetRenting(int index)
        {
            return rentings[index];
        }
        public void DeleteRenting(int index)
        {
            rentings.RemoveAt(index);
        }
        public void DeleteRenting(Renting rentingToDelete)
        {
            if (!rentings.Contains(rentingToDelete))
                throw new ArgumentException("The object is not in the collection. It is not possible to delete it.", "rentingToDelete");
            else
                rentings.Remove(rentingToDelete);
        }
        public List<Renting> FilterRentings(Predicate<Renting> condition)
        {
            List<Renting> tmpList = new List<Renting>();
            foreach (Renting renting in rentings)
                if (condition(renting))
                    tmpList.Add(renting);
            return tmpList;
        }
    }
}
