using AutoMapper;
using ECommerceBusiness.Abstract;
using ECommerceDataAccess.Abstract;
using ECommerceEntities;
using ECommerceEntities.Dto.CreateDto;

namespace ECommerceBusiness.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        private readonly IMapper _mapper;
        public ProductManager(IProductDal productDal, IMapper mapper)
        {
            _productDal = productDal;
            _mapper = mapper;
        }
        public async Task Add(ProductCreateDto productCreateDto)
        {
            if (productCreateDto == null)
            {
                throw new ArgumentNullException();
            }
            Product product = _mapper.Map<Product>(productCreateDto);
             await _productDal.Add(product);
        }
        public Task TAdd(Product entity)=>
            _productDal.Add(entity);

        public Task TDelete(Product entity) =>
            _productDal.Delete(entity);
        public Task<Product> TGetByID(int id)
        {
            return _productDal.GetById(id);
        }

        public Task<List<Product>> TGetListAll()
        {
            return  _productDal.GetAll();
        }

        public async Task<List<Product>> TGetProductsWithCategories()
        {
          return await _productDal.GetProductsWithCategories();
        }

        public Task TUpdate(Product entity) =>
            _productDal.Update(entity);

        public async Task<IEnumerable<Product>> ProductByCategory(int id)
        {
            return _productDal.GetAll().Result.Where(x => x.CategoryId.Equals(id)).ToList();
        }
    }
}
