using ECommerceBusiness.Abstract;
using ECommerceDataAccess.Abstract;
using ECommerceEntities;

namespace ECommerceBusiness.Concrete
{
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _aboutDal;
        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }
        public Task TAdd(About entity) =>
            _aboutDal.Add(entity);

        public Task TDelete(About entity) =>
            _aboutDal.Delete(entity);

        public Task<About> TGetByID(int id)
        {
            return _aboutDal.GetById(id);
        }
        public Task<List<About>> TGetListAll()
        {
            return _aboutDal.GetAll();
        }

        public Task TUpdate(About entity) =>
            _aboutDal.Update(entity);
    }
}
