using ECommerceEntities;
using ECommerceEntities.Dto.CreateDto;

namespace ECommerceBusiness.Abstract
{
    public interface IProductService: IRepositoryService<Product>
    {
        Task<List<Product>> TGetProductsWithCategories();
        Task<IEnumerable<Product>> ProductByCategory(int id);
        Task Add(ProductCreateDto productCreateDto);
    }
}
