using ECommerceEntities;

namespace ECommerceBusiness.Abstract
{
    public interface ICategoryService: IRepositoryService<Category>
    {
        int TCategoryCount();
        Task<Category> GetCategoryByName(string categoryName);
        Task<List<Category>> GetCategoryForFooter();
    }
}
