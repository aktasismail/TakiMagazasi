using AutoMapper;
using ECommerceBusiness.Abstract;
using ECommerceEntities.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebUi.ViewComponents
{
    public class ProdutListVC : ViewComponent
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProdutListVC(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = _mapper.Map<List<ProductDto>>(_productService.TGetListAll().Result.Take(3));
            return View(value);
        }
    }
}
