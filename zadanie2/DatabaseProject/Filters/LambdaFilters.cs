using System.Collections.Generic;
using System.Linq;

namespace Database.Filters
{
    public class LambdaFilters : IFilters
    {
        private DataClassesDataContext db;

        public LambdaFilters()
        {
            db = new DataClassesDataContext();
        }

        public DataClassesDataContext GetDataContext()
        {
            return db;
        }

        public List<string> GetProductNamesByVendorName(string vendorName)
        {
            var products = db.ProductVendors.Where(x => x.Vendor.Name == vendorName)
                .Select(x => x.Product.Name);
            return products.ToList();
        }

        public List<Product> GetRecentlyReviewedProducts(int howManyReviews)
        {
            var products = db.ProductReviews.OrderByDescending(a => a.ReviewDate)
                .Select(x => x.Product).Take(howManyReviews).Distinct();
            return products.ToList();
        }

        public List<Product> GetNRecentlyReviewedProducts(int howManyProducts)
        {
            var products = db.ProductReviews.OrderByDescending(a => a.ReviewDate)
                .Select(x => x.Product).Distinct().Take(howManyProducts);
            return products.ToList();
        }

        public List<Product> GetNSortedProducts(int howManyProducts)
        {
            var products = db.Products.OrderBy(p => p.ProductSubcategory.ProductCategory.Name)
                .ThenBy(p => p.Name).Select(p => p).Take(howManyProducts);
            return products.ToList();
        }

        public decimal GetTotalStandardCostByCategory(ProductCategory category)
        {
            var cost = db.Products.Where(p => p.ProductSubcategory.ProductCategory == category)
                .Select(p => p.StandardCost).Sum();
            return cost;
        }
    }
}
