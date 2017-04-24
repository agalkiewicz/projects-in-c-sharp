using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Library
{
    public delegate void RentingAddedEventHandler
        (DataService sender, RentingAddedEventArgs e);

    public class RentingAddedEventArgs : EventArgs
    {
        public Renting Renting { get; }

        public RentingAddedEventArgs(Renting renting)
        {
            Renting = renting;
        }
    }

    public class DataService
    {
        private DataRepository repository;

        public event RentingAddedEventHandler RentingAdded;

        public DataService(DataRepository dataRepository)
        {
            this.repository = dataRepository;

            NotifyCollectionChangedEventHandler handler;
            handler = new NotifyCollectionChangedEventHandler
                (this.rentingsCollectionChanged);
            repository.ReadAllRentings().CollectionChanged += handler;
        }

        public ICollection<Book> GetAllBooks()
        {
            return repository.ReadAllBooks().Values;
        }

        public ICollection<Reader> GetAllReaders()
        {
            return repository.ReadAllReaders();
        }

        public ICollection<Renting> GetAllRentings()
        {
            return repository.ReadAllRentings();
        }

        public ICollection<Renting> GetRentingsOfReader(Reader reader)
        {
            return repository.FilterRentings(x => x.ReaderWhoRented == reader);
        }

        public void AddBook(Book book)
        {
            repository.AddBook(book);
        }

        public void AddReader(Reader reader)
        {
            repository.AddReader(reader);
        }

        public void AddRenting(Renting renting)
        {
            repository.AddRenting(renting);
        }

        public void DeleteBook(Book book)
        {
            repository.DeleteBook(book.Id);
        }

        public void DeleteReader(Reader reader)
        {
            repository.DeleteReader(reader);
        }

        public void DeleteRenting(Renting renting)
        {
            repository.DeleteRenting(renting);
        }

        private void rentingsCollectionChanged
            (object sender, NotifyCollectionChangedEventArgs e)
        {
            if (
                RentingAdded != null &&
                e.Action == NotifyCollectionChangedAction.Add
                )
            {
                foreach (object addedObject in e.NewItems ) {
                    Renting renting = addedObject as Renting;
                    if (renting != null)
                        RentingAdded(this, new RentingAddedEventArgs(renting));
                }
            }
        }

    } // end class DataService
}
