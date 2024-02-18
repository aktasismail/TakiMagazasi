using ECommerceDataAccess.Concrete;
using ECommerceEntities;

namespace ECommerceDataAccess.Abstract
{
    public interface IFavouriteDal : IRepository<Favourite>
    {
        Task<List<Favourite>> GetByNumber(int id);
    }
}
