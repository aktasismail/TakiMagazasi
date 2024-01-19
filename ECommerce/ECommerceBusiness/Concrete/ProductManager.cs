using ECommerceBusiness.Abstract;
using ECommerceDataAccess.Abstract;
using ECommerceEntities;

namespace SignalR.BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public string TProductNameByMaxPrice()
        {
            return _productDal.ProductNameByMaxPrice();
        }

        public string TProductNameByMinPrice()
        {
            return _productDal.ProductNameByMinPrice();
        }

        public void TAdd(Product entity)
        {
            _productDal.Add(entity);
        }

        public void TDelete(Product entity)
        {
            _productDal.Delete(entity);
        }

        public Product TGetByID(int id)
        {
            return _productDal.GetById(id);
        }

        public List<Product> TGetListAll()
        {
            return _productDal.GetAll();
        }

        public List<Product> TGetProductsWithCategories()
        {
          return _productDal.GetProductsWithCategories();
        }

        public int TProductCount()
        {
            return _productDal.ProductCount();
        }
        public decimal TProductPriceAvg()
        {
            return _productDal.ProductPriceAvg();
        }

        public void TUpdate(Product entity)
        {
           _productDal.Update(entity);
        }

        public IEnumerable<Product> ProductByCategory(int id)
        {
            return _productDal.GetAll().Where(x => x.CategoryId.Equals(id)).ToList();
        }
    }
}
