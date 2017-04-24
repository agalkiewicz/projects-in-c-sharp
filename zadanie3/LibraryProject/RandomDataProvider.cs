using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class RandomDataProvider : IDataProvider
    {
        uint BookCount { get; set; }
        uint ReaderCount { get; set; }
        uint RentingCount { get; set; }

        private Random random;

        public RandomDataProvider(uint bookCount, uint readerCount, uint rentingCount)
        {
            BookCount = bookCount;
            ReaderCount = readerCount;
            RentingCount = rentingCount;

            random = new Random();
        }

        public void Fill(DataRepository dataRepository)
        {
            FillWithBooks(dataRepository);
            FillWithReaders(dataRepository);

            if (
                dataRepository.ReadAllBooks().Count > 0
                && dataRepository.ReadAllReaders().Count > 0
            ) {
                FillWithRentings(dataRepository);
            }
        }

        private void FillWithBooks(DataRepository dataRepository)
        { 

            uint authorsCount = BookCount / 3 + 1;
            uint publishersCount = BookCount / 4 + 1;

            List<Author> authors = new List<Author>();
            for (uint i = 0 ; i < authorsCount; ++i)
            {
                authors.Add(new Author(getRandomWord(5, 10), getRandomWord(3, 12)));
            }

            List<string> publishers = new List<string>();
            for (uint i = 0; i < publishersCount; ++i)
            {
                publishers.Add(getRandomWord(3, 6));
            }


            for (uint i = 0; i < BookCount; ++i)
            {
                Author author = authors.ElementAt(random.Next((int)authorsCount));
                string publisher = publishers.ElementAt(random.Next((int)publishersCount));
                uint year = (uint) random.Next(1900, 2015);

                Book book = new Book(GetRandomTitle(4), author, year, publisher, i);
                dataRepository.AddBook(book);
            }
            
        }

        private void FillWithReaders(DataRepository dataRepository)
        {
            for (uint i = 0; i < ReaderCount; ++i)
            {
                Reader reader = new Reader(getRandomWord(5, 10), getRandomWord(3, 12), i);
                dataRepository.AddReader(reader);
            }
        }

        private void FillWithRentings(DataRepository dataRepository)
        {
            int books = dataRepository.ReadAllBooks().Count;
            int readers = dataRepository.ReadAllReaders().Count;
            for (uint i = 0; i < RentingCount; ++i)
            {
                Book book = dataRepository.GetBook((uint)random.Next(books));
                Reader reader = dataRepository.GetReader(random.Next(readers));
                DateTime date = DateTime.Now.AddDays(-random.Next(365 * 5));
                Renting renting = new Renting(reader, book, date);
                dataRepository.AddRenting(renting);
            }
        }

        private string GetRandomTitle(int maxWords)
        {
            int wordsCount = random.Next(maxWords);
            string title = "";
            for (int i = 0; i < wordsCount; ++i)
            {
                title += getRandomWord(2, 10) + " ";
            }
            return title.TrimEnd(' ');
        }

        private string getRandomWord(int min, int max)
        {
            int letterCount = 'Z' - 'A';

            int length = random.Next(min-1, max-1);
            string word = "";

            word += (char)('A' + random.Next(0, letterCount));

            for (int i = 0; i < length; i++)
            {
                word += (char)('a' + random.Next(0, letterCount));
            }

            return word;
            
        }

    }
}
