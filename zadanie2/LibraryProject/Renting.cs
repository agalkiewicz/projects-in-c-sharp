using System;
namespace Library
{
    public class Renting
    {
        public Reader ReaderWhoRented { get; }
        public Book RentalBook { get; }
        public DateTime DateOfRenting { get; }
        public DateTime DateOfReturn { get; }

        public Renting(Reader readerWhoRented, Book rentalBook, DateTime dateOfRenting)
        {
            ReaderWhoRented = readerWhoRented;
            RentalBook = rentalBook;
            DateOfRenting = dateOfRenting;
            DateOfReturn = DateOfRenting.AddMonths(3);
        }

        public override string ToString()
        {
            return ReaderWhoRented.ToString() + " " + RentalBook.ToString() + " " +
                   DateOfRenting.ToString() + " " + DateOfReturn.ToString();
        }
    }
}
