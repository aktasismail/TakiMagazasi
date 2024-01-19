using AutoMapper;
using ECommerceEntities;
using ECommerceEntities.Dto;
using ECommerceEntities.Dto.CreateDto;

namespace ECommerceWebApi.AutoMapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<About, AboutDto>().ReverseMap();
            CreateMap<Cart, CartDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Contact, ContactDto>().ReverseMap();
            CreateMap<Discount, DiscountDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<RegisterDto, AppUser>();
            CreateMap<SocialMedia, SocialMediaDto>().ReverseMap();
            CreateMap<Comment, CommentDto>().ReverseMap();
            CreateMap<Favourite, FavouriteDto>().ReverseMap();

            //Mapping with createDto
            CreateMap<About, AboutCreateDto>();
            CreateMap<Cart, CartCreateDto>();
            CreateMap<Category, CategoryCreateDto>();
            CreateMap<Contact, ContactCreateDto>();
            CreateMap<Discount, DiscountCreateDto>();
            CreateMap<Product, ProductCreateDto>();
            CreateMap<SocialMedia, SocialMediaCreateDto>();
            CreateMap<Comment, CommentCreateDto>();
            CreateMap<Favourite, FavouriteCreateDto>();
        }
    }
}
