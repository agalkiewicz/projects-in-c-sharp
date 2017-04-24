using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Library.Filters.Tests
{
    [TestClass]
    public class LambdaFiltersTests : FiltersTests
    {
        protected override void setFilters()
        {
            filters = new LambdaFilters();
        }
    }
}
