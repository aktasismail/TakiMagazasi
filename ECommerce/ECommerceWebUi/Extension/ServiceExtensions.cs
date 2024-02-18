using ECommerceBusiness.Abstract;
using ECommerceBusiness.Concrete;
using ECommerceDataAccess.Abstract;
using ECommerceDataAccess.Concrete;
using ECommerceDataAccess.Data;
using ECommerceEntities;
using Microsoft.AspNetCore.Identity;
namespace ECommerceWebUi.Extension
{
    public static class ServiceExtensions
    {
        public static void ConfigureDataAccessLayer(this IServiceCollection services)
        {
            services.AddScoped<IAboutDal, AboutDal>();
            services.AddScoped<ICategoryDal, CategoryDal>();
            services.AddScoped<IContactDal, ContactDal>();
            services.AddScoped<IProductDal, ProductDal>();
            services.AddScoped<ISocialMediaDal, SocialMediaDal>();
            services.AddScoped<ICommentDal, CommentDal>();
            services.AddScoped<IFavouriteDal, FavouriteDal>();
        }
        public static void ConfigureBusinessLayer(this IServiceCollection services)
        {
            services.AddScoped<IAboutService, AboutManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IContactService, ContactManager>();
            services.AddScoped<IOrderService, OrderManager>();
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<ISocialMediaService, SocialMediaManager>();
            services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<IFavouriteService, FavouriteManager>();
            
        }
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentity<AppUser, IdentityRole>(option =>
            {
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequiredLength = 8;
                option.Password.RequiredUniqueChars = 1;
                option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
                option.Lockout.MaxFailedAccessAttempts = 100;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders(); ;
            builder.Services.ConfigureApplicationCookie(options => {
                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(30);
            });
        }
        public static void ConfigureSession(this IServiceCollection services)
        {
            var builder = services.AddSession(options =>
            {
                options.Cookie.Name = "ismailaktascookie";
                options.IdleTimeout = TimeSpan.FromDays(7);
            });
        }
    }
}
