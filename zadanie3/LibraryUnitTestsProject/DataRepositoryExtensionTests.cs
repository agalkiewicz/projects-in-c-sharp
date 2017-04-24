using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Tests
{
    [TestClass()]
    public class DataRepositoryExtensionTests
    {
        [TestMethod()]
        public void GetReadersWithMostRentingsTest_Count2()
        {
            DataRepository repository = 
                new DataRepository(new SimpleDataProvider());

            IEnumerable<Reader> readers = repository.GetReadersWithMostRentings(2);
            Assert.AreEqual(2, readers.Count());
        }

        [TestMethod()]
        public void GetReadersWithMostRentingsTest_Count1()
        {
            DataRepository repository =
                new DataRepository(new SimpleDataProvider());

            IEnumerable<Reader> readers = repository.GetReadersWithMostRentings(1);
            Assert.AreEqual(1, readers.Count());
            Assert.AreEqual(1u, readers.First().IdNumber);
        }

        [TestMethod()]
        public void ChunkReadersTest_ChunkSize10_ArrayLenght10()
        {
            DataRepository repository =
                new DataRepository(new RandomDataProvider(0, 100, 0));
            IEnumerable<Reader>[] chunks = repository.ChunkReaders(10);
            Assert.AreEqual(10, chunks.Length);
        }

        [TestMethod()]
        public void ChunkReadersTest_ReadersCount98_LastElementCount8()
        {
            DataRepository repository =
                new DataRepository(new RandomDataProvider(0, 98, 0));
            IEnumerable<Reader>[] chunks = repository.ChunkReaders(10);
            Assert.AreEqual(8, chunks.Last().Count());
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ChunkReadersTest_ChunkSize0_ArgumentOutOfRangeException()
        {
            DataRepository repository =
                new DataRepository(new RandomDataProvider(0, 98, 0));
            repository.ChunkReaders(0);

        }

        [TestMethod()]
        public void GetNeverRentedBooksTest()
        {
            DataRepository repository =
                new DataRepository(new SimpleDataProvider());
            int neverRentedCount = repository.GetNeverRentedBooks().Count();

            Assert.AreEqual(2, neverRentedCount);
        }
    }
}