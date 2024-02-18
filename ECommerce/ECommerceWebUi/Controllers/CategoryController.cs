using AutoMapper;
using ECommerceBusiness.Abstract;
using ECommerceEntities;
using ECommerceEntities.Dto;
using ECommerceEntities.Dto.CreateDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebUi.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var value =  _mapper.Map<List<CategoryDto>>(await _categoryService.TGetListAll());
            return View(value);
        }
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryCreateDto categoryCreateDto)
        {
            await _categoryService.TAdd(new Category()
            {
                CategoryName = categoryCreateDto.CategoryName,
            });
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var value = await _categoryService.TGetByID(id);
            await _categoryService.TDelete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var value = await _categoryService.TGetByID(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(CategoryDto categoryDto)
        {
            await _categoryService.TUpdate(new Category()
            {
                CategoryName = categoryDto.CategoryName,
                CategoryId = categoryDto.CategoryId,
            });
            return RedirectToAction("Index");
        }
    }
}
