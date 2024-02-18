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

        public async Task<List<Favourite>> GetByNumber(int id)
        {
            using var context=new AppDbContext();
            var values = await context.Favourites.Include(y=>y.Product).ToListAsync();
            return values;
        }
    }
}
