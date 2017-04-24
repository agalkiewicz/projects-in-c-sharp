using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Library.Filters.Tests
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
