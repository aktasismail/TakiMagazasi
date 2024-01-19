using AutoMapper;
using ECommerceBusiness.Abstract;
using ECommerceEntities;
using ECommerceEntities.Dto;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var value = _mapper.Map<List<ContactDto>>(_contactService.TGetListAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateContact(ContactDto createContactDto)
        {
            _contactService.TAdd(new Contact()
            {
                Title = createContactDto.Title,
                Location = createContactDto.Location,
                Mail = createContactDto.Mail,
                Phone = createContactDto.Phone,
                Description = createContactDto.Description,
            });
            return Ok("İletişim Bilgisi Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var value = _contactService.TGetByID(id);
            _contactService.TDelete(value);
            return Ok("İletişim Bilgisi Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetContact(int id)
        {
            var value = _contactService.TGetByID(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateContact(ContactDto updateContactDto)
        {
            _contactService.TUpdate(new Contact()
            {
                ContactId = updateContactDto.ContactId,
                Description = updateContactDto.Description,
                Location = updateContactDto.Location,
                Mail = updateContactDto.Mail,
                Phone = updateContactDto.Phone,
                Title = updateContactDto.Title,
            });
            return Ok("İletişim Bilgisi Güncellendi");
        }
    }
}
