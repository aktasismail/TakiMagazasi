using ECommerceDataAccess.Abstract;
using ECommerceDataAccess.Data;
using ECommerceEntities;

namespace ECommerceDataAccess.Concrete
{
    public class ContactDal : Repository<Contact>, IContactDal
    {
        public ContactDal(AppDbContext context) : base(context)
        {
        }
    }
}
