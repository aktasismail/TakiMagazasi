using ECommerceBusiness.Abstract;
using ECommerceDataAccess.Data;
using ECommerceEntities;
using ECommerceEntities.Dto;
using ECommerceEntities.Dto.CreateDto;
using ECommerceEntities.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;

namespace ECommerceWebUi.Controllers
{
    public class FavouriteController : Controller
    {
        private readonly IFavouriteService _favouriteService;
        public FavouriteController(IFavouriteService favouriteService)
        {
            _favouriteService = favouriteService;
        }
        public async Task<IActionResult> Index()
        {
            string userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            using var context = new AppDbContext();
            var values = await context.Favourites.Include(x => x.Product).Where(x=>x.UserId.Equals(userid)).ToListAsync();
            return View(values);
        }
        public async Task<IActionResult> CreateFavourite(int id)
        {
            string userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _favouriteService.TAdd(new Favourite()
            {
                ProductId = id,
                UserId = userid,
            });
            return Ok();
        }
        public async Task<IActionResult> DeleteFavourite(int id)
        {
            var value = await _favouriteService.TGetByID(id);
            await _favouriteService.TDelete(value);
            return RedirectToAction("Index");
        }
        
    }
}
