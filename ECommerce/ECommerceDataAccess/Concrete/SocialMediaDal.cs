using ECommerceDataAccess.Abstract;
using ECommerceDataAccess.Data;
using ECommerceEntities;

namespace ECommerceDataAccess.Concrete
{
    public class SocialMediaDal : Repository<SocialMedia>, ISocialMediaDal
    {
        public SocialMediaDal(AppDbContext context) : base(context)
        {
        }
    }
}
