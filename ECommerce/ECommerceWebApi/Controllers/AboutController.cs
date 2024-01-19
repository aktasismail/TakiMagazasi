using ECommerceBusiness.Abstract;
using ECommerceEntities;
using ECommerceEntities.Dto;
using ECommerceEntities.Dto.CreateDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebApi.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            var entity = _aboutService.TGetListAll();
            return Ok(entity);
        }
        [HttpPost]
        public IActionResult AddAbout(AboutCreateDto aboutCreateDto)
        {
            About about = new About()
            {
                Title = aboutCreateDto.Title,
                Description = aboutCreateDto.Description,
                ImageUrl = aboutCreateDto.ImageUrl,
            };
            _aboutService.TAdd(about);
            return Ok("Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id)
        {
            var value = _aboutService.TGetByID(id);
            _aboutService.TDelete(value);
            return Ok("Hakkımda Alanı Silindi");
        }
        [HttpPut]
        public IActionResult UpdateAbout(AboutDto aboutDto)
        {
            About about = new About()
            {
                AboutId = aboutDto.AboutId,
                ImageUrl = aboutDto.ImageUrl,
                Description = aboutDto.Description,
                Title = aboutDto.Title
            };
            _aboutService.TUpdate(about);
            return Ok("Hakkımda Alanı Güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetAbout(int id)
        {
            var value = _aboutService.TGetByID(id);
            return Ok(value);
        }
    }
}
