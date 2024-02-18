using ECommerceBusiness.Abstract;
using ECommerceDataAccess.Abstract;
using ECommerceDataAccess.Concrete;
using ECommerceEntities;

namespace ECommerceBusiness.Concrete
{
    public class FavouriteManager : IFavouriteService
    {
        private readonly IFavouriteDal _favouriteDal;
        public FavouriteManager(IFavouriteDal favouriteDal)
        {
            _favouriteDal = favouriteDal;
        }
        public Task TAdd(Favourite entity)=>
            _favouriteDal.Add(entity);


        public Task TDelete(Favourite entity) =>
            _favouriteDal.Delete(entity);


        public Task<List<Favourite>> TGetByNumber(int id)
        {
            return _favouriteDal.GetByNumber(id);
        }
        Task<List<Favourite>> IFavouriteService.TGetByNumber(int id)
        {
            throw new NotImplementedException();
        }
        public Task<Favourite> TGetByID(int id)
        {
            return _favouriteDal.GetById(id);
        }
        public Task<List<Favourite>> TGetListAll()
        {
            throw new NotImplementedException();
        }
        public Task TUpdate(Favourite entity) =>
            throw new NotImplementedException();

        
    }
}
