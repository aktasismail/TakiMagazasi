using ECommerceEntities;

namespace ECommerceBusiness.Abstract
{
    public interface IDiscountService : IRepositoryService<Discount>
	{
		void TChangeStatusToTrue(int id);
		void TChangeStatusToFalse(int id);
		List<Discount> TGetListByStatusTrue();
	}
}
