﻿using ECommerceBusiness.Abstract;
using ECommerceDataAccess.Abstract;
using ECommerceEntities;

namespace SignalR.BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _aboutDal;
        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }
        public void TAdd(About entity)
        {
            _aboutDal.Add(entity);
        }

        public void TDelete(About entity)
        {
            _aboutDal.Delete(entity);
        }

        public About TGetByID(int id)
        {
           return _aboutDal.GetById(id);
        }

        public List<About> TGetListAll()
        {
           return _aboutDal.GetAll();
        }

        public void TUpdate(About entity)
        {
           _aboutDal.Update(entity);
        }
    }
}
