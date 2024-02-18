using AutoMapper;
using ECommerceBusiness.Abstract;
using ECommerceEntities.Dto;
using ECommerceEntities.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace ECommerceWebUi.ViewComponents
{
    public class FooterSocialMediaVC : ViewComponent
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;
        public FooterSocialMediaVC(ISocialMediaService socialMediaService, IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = _mapper.Map<List<SocialMediaDto>>(await _socialMediaService.TGetListAll());
            return View(value);
        }
    }
}
