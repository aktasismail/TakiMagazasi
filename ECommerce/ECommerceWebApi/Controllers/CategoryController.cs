using AutoMapper;
using ECommerceBusiness.Abstract;
using ECommerceEntities;
using ECommerceEntities.Dto;
using ECommerceEntities.Dto.CreateDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult CategoryList()
        {

            var value = _mapper.Map<List<CategoryDto>>(_categoryService.TGetListAll());
            return Ok(value);
        }
        [HttpGet("CategoryListToFooter")]
        public IActionResult CategoryListToFooter()
        {
            var value = _mapper.Map<List<CategoryDto>>(_categoryService.TGetListAll().Take(4));
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateCategory(CategoryCreateDto categoryCreateDto)
        {
            _categoryService.TAdd(new Category()
            {
                CategoryName = categoryCreateDto.CategoryName,
            });
            return Ok("Kategori Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var value = _categoryService.TGetByID(id);
            _categoryService.TDelete(value);
            return Ok("Kategori Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var value = _categoryService.TGetByID(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateCategory(CategoryDto updateCategoryDto)
        {
            _categoryService.TUpdate(new Category()
            {
                CategoryName = updateCategoryDto.CategoryName,
                CategoryId=updateCategoryDto.CategoryId,
            });
            return Ok("Kategori Güncellendi");
        }
    }
}
