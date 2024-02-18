using ECommerceDataAccess.Data;
using ECommerceWebUi.Extension;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddDbContext<AppDbContext>();
builder.Services.ConfigureIdentity();
builder.Services.ConfigureDataAccessLayer();
builder.Services.ConfigureBusinessLayer();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddAuthentication();
builder.Services.ConfigureSession();
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
app.UseSession();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );
});
 app.Run();