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

    public class FavouriteController : ControllerBase
    {
        private readonly IFavouriteService _favouriteService;
        public FavouriteController(IFavouriteService favouriteService)
        {
            _favouriteService = favouriteService;
        }
        [HttpGet("ListFavouriteProduct")]
        public IActionResult ListFavouriteProduct(string userid)
        {
            using var context = new AppDbContext();
            var values = context.Favourites.Include(x => x.Product).Select(z => new FavoriteListModel
            {
                FavouriteId = z.FavouriteId,
                ProductId = z.ProductId,
                ProductName = z.Product.ProductName,
                ImageUrl=z.Product.ImageUrl,
                UserId = z.UserId
                
            }).Where(x=>x.UserId.Equals(userid)).ToList();
            return Ok(values);  
        }
        [HttpPost]
        public IActionResult CreateFavourite(FavouriteCreateDto FavouriteCreateDto)
        {
            using var context = new AppDbContext();
            _favouriteService.TAdd(new Favourite()
            {
                ProductId = FavouriteCreateDto.ProductId,
                UserId = FavouriteCreateDto.UserId,
            });
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeletEFavouriteItem(int id)
        {
            var value = _favouriteService.TGetByID(id);
            _favouriteService.TDelete(value);
            return Ok("Seçilen Ürün Silindi");
        }
    }
}
