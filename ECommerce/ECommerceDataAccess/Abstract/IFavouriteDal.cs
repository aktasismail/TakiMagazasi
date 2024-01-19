using ECommerceDataAccess.Concrete;
using ECommerceEntities;

namespace ECommerceDataAccess.Abstract
{
    public interface IFavouriteDal : IRepository<Favourite>
    {
        List<Favourite> GetByNumber(int id);
    }
}
