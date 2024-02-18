using ECommerceEntities;

namespace ECommerceDataAccess.Abstract
{
    public interface IProductDal: IRepository<Product>
    {
        Task<List<Product>> GetProductsWithCategories();
    }
}
