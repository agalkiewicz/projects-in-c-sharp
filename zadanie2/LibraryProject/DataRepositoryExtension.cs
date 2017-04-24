using System;
using System.Collections.Generic;
using System.Linq;

namespace Library
{
    public static class DataRepositoryExtension
    {
        public static IEnumerable<Reader> GetReadersWithMostRentings
            (this DataRepository repo, int maxCount)
        {
            return
                (
                    from reader in repo.ReadAllReaders()
                    join renting in repo.ReadAllRentings()
                        on reader equals renting.ReaderWhoRented
                        into joined
                    orderby joined.Count() descending
                    select reader
                )
                .Take(maxCount);

        }

        public static IEnumerable<Reader>[] ChunkReaders
            (this DataRepository repo, int size)
        {
            if (size < 1) throw new ArgumentOutOfRangeException("size",
                "The size must be a positive number.");

            ICollection<Reader> readers = repo.ReadAllReaders();
            int length = (int) Math.Ceiling((decimal)(readers.Count) / size);
            IEnumerable<Reader>[] result = new IEnumerable<Reader>[length];

            for (int i = 0; i < length; ++i)
            {
                result[i] = readers.Skip(size*i).Take(size);
            }
            return result;
        }

        public static IEnumerable<Book> GetNeverRentedBooks(this DataRepository repo)
        {
            return
                (
                    from book in repo.ReadAllBooks().Values
                    join renting in repo.ReadAllRentings()
                        on book equals renting.RentalBook
                        into rentings
                    where rentings.Count() == 0
                    select book
                );
        }

    }
}
