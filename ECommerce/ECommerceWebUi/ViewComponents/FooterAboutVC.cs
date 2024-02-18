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
    public class FooterAboutVC : ViewComponent
    {
        private readonly IAboutService _aboutService;

        public FooterAboutVC(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var entity = await _aboutService.TGetListAll();
            return View(entity);
        }
    }
}
