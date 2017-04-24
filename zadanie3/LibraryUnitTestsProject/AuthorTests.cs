using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library;
using System;

namespace Library.Tests
{
    [TestClass]
    public class AuthorTests
    {
        [TestMethod]
        public void AuthorEqualsTest()
        {
            Author a1 = new Author("Aa", "Bb");
            Author a2 = new Author("Aa", "Bb");
            Author b = new Author("Aa", "Cc");

            Assert.IsTrue(a1.Equals(a2));
            Assert.IsTrue(a1.Equals(a1));
            Assert.IsFalse(a1.Equals(b));
            Assert.IsFalse(b.Equals(null));
        }

        [TestMethod]
        public void AuthorOperatorTest()
        {
            Author a1 = new Author("Aa", "Bb");
            Author a2 = new Author("Aa", "Bb");
            Author b = new Author("Aa", "Cc");

            Assert.IsTrue(a1 == a2);
            Assert.IsTrue(a1 == a1);
            Assert.IsTrue(a1 != b);
            Assert.IsTrue(a1 != null);
        }

    }
}