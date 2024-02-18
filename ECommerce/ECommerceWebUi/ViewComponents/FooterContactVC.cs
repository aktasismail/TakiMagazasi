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
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public FooterContactVC(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = _mapper.Map<List<ContactDto>>(await _contactService.TGetListAll());
            return View(value);
        }
    }
}
