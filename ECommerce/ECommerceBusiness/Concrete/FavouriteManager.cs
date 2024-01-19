using ECommerceBusiness.Abstract;
using ECommerceDataAccess.Abstract;
using ECommerceDataAccess.Concrete;
using ECommerceEntities;

namespace SignalR.BusinessLayer.Concrete
{
    public class FavouriteManager : IFavouriteService
    {
        private readonly IFavouriteDal _favouriteDal;
        public FavouriteManager(IFavouriteDal favouriteDal)
        {
            _favouriteDal = favouriteDal;
        }
        public void TAdd(Favourite entity)
        {
            _favouriteDal.Add(entity);
        }

        public void TDelete(Favourite entity)
        {
            _favouriteDal.Delete(entity);
        }

        public List<Favourite> TGetByNumber(int id)
        {
            return _favouriteDal.GetByNumber(id);
        }

        public Favourite TGetByID(int id)
        {
            return _favouriteDal.GetById(id);
        }

        public List<Favourite> TGetListAll()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Favourite entity)
        {
            throw new NotImplementedException();
        }
    }
}
