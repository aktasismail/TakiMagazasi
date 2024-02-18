using AutoMapper;
using ECommerceBusiness.Abstract;
using ECommerceDataAccess.Data;
using ECommerceEntities;
using ECommerceEntities.Dto;
using ECommerceWebUi.Keys;
using ECommerceWebUi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SelectPdf;
using System.Security.Claims;

namespace ECommerceWebUi.Controllers
{
    public class OrderController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;
        private readonly AppDbContext _appDbContext;
        public OrderController(UserManager<AppUser> userManager, IOrderService orderService, IMapper mapper, ICategoryService categoryService, AppDbContext appDbContext)
        {
            _mapper = mapper;
            _userManager = userManager;
            _orderService = orderService;
            _categoryService = categoryService;
            _appDbContext = appDbContext;
        }
        public async Task<IActionResult> Checkout()
        {
            var cart = HttpContext.Session.GetString(Key.cart_items);
            var user = HttpContext.Session.GetString(Key.Users);
            var cartitems = JsonConvert.DeserializeObject<List<CartModel>>(cart);
            var specificUser = JsonConvert.DeserializeObject<AppUser>(user);

            OrderModel _model = new OrderModel();
            _model.UserId = specificUser.Id;
            _model.FirstName = specificUser.FirstName;
            _model.LastName = specificUser.LastName;
            _model.OrderDate = DateTime.UtcNow;
            _model.Items = cartitems;
            return View(_model);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCheckout(OrderModel model)
        {
            var basket = HttpContext.Session.GetString(Key.cart_items);
            var basket_items = JsonConvert.DeserializeObject<List<CartModel>>(basket);
            var user = HttpContext.User.Identity.Name;
            var userDetail = await _userManager.FindByNameAsync(user);
            List<Product> _product = new List<Product>();
            foreach (var item in basket_items)
            {
                var category = await _categoryService.GetCategoryByName(item.CategoryName);
                Product obj = new Product();
                obj.Id = item.Id;
                obj.ProductName = item.ProductName;
                obj.Description = item.ProductDescription;
                obj.Price = item.Price;
                obj.ImageUrl = item.ImageUrl;
                obj.CategoryId = category.CategoryId;
                _product.Add(obj);
            }
            var mapDTO = _mapper.Map<OrderDto>(model);
            mapDTO.UserId = userDetail.Id;
            OrderVM _processModel = new OrderVM();
            _processModel._product = _product;
            _processModel._orderDto = mapDTO;

            var orderForSession = JsonConvert.SerializeObject(_processModel);
            HttpContext.Session.SetString(Key.orderProcess, orderForSession);

            return RedirectToAction("Index", "Payment");
        }
        public IActionResult OrderConfirmation(OrderConfirmationModel model)
        {
            return View(model);
        }
        public async Task<IActionResult> Billing(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            OrderDetailVM order = new OrderDetailVM()
            {
                AppUser = await _userManager.FindByIdAsync(userId),
                Order = await _orderService.GetOrderById(id),
                ListOrder = await _orderService.MyOrders(userId)
            };
            return View(order);
        }
        [HttpPost]
        public ActionResult GeneratePdf(string url)
        {
            HtmlToPdf converter = new HtmlToPdf();
            PdfDocument doc = converter.ConvertUrl(url);
            byte[] pdf = doc.Save();
            doc.Close();
            FileResult fileResult = new FileContentResult(pdf, "application/pdf");
            fileResult.FileDownloadName = "Document.pdf";
            return fileResult;
        }
        public async Task<IActionResult> OrderDetailForAdmin(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            OrderDetailVM order = new OrderDetailVM()
            {
                AppUser = await _userManager.FindByIdAsync(userId),
                Order = await _orderService.GetOrderById(id),
                ListOrder = await _orderService.MyOrders(userId)
            };
            return View(order);
        }
        public async Task<IActionResult> OrderDetail(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            OrderDetailVM order = new OrderDetailVM()
            {
                AppUser = await _userManager.FindByIdAsync(userId),
                Order = await _orderService.GetOrderById(id),
                ListOrder = await _orderService.MyOrders(userId)
            };
            return View(order);
        }
        [HttpPost]
        public async Task<IActionResult> OrderStatusChange(int orderId, string orderStatus,string tracking)
        {
            var order = await _orderService.GetOrderById(orderId);
            if (order != null)
            {
                order.Status = orderStatus;
                order.Tracking = tracking;
                await _appDbContext.SaveChangesAsync();
                return RedirectToAction("Index", "User");

            }
            return RedirectToAction("Index", "User");
        }
        public async Task<IActionResult> OrderForAdmin()
        {
            var myorder = await _appDbContext.Orders.ToListAsync();
            return View(myorder);
        }
    }
}

