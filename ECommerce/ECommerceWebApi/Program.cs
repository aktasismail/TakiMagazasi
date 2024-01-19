using ECommerceBusiness.Abstract;
using ECommerceDataAccess.Abstract;
using ECommerceDataAccess.Concrete;
using ECommerceDataAccess.Data;
using ECommerceWebApi.Extension;
using ECommerceWebApi.Hubs;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(opt =>
{
	opt.AddPolicy("CorsPolicy", builder =>
	{
		builder.AllowAnyHeader()
		.AllowAnyMethod()
		.SetIsOriginAllowed((host) => true)
		.AllowCredentials();
	});
});
builder.Services.AddSignalR();

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.ConfigureDataAccessLayer();
builder.Services.ConfigureBusinessLayer();
builder.Services.AddAuthentication();
builder.Services.AddControllersWithViews()
	.AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapHub<SignalRHub>("/signalrhub");
app.Run();