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
        private readonly IHttpClientFactory _httpClientFactory;
        public FooterAboutVC(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7028/api/About");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<AboutDto>>(jsonData);
            return View(values);
        }
    }
}
