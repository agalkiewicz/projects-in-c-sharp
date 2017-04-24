using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Database.Filters.Tests
{
    abstract public class FiltersTests
    {
        protected IFilters filters;

        abstract protected void setFilters();

        [TestInitialize()]
        public void init()
        {
            this.setFilters();
        }

        [TestMethod()]
        public void GetProductNamesByVendorName_ValidMethod_ReturnsValidString()
        {
            List<string> list = new List<string>();
            list.Add("Thin - Jam Lock Nut 9");
            list.Add("Thin - Jam Lock Nut 10");
            list.Add("Thin - Jam Lock Nut 1");
            list.Add("Thin - Jam Lock Nut 2");
            list.Add("Thin - Jam Lock Nut 15");
            list.Add("Thin - Jam Lock Nut 16");
            list.Add("Thin - Jam Lock Nut 5");
            list.Add("Thin - Jam Lock Nut 6");
            list.Add("Thin - Jam Lock Nut 3");
            list.Add("Thin - Jam Lock Nut 4");
            list.Add("Thin - Jam Lock Nut 13");
            list.Add("Thin - Jam Lock Nut 14");
            list.Add("Thin - Jam Lock Nut 7");
            list.Add("Thin - Jam Lock Nut 8");
            list.Add("Thin - Jam Lock Nut 12");
            list.Add("Thin - Jam Lock Nut 11");

            Assert.AreSame(list.ToString(), filters.GetProductNamesByVendorName("Australia Bike Retailer").ToString());
        }
    }
}
