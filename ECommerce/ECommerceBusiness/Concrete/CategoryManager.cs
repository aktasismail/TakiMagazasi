using ECommerceBusiness.Abstract;
using ECommerceDataAccess.Abstract;
using ECommerceDataAccess.Data;
using ECommerceEntities;
using Microsoft.EntityFrameworkCore;

namespace ECommerceBusiness.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        private readonly AppDbContext _context;
        public CategoryManager(ICategoryDal categoryDal, AppDbContext context)
        {
            _categoryDal = categoryDal;
            _context = context;
        }

        public async Task<Category> GetCategoryByName(string categoryName)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.CategoryName == categoryName);
            if (category != null)
            {
                return category;
            }
            return null;
        }
        public int TCategoryCount()
        {
            return _categoryDal.CategoryCount();
        }
        public Task TAdd(Category entity) =>
            _categoryDal.Add(entity);

        public Task TDelete(Category entity) =>
            _categoryDal.Delete(entity);

        public Task<Category> TGetByID(int id)
        {
            return  _categoryDal.GetById(id);
        }

        public  Task<List<Category>> TGetListAll()
        {
            return  _categoryDal.GetAll();
        }
        public async Task<List<Category>> GetCategoryForFooter()
        {
            return await _categoryDal.GetAllUrls().Take(4).ToListAsync();
        }
        public Task TUpdate(Category entity)=>
            _categoryDal.Update(entity);
    }
}
