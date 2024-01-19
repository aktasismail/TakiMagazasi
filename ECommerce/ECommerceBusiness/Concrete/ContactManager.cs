using ECommerceBusiness.Abstract;
using ECommerceDataAccess.Abstract;
using ECommerceEntities;

namespace SignalR.BusinessLayer.Concrete
{
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactDal;
        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }
        public void TAdd(Contact entity)
        {
            _contactDal.Add(entity);
        }

        public void TDelete(Contact entity)
        {
            _contactDal.Delete(entity);
        }

        public Contact TGetByID(int id)
        {
            return _contactDal.GetById(id);
        }

        public List<Contact> TGetListAll()
        {
            return _contactDal.GetAll();
        }

        public void TUpdate(Contact entity)
        {
            _contactDal.Update(entity);
        }
    }
}
