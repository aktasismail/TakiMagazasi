using ECommerceDataAccess.Data;
using ECommerceEntities;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddIdentity<AppUser, IdentityRole>(option =>
{
	option.Password.RequireNonAlphanumeric = false;
	option.Password.RequiredLength = 8;
	option.Password.RequiredUniqueChars = 1;
	option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
	option.Lockout.MaxFailedAccessAttempts = 100;
}).AddEntityFrameworkStores<AppDbContext>()
				.AddDefaultTokenProviders();

builder.Services.AddHttpClient();
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.ConfigureApplicationCookie(options => {
	options.LoginPath = "/Account/Login";
	options.AccessDeniedPath = "/Account/AccessDenied";
	options.SlidingExpiration = true;
	options.ExpireTimeSpan = TimeSpan.FromDays(30);
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );
});


app.Run();