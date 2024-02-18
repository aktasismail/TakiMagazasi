using AutoMapper;
using ECommerceEntities;
using ECommerceEntities.Dto;
using ECommerceEntities.Dto.CreateDto;
using ECommerceWebUi.Models;

namespace ECommerceWebUi.AutoMapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<About, AboutDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Contact, ContactDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<OrderDto, OrderModel>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<RegisterDto, AppUser>();
            CreateMap<SocialMedia, SocialMediaDto>().ReverseMap();
            CreateMap<Comment, CommentDto>().ReverseMap();
            CreateMap<Favourite, FavouriteDto>().ReverseMap();

            //Mapping with createDto
            CreateMap<About, AboutCreateDto>();
            CreateMap<Category, CategoryCreateDto>();
            CreateMap<Contact, ContactCreateDto>();
            CreateMap<Order, OrderCreateDto>();
            CreateMap<Product, ProductCreateDto>().ReverseMap();
            CreateMap<SocialMedia, SocialMediaCreateDto>();
            CreateMap<Comment, CommentCreateDto>().ReverseMap();
            CreateMap<Favourite, FavouriteCreateDto>();
        }
    }
}
