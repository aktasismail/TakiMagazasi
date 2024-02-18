using AutoMapper;
using ECommerceBusiness.Abstract;
using ECommerceEntities;
using ECommerceEntities.Dto;
using ECommerceEntities.Dto.CreateDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace ECommerceWebUi.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;
        public ProductController(IProductService productService, IMapper mapper, ICommentService commentService, ICategoryService categoryService)
        {
            _productService = productService;
            _mapper = mapper;
            _commentService = commentService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var value = _mapper.Map<List<ProductDto>>(await _productService.TGetListAll());
            return View(value);
        }
        public async Task<IActionResult> ListByCategory(int id)
        {
            var value = _mapper.Map<List<ProductDto>>(await _productService.ProductByCategory(id));
            return View(value);
        }
        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            var values = _mapper.Map<List<CategoryDto>>(await _categoryService.TGetListAll());
            List<SelectListItem> values2 = (from x in values
                                            select new SelectListItem
                                            {
                                                Text = x.CategoryName,
                                                Value = x.CategoryId.ToString()
                                            }).ToList();
            ViewBag.v = values2;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromForm]ProductCreateDto createProductDto, [FromForm]IFormFile formFile)
        {

            if (formFile is not null)
            {
                string? path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "image", formFile.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await formFile.CopyToAsync(stream);
                }

                createProductDto.ImageUrl = String.Concat(formFile.FileName);
            }
            else
            {
                createProductDto.ImageUrl = null;
            }
            await _productService.Add(createProductDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var value = await _productService.TGetByID(id);
            await _productService.TDelete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var values = _mapper.Map<List<CategoryDto>>(await _categoryService.TGetListAll());
            List<SelectListItem> values2 = (from x in values
                                            select new SelectListItem
                                            {
                                                Text = x.CategoryName,
                                                Value = x.CategoryId.ToString()
                                            }).ToList();
            ViewBag.v = values2;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(ProductDto updateProductDto)
        {
            await _productService.TUpdate(new Product()
            {
                Description = updateProductDto.Description,
                ImageUrl = updateProductDto.ImageUrl,
                Price = updateProductDto.Price,
                ProductName = updateProductDto.ProductName,
                IsActice = updateProductDto.IsActice,
                Id = updateProductDto.Id,
                CategoryId = updateProductDto.CategoryId
            });
            return RedirectToAction("Index");
        }

    }
}
