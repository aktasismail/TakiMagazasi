using ECommerceEntities;

namespace ECommerceDataAccess.Abstract
{
    public interface IDiscountDal : IRepository<Discount>
    {
        void ChangeStatusToTrue(int id);
        void ChangeStatusToFalse(int id);
        List<Discount> GetListByStatusTrue();
    }
}
