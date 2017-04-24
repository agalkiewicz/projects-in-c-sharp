using System.Collections.Generic;

namespace Database.Filters
{
    public interface IFilters
    {
        DataClassesDataContext GetDataContext();
        List<Product> GetNRecentlyReviewedProducts(int howManyProducts);
        List<Product> GetNSortedProducts(int howManyProducts);
        List<string> GetProductNamesByVendorName(string vendorName);
        List<Product> GetRecentlyReviewedProducts(int howManyReviews);
        decimal GetTotalStandardCostByCategory(ProductCategory category);
    }
}