using ECommerceDataAccess.Abstract;
using ECommerceDataAccess.Data;
using ECommerceEntities;
using System;

namespace ECommerceDataAccess.Concrete
{
    public class CategoryDal : Repository<Category>, ICategoryDal
    {
        public CategoryDal(AppDbContext context) : base(context)
        {

        }
        public int CategoryCount()
        {
            using var context = new AppDbContext();
            return context.Categories.Count();
        }
        public IQueryable<Category> GetAllUrls()
        {
            using var context = new AppDbContext();
            return context.Categories.AsQueryable();
        }
    }
}
