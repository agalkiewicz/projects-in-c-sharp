using System.Collections.Generic;
using System.Linq;

namespace Database.Filters
{
    public class LinqFilters : IFilters
    {
        private DataClassesDataContext db;

        public LinqFilters()
        {
            db = new DataClassesDataContext();
        }

        public DataClassesDataContext GetDataContext()
        {
            return db;
        }

        public List<string> GetProductNamesByVendorName(string vendorName)
        {
            var products =
                from pv in db.ProductVendors
                where pv.Vendor.Name == vendorName
                select pv.Product.Name;
            return products.ToList();
        }
        
        public List<Product> GetRecentlyReviewedProducts(int howManyReviews)
        {
            var products =
                (
                from pr in db.ProductReviews
                orderby pr.ReviewDate descending
                select pr.Product
                ).Take(howManyReviews).Distinct();
            return products.ToList();
        }
        
        public List<Product> GetNRecentlyReviewedProducts(int howManyProducts)
        {
            var products =
                (
                from pr in db.ProductReviews
                orderby pr.ReviewDate descending
                select pr.Product
                ).Distinct().Take(howManyProducts);
            return products.ToList();
        }
        
        public List<Product> GetNSortedProducts(int howManyProducts)
        {
            var products =
                (
                from p in db.Products
                orderby p.ProductSubcategory.ProductCategory.Name, p.Name
                select p
                ).Take(howManyProducts);
            return products.ToList();
        }

        
        public decimal GetTotalStandardCostByCategory(ProductCategory category)
        {
            var cost =
                (
                from p in db.Products
                where p.ProductSubcategory.ProductCategory == category
                select p.StandardCost).Sum();
            return cost;

        }
    }
}
