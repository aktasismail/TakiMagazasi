using ECommerceBusiness.Abstract;
using ECommerceDataAccess.Abstract;
using ECommerceEntities;

namespace ECommerceBusiness.Concrete
{
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactDal;
        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }
        public Task TAdd(Contact entity)=>
            _contactDal.Add(entity);
        public Task TDelete(Contact entity) =>
            _contactDal.Delete(entity);
        public Task<Contact> TGetByID(int id)
        {
            return _contactDal.GetById(id);
        }
        public Task<List<Contact>> TGetListAll()
        {
            return _contactDal.GetAll();
        }
        public Task TUpdate(Contact entity) =>
            _contactDal.Update(entity);
    }
}
