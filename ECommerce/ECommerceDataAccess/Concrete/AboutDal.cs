using ECommerceDataAccess.Abstract;
using ECommerceDataAccess.Data;
using ECommerceEntities;

namespace ECommerceDataAccess.Concrete
{
    public class AboutDal : Repository<About>, IAboutDal
    {
        public AboutDal(AppDbContext context) : base(context)
        {
        }
    }
}
