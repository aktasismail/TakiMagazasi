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

        public async Task<List<Product>> GetProductsWithCategories()
        {
            var context = new AppDbContext();
            var values =  context.Products.Include(x => x.Category).ToList();
            return values;
        }
    }
}
