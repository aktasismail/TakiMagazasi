using ECommerceDataAccess.Abstract;
using ECommerceDataAccess.Data;
using ECommerceEntities;
using Microsoft.EntityFrameworkCore;

namespace ECommerceDataAccess.Concrete
{
    public class ProductDal : Repository<Product>, IProductDal
    {
        public ProductDal(AppDbContext context) : base(context)
        {
        }

        public List<Product> GetProductsWithCategories()
        {
            var context = new AppDbContext();
            var values = context.Products.Include(x => x.Category).ToList();
            return values;
        }

        public int ProductCount()
        {
            using var context = new AppDbContext();
            return context.Products.Count();
        }
        public string ProductNameByMaxPrice()
        {
            using var context = new AppDbContext();
            return context.Products.Where(x => x.Price == (context.Products.Max(y => y.Price))).Select(z => z.ProductName).FirstOrDefault();
        }

        public string ProductNameByMinPrice()
        {
            using var context = new AppDbContext();
            return context.Products.Where(x => x.Price == (context.Products.Min(y => y.Price))).Select(z => z.ProductName).FirstOrDefault();
        }

        public decimal ProductPriceAvg()
        {
            using var context = new AppDbContext();
            return context.Products.Average(x=> x.Price);
        }
    }
}
