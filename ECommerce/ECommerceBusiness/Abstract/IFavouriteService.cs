using ECommerceEntities;

namespace ECommerceBusiness.Abstract
{
    public interface IFavouriteService : IRepositoryService<Favourite>
    {
        List<Favourite> TGetByNumber(int id);
    }
}
