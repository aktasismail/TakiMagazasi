    using ECommerceBusiness.Abstract;
using ECommerceBusiness.Concrete;
using ECommerceDataAccess.Abstract;
using ECommerceDataAccess.Concrete;
using ECommerceDataAccess.Data;
using ECommerceEntities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SignalR.BusinessLayer.Concrete;
using System.Text;

namespace ECommerceWebApi.Extension
{
    public static class ServiceExtensions
    {
        public static void ConfigureDataAccessLayer(this IServiceCollection services)
        {
            services.AddScoped<IAboutDal, AboutDal>();
            services.AddScoped<ICartDal, CartDal>();
            services.AddScoped<ICategoryDal, CategoryDal>();
            services.AddScoped<IContactDal, ContactDal>();
            services.AddScoped<IDiscountDal, DiscountDal>();
            services.AddScoped<IProductDal, ProductDal>();
            services.AddScoped<ISocialMediaDal, SocialMediaDal>();
            services.AddScoped<ICommentDal, CommentDal>();
            services.AddScoped<IFavouriteDal, FavouriteDal>();
        }
        public static void ConfigureBusinessLayer(this IServiceCollection services)
        {
            services.AddScoped<IAboutService, AboutManager>();
            services.AddScoped<ICartService, CartManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IContactService, ContactManager>();
            services.AddScoped<IDiscountService, DiscountManager>();
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<ISocialMediaService, SocialMediaManager>();
            services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<IFavouriteService, FavouriteManager>();

        }
    }
}
