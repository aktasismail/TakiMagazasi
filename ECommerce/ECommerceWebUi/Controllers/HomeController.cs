using ECommerceEntities.Dto;
using ECommerceEntities.Dto.CreateDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Security.Claims;
using System.Text;

namespace ECommerceWebUi.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7028/api/Product/ProductListWithCategory");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ProductDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> ProductDetail(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7028/api/Product/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ProductDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddToCart(int id)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            CartCreateDto cartDto = new CartCreateDto();
            cartDto.ProductId = id;
            cartDto.UserId = userId;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(cartDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7028/api/Cart", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return Json(cartDto);
        }
        [HttpPost]
        public async Task<IActionResult> AddComment(int id,string name,string text)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            CommentCreateDto commentDto = new CommentCreateDto();
            commentDto.ProductId = id;
            commentDto.UserId = userId;
            commentDto.FullName = name;
            commentDto.Text = text;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(commentDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7028/api/Comment", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return Json(commentDto);
        }
        public async Task<IActionResult> AddFavourite(int id)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            FavouriteCreateDto favouriteDto = new FavouriteCreateDto();
            favouriteDto.ProductId = id;
            favouriteDto.UserId = userId;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(favouriteDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7028/api/Favourite", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return Json(favouriteDto);
        }
        public async Task<IActionResult> GetAbout()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7028/api/About");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<AboutDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> GetContact()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7028/api/Contact");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ContactDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
