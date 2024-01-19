using AutoMapper;
using ECommerceBusiness.Abstract;
using ECommerceDataAccess.Data;
using ECommerceEntities;
using ECommerceEntities.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult ProductList()
        {
            var value = _mapper.Map<List<ProductDto>>(_productService.TGetListAll());
            return Ok(value);
        }
        [HttpGet("ProductListToDetail")]
        public IActionResult ProductListToDetail()
        {
            var value = _mapper.Map<List<ProductDto>>(_productService.TGetListAll().Take(3));
            return Ok(value);
        }
        [HttpGet("ProductListByCategory")]
        public IActionResult ProductListByCategory(int id)
        {
            var value = _mapper.Map<List<ProductDto>>(_productService.ProductByCategory(id));
            return Ok(value);
        }
        [HttpGet("ProductCount")]
        public IActionResult ProductCount()
        {
            return Ok(_productService.TProductCount());
        }  
        [HttpGet("ProductNameByMaxPrice")]
        public IActionResult ProductNameByMaxPrice()
        {
            return Ok(_productService.TProductNameByMaxPrice());
        }

        [HttpGet("ProductNameByMinPrice")]
        public IActionResult ProductNameByMinPrice()
        {
            return Ok(_productService.TProductNameByMinPrice());
        }
        [HttpGet("ProductPriceAvg")]
        public IActionResult ProductPriceAvg()
        {
            return Ok(_productService.TProductPriceAvg());
        }
        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            var context = new AppDbContext();
            var values = context.Products.Include(x => x.Category).Select(y => new ProductDto
            {
                Description = y.Description,
                ImageUrl = y.ImageUrl,
                Price = y.Price,
                Id = y.Id,
                ProductName = y.ProductName,
                IsActice = y.IsActice,
                CategoryId = y.Category.CategoryId
            });
            return Ok(values.ToList());
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductDto createProductDto)
        {
            _productService.TAdd(new Product()
            {
                Description = createProductDto.Description,
                ImageUrl = createProductDto.ImageUrl,
                Price = createProductDto.Price,
                ProductName = createProductDto.ProductName,
                IsActice = createProductDto.IsActice,
                CategoryId = createProductDto.CategoryId
            });
            return Ok("Ürün Bilgisi Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.TGetByID(id);
            _productService.TDelete(value);
            return Ok("Ürün Bilgisi Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var value = _productService.TGetByID(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateProduct(ProductDto updateProductDto)
        {
            _productService.TUpdate(new Product()
            {
                Description = updateProductDto.Description,
                ImageUrl = updateProductDto.ImageUrl,
                Price = updateProductDto.Price,
                ProductName = updateProductDto.ProductName,
                IsActice = updateProductDto.IsActice,
                Id = updateProductDto.Id,
                CategoryId = updateProductDto.CategoryId
            });
            return Ok("Ürün Bilgisi Güncellendi");
        }
    }
}
