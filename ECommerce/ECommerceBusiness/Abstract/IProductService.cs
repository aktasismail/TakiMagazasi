using ECommerceEntities;

namespace ECommerceBusiness.Abstract
{
    public interface IProductService: IRepositoryService<Product>
    {
        List<Product> TGetProductsWithCategories();
        IEnumerable<Product> ProductByCategory(int id);
        int TProductCount();
        decimal TProductPriceAvg();
        string TProductNameByMaxPrice();
        string TProductNameByMinPrice();
    }
}
