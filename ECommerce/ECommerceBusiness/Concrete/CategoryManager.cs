using ECommerceBusiness.Abstract;
using ECommerceDataAccess.Abstract;
using ECommerceEntities;

namespace SignalR.BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public void TAdd(Category entity)
        {
            _categoryDal.Add(entity);
        }
        public void TDelete(Category entity)
        {
           _categoryDal.Delete(entity);
        }

        public Category TGetByID(int id)
        {
            return _categoryDal.GetById(id);
        }

        public List<Category> TGetListAll()
        {
            return _categoryDal.GetAll();
        }
        public void TUpdate(Category entity)
        {
            _categoryDal.Update(entity);
        }
    }
}
