using AutoMapper;
using ECommerceBusiness.Abstract;
using ECommerceEntities;
using ECommerceEntities.Dto;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;
        public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var value = _mapper.Map<List<SocialMediaDto>>(_socialMediaService.TGetListAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateSocialMedia(SocialMediaDto createSocialMediaDto)
        {
            _socialMediaService.TAdd(new SocialMedia()
            {
              Icon=createSocialMediaDto.Icon,
              Title=createSocialMediaDto.Title,
              Url=createSocialMediaDto.Url
            });
            return Ok("Sosyal Medya Bilgisi Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSocialMedia(int id)
        {
            var value = _socialMediaService.TGetByID(id);
            _socialMediaService.TDelete(value);
            return Ok("Sosyal Medya Bilgisi Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetSocialMedia(int id)
        {
            var value = _socialMediaService.TGetByID(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateSocialMedia(SocialMediaDto updateSocialMediaDto)
        {
            _socialMediaService.TUpdate(new SocialMedia()
            {
                Icon = updateSocialMediaDto.Icon,
                Title = updateSocialMediaDto.Title,
                Url = updateSocialMediaDto.Url,
                SocialMediaId=updateSocialMediaDto.SocialMediaId
            });
            return Ok("Sosyal Medya Bilgisi Güncellendi");
        }
    }
}
