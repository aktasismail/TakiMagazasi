using ECommerceDataAccess.Abstract;
using ECommerceDataAccess.Data;
using ECommerceEntities;

namespace ECommerceDataAccess.Concrete
{
    public class DiscountDal : Repository<Discount>, IDiscountDal
    {
        public DiscountDal(AppDbContext context) : base(context)
        {
        }

		public void ChangeStatusToFalse(int id)
		{
			using var context=new AppDbContext();
			var value = context.Discounts.Find(id);
			value.Status = false;
			context.SaveChanges();
		}

		public void ChangeStatusToTrue(int id)
		{
			using var context = new AppDbContext();
			var value = context.Discounts.Find(id);
			value.Status = true;
			context.SaveChanges();
		}

		public List<Discount> GetListByStatusTrue()
		{
			using var context = new AppDbContext();
			var value = context.Discounts.Where(x => x.Status == true).ToList();
			return value;
		}
	}
}
