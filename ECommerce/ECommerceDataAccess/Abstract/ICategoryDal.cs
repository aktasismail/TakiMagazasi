using ECommerceEntities;

namespace ECommerceDataAccess.Abstract
{
    public interface ICategoryDal : IRepository<Category>
    {
        int CategoryCount();
        IQueryable<Category> GetAllUrls();
    }
}
