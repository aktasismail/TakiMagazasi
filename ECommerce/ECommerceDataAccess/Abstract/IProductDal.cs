using ECommerceEntities;

namespace ECommerceDataAccess.Abstract
{
    public interface IProductDal: IRepository<Product>
    {
        List<Product> GetProductsWithCategories();
        int ProductCount();
        decimal ProductPriceAvg();
        string ProductNameByMaxPrice();
        string ProductNameByMinPrice();
        

    }
}
