using ECommerceBusiness.Abstract;
using ECommerceDataAccess.Abstract;
using ECommerceEntities;

namespace ECommerceBusiness.Concrete
{
    public class SocialMediaManager : ISocialMediaService
    {
        private readonly ISocialMediaDal _socialMediaDal;

        public SocialMediaManager(ISocialMediaDal socialMediaDal)
        {
            _socialMediaDal = socialMediaDal;
        }
        public Task TAdd(SocialMedia entity)=>
           _socialMediaDal.Add(entity);
        public Task TDelete(SocialMedia entity)=>
            _socialMediaDal.Delete(entity);
        public Task<SocialMedia> TGetByID(int id)
        {
           return _socialMediaDal.GetById(id);
        }
        public Task<List<SocialMedia>> TGetListAll()
        {
            return _socialMediaDal.GetAll();
        }
        public Task TUpdate(SocialMedia entity) =>
            _socialMediaDal.Update(entity);
    }
}
