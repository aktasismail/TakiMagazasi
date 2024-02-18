using AutoMapper;
using ECommerceBusiness.Abstract;
using ECommerceEntities;
using ECommerceEntities.Dto;
using ECommerceEntities.Dto.CreateDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ECommerceWebUi.Controllers
{
    [Authorize]
    public class SocialMediaController : Controller
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;
        public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var value = _mapper.Map<List<SocialMediaDto>>(await _socialMediaService.TGetListAll());
            return View(value);
        }
        [HttpGet]
        public IActionResult CreateSocialMedia()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia(SocialMediaCreateDto socialMediaCreateDto)
        {
           await _socialMediaService.TAdd(new SocialMedia()
            {
                Icon = socialMediaCreateDto.Icon,
                Title = socialMediaCreateDto.Title,
                Url = socialMediaCreateDto.Url
            });
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteSocialMedia(int id)
        {
            var value = await _socialMediaService.TGetByID(id);
            await _socialMediaService.TDelete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateSocialMedia(int id)
        {
            var value = await _socialMediaService.TGetByID(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateSocialMedia(SocialMediaDto updateSocialMediaDto)
        {
            await _socialMediaService.TUpdate(new SocialMedia()
            {
                Icon = updateSocialMediaDto.Icon,
                Title = updateSocialMediaDto.Title,
                Url = updateSocialMediaDto.Url,
                SocialMediaId = updateSocialMediaDto.SocialMediaId
            });
            return RedirectToAction("Index");
        }
    }
}
