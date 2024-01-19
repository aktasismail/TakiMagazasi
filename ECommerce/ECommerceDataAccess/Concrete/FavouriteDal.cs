using ECommerceDataAccess.Abstract;
using ECommerceDataAccess.Data;
using ECommerceEntities;
using Microsoft.EntityFrameworkCore;

namespace ECommerceDataAccess.Concrete
{
    public class FavouriteDal : Repository<Favourite>, IFavouriteDal
    {
        public FavouriteDal(AppDbContext context) : base(context)
        {
        }

        public List<Favourite> GetByNumber(int id)
        {
            using var context=new AppDbContext();
            var values = context.Favourites.Include(y=>y.Product).ToList();
            return values;
        }
    }
}
