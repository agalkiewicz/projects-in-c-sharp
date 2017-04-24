using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Database.Filters.Tests
{
    [TestClass]
    public class LinqFiltersTests : FiltersTests
    {
        protected override void setFilters()
        {
            filters = new LinqFilters();
        }
    }
}
