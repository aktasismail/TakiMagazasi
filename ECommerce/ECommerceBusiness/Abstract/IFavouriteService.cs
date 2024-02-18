using ECommerceEntities;

namespace ECommerceBusiness.Abstract
{
    public interface IFavouriteService : IRepositoryService<Favourite>
    {
        Task<List<Favourite>> TGetByNumber(int id);
    }
}
