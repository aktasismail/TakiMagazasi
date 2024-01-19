using ECommerceEntities;

namespace ECommerceBusiness.Abstract
{
    public interface ICartService: IRepositoryService<Cart>
    {
        List<Cart> TGetByNumber(int id);
    }
}
