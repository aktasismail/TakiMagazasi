using ECommerceBusiness.Abstract;
using ECommerceDataAccess.Data;
using ECommerceEntities;
using ECommerceEntities.Dto;
using ECommerceEntities.Dto.CreateDto;
using ECommerceEntities.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SignalRApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }
        [HttpGet("CartListWithProductName")]
        public IActionResult CartListWithProductName(string userid)
        {
            using var context = new AppDbContext();
            var values = context.Carts.Include(x => x.Product).Select(z => new CartListWithProduct
            {
                CartId = z.CartId,
                Count = z.Count,
                Price = z.Price,
                ProductId = z.ProductId,
                TotalPrice = z.TotalPrice,
                ProductName = z.Product.ProductName,
                ImageUrl=z.Product.ImageUrl,
                UserId = z.UserId
                
            }).Where(x=>x.UserId.Equals(userid)).ToList();
            return Ok(values);  
        }
        [HttpPost]
        public IActionResult CreateCart(CartCreateDto cartCreateDto)
        {
            using var context = new AppDbContext();
            _cartService.TAdd(new Cart()
            {
                ProductId = cartCreateDto.ProductId,
                UserId =cartCreateDto.UserId,
                Count = 1,
                Price = context.Products.Where(x => x.Id == cartCreateDto.ProductId).Select(y => y.Price).FirstOrDefault(),
                TotalPrice=0
            });
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCartItem(int id)
        {
            var value = _cartService.TGetByID(id);
            _cartService.TDelete(value);
            return Ok("Sepetteki Seçilen Ürün Silindi");
        }
    }
}
