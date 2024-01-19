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
    public class FooterContactVC : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public FooterContactVC(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7028/api/Contact");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ContactDto>>(jsonData);
            return View(values);
        }
    }
}
