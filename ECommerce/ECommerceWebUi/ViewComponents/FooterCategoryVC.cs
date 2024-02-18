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
    public class FooterCategoryVC : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public FooterCategoryVC(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = _mapper.Map<List<CategoryDto>>(_categoryService.TGetListAll().Result.Take(4));
            return View(value);
        }
    }
}
