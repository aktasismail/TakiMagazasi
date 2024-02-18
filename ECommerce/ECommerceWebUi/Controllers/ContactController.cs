using AutoMapper;
using ECommerceBusiness.Abstract;
using ECommerceEntities;
using ECommerceEntities.Dto;
using ECommerceEntities.Dto.CreateDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebUi.Controllers
{
    [Authorize]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var value = _mapper.Map<List<ContactDto>>(await _contactService.TGetListAll());
            return View(value);
        }
        [HttpGet]
        public IActionResult CreateContact()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateContact(ContactCreateDto contactCreateDto)
        {
            await _contactService.TAdd(new Contact()
            {
                Title = contactCreateDto.Title,
                Location = contactCreateDto.Location,
                Mail = contactCreateDto.Mail,
                Phone = contactCreateDto.Phone,
                Description = contactCreateDto.Description,
            });
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteContact(int id)
        {
            var value = await _contactService.TGetByID(id);
            await _contactService.TDelete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateContact(int id)
        {
            var value = await _contactService.TGetByID(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateContact(ContactDto contactDto)
        {
            await _contactService.TUpdate(new Contact()
            {
                ContactId = contactDto.ContactId,
                Description = contactDto.Description,
                Location = contactDto.Location,
                Mail = contactDto.Mail,
                Phone = contactDto.Phone,
                Title = contactDto.Title,
            });
            return RedirectToAction("Index");
        }
    }
}
