using ECommerceBusiness.Abstract;
using ECommerceDataAccess.Abstract;
using ECommerceEntities;

namespace SignalR.BusinessLayer.Concrete
{
    public class CartManager : ICartService
    {
        private readonly ICartDal _cartDal;
        public CartManager(ICartDal cartDal)
        {
            _cartDal = cartDal;
        }
        public void TAdd(Cart entity)
        {
            _cartDal.Add(entity);
        }

        public void TDelete(Cart entity)
        {
            _cartDal.Delete(entity);
        }

        public List<Cart> TGetByNumber(int id)
        {
            return _cartDal.GetByNumber(id);
        }

        public Cart TGetByID(int id)
        {
            return _cartDal.GetById(id);
        }

        public List<Cart> TGetListAll()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Cart entity)
        {
            throw new NotImplementedException();
        }
    }
}
