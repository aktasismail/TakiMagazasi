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
    public class ProdutListVC : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ProdutListVC(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7028/api/Product/ProductListToDetail");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ProductDto>>(jsonData);
            return View(values);
        }
    }
}
