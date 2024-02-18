using AutoMapper;
using ECommerceBusiness.Abstract;
using ECommerceEntities.Dto;
using ECommerceEntities.Dto.CreateDto;
using ECommerceEntities.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ECommerceWebUi.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly IAboutService _aboutService;
        private readonly IContactService _contactService;
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;
        public HomeController(IProductService productService, IMapper mapper, IAboutService aboutService, IContactService contactService, ICommentService commentService)
        {
            _productService = productService;
            _mapper = mapper;
            _aboutService = aboutService;
            _contactService = contactService;
            _commentService = commentService;
        }
        public async Task<IActionResult> Index()
        {
            var value = _mapper.Map<List<ProductDto>>(await _productService.TGetListAll());
            return View(value);
        }
        [HttpGet]
        public async Task<IActionResult> ProductDetails(int id)
        {
            var CommentModel = new CommentModels()
            {
                productDto = _mapper.Map<ProductDto>(await _productService.TGetByID(id)),
                Comment = _commentService.TGetListAll().Result.Where(x=>x.ProductId.Equals(id)).ToList()
            };
            return View(CommentModel);
        }
        public async Task<IActionResult> GetAbout()
        {
            var entity = await _aboutService.TGetListAll();
            return View(entity);
        }
        public async Task<IActionResult> GetContact()
        {
            var value = _mapper.Map<List<ContactDto>>(await _contactService.TGetListAll());
            return View(value);
        }
    }
}
