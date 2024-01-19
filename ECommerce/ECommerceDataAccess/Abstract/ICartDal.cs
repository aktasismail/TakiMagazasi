using ECommerceEntities;

namespace ECommerceDataAccess.Abstract
{
    public interface ICartDal : IRepository<Cart>
    {
        List<Cart> GetByNumber(int id);
    }
}
