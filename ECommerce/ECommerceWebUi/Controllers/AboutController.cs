using ECommerceBusiness.Abstract;
using ECommerceDataAccess.Concrete;
using ECommerceEntities;
using ECommerceEntities.Dto;
using ECommerceEntities.Dto.CreateDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace ECommerceWebUi.Controllers
{
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;
        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }
        public async Task<IActionResult> Index()
        {
            var entity = await _aboutService.TGetListAll();
            return View(entity);
        }
        [HttpGet]
        public IActionResult CreateAbout()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAbout(AboutCreateDto createAboutDto)
        {
            About about = new About()
            {
                Title = createAboutDto.Title,
                Description = createAboutDto.Description,
                ImageUrl = createAboutDto.ImageUrl,
            };
            await _aboutService.TAdd(about);
            return RedirectToAction("Index");

        }
        public async Task<IActionResult> DeleteAbout(int id)
        {
            var value = await _aboutService.TGetByID(id);
            await _aboutService.TDelete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateAbout(int id)
        {
            var value = await _aboutService.TGetByID(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAbout(AboutDto aboutDto)
        {
            About about = new About()
            {
                AboutId = aboutDto.AboutId,
                ImageUrl = aboutDto.ImageUrl,
                Description = aboutDto.Description,
                Title = aboutDto.Title
            };
            await _aboutService.TUpdate(about);
            return RedirectToAction("Index");
        }
    }
}
