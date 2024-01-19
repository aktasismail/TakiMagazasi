using ECommerceBusiness.Abstract;
using ECommerceDataAccess.Abstract;
using ECommerceEntities;

namespace SignalR.BusinessLayer.Concrete
{
    public class SocialMediaManager : ISocialMediaService
    {
        private readonly ISocialMediaDal _socialMediaDal;

        public SocialMediaManager(ISocialMediaDal socialMediaDal)
        {
            _socialMediaDal = socialMediaDal;
        }

        public void TAdd(SocialMedia entity)
        {
           _socialMediaDal.Add(entity);
        }

        public void TDelete(SocialMedia entity)
        {
           _socialMediaDal.Delete(entity);
        }

        public SocialMedia TGetByID(int id)
        {
           return _socialMediaDal.GetById(id);
        }

        public List<SocialMedia> TGetListAll()
        {
            return _socialMediaDal.GetAll();
        }

        public void TUpdate(SocialMedia entity)
        {
            _socialMediaDal.Update(entity);
        }
    }
}
