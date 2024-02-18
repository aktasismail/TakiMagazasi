using ECommerceBusiness.Abstract;
using ECommerceEntities;
using ECommerceEntities.Dto;
using ECommerceEntities.Dto.CreateDto;
using ECommerceWebUi.Keys;
using ECommerceWebUi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;

namespace ECommerceWebUi.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly UserManager<AppUser> _userManager;
        public CartController(IProductService productService, ICategoryService categoryService, UserManager<AppUser> userManager)
        {
            _productService = productService;
            _categoryService = categoryService;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var cart = HttpContext.Session.GetString(Key.cart_items);
            if (string.IsNullOrEmpty(cart))
            {
                return View(new List<CartModel>());
            }
            else
            {
                var cartitem = JsonConvert.DeserializeObject<List<CartModel>>(cart);
                return View(cartitem);
            }
        }
        public async Task<IActionResult> AddToCart(int id)
        {
            CartModel model = new CartModel();
            List<CartModel>listmodel = new List<CartModel>();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var product = await _productService.TGetByID(id);
            var category = await _categoryService.TGetByID(product.CategoryId);
            model.ProductName = product.ProductName;
            model.ProductDescription = product.Description;
            model.Price = product.Price;
            model.ImageUrl = product.ImageUrl;
            model.CategoryName = category.CategoryName;
            model.Id = product.Id;
            var cart = HttpContext.Session.GetString(Key.cart_items);
            if (cart != null)
            {
                var cartitem = JsonConvert.DeserializeObject<List<CartModel>>(cart);
                foreach (var item in cartitem)
                {
                    listmodel.Add(item);
                }
                listmodel.Add(model);
            }
            else
            {
                listmodel.Add(model);
            }
            var user = await _userManager.FindByIdAsync(userId);
            string serializeProduct = JsonConvert.SerializeObject(listmodel);
            string serializeUser = JsonConvert.SerializeObject(user);
            HttpContext.Session.SetString(Key.cart_items, serializeProduct);
            HttpContext.Session.SetString(Key.Users, serializeUser);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult DeleteCart([FromRoute] int id)
        {
            var cart = HttpContext.Session.GetString(Key.cart_items);
            var cartitem = JsonConvert.DeserializeObject<List<CartModel>>(cart);
            foreach (var item in cartitem)
            {
                if (item.Id == id)
                {
                    cartitem.Remove(item);
                    string serializeProduct = JsonConvert.SerializeObject(cartitem);
                    HttpContext.Session.SetString(Key.cart_items, serializeProduct);
                    return RedirectToAction("Index", "Cart");
                }

            }
            return RedirectToAction("Index", "Cart");
        }
    }
}
