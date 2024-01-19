using ECommerceDataAccess.Abstract;
using ECommerceDataAccess.Data;
using ECommerceEntities;

namespace ECommerceDataAccess.Concrete
{
    public class CategoryDal : Repository<Category>, ICategoryDal
    {
        public CategoryDal(AppDbContext context) : base(context)
        {
        }

    }
}
