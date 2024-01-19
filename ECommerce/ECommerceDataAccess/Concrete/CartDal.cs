using ECommerceDataAccess.Abstract;
using ECommerceDataAccess.Data;
using ECommerceEntities;
using Microsoft.EntityFrameworkCore;

namespace ECommerceDataAccess.Concrete
{
    public class CartDal : Repository<Cart>, ICartDal
    {
        public CartDal(AppDbContext context) : base(context)
        {
        }

        public List<Cart> GetByNumber(int id)
        {
            using var context=new AppDbContext();
            var values = context.Carts.Include(y=>y.Product).ToList();
            return values;
        }
    }
}
