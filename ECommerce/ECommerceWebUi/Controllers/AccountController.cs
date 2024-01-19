using ECommerceEntities.Dto.CreateDto;
using ECommerceEntities.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ECommerceWebUi.Models;
using ECommerceEntities.ViewModels;
using JsonSerializer = System.Text.Json.JsonSerializer;
using ECommerceEntities;
using Microsoft.AspNetCore.Identity;

namespace ECommerceWebUi.Controllers
{
    public class AccountController : Controller
    {
		private UserManager<AppUser> _userManager;
		private RoleManager<IdentityRole> _roleManager;
		private SignInManager<AppUser> _signInManager;
		public AccountController(
			UserManager<AppUser> userManager,
			RoleManager<IdentityRole> roleManager,
			SignInManager<AppUser> signInManager)
		{
			_userManager = userManager;
			_roleManager = roleManager;
			_signInManager = signInManager;
		}
		public IActionResult Login()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Login(UserLoginModel model)
		{
			if (ModelState.IsValid)
			{
				var entity = await _userManager.FindByEmailAsync(model.Email);
				if (entity != null)
				{
					await _signInManager.SignOutAsync();
					var sonuc = await _signInManager.PasswordSignInAsync(entity, model.Password, model.RememberMe, true);
					if (sonuc.Succeeded)
					{
						await _userManager.ResetAccessFailedCountAsync(entity);
						await _userManager.SetLockoutEndDateAsync(entity, null);
						return RedirectToAction("Index", "Product");
					}
					else if (sonuc.IsLockedOut)
					{
						var kacdakika = await _userManager.GetLockoutEndDateAsync(entity);
						var bloekesayacı = kacdakika.Value - DateTime.UtcNow;
						ModelState.AddModelError("", $"Hesabınız kitlendi, Lütfen {kacdakika.Value} dakika sonra deneyiniz");
					}
				}
				else
				{
					ModelState.AddModelError("", "Kullanıcı bulunamadı");
				}

				return View(model);
			}
			ModelState.AddModelError("", $"Lütfen tüm alanları dolddurunuz");
			return RedirectToAction("Register");
		}
		public IActionResult Register()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Register(UserRegisterModel model)
		{
			if (ModelState.IsValid)
			{
				var yeni = new AppUser
				{
					FirstName = model.FirstName,
					Lastame = model.LastName,
					UserName = model.UserName,
					Email = model.Email,
				};
				IdentityResult result = await _userManager.CreateAsync(yeni, model.Password);
				if (result.Succeeded)
				{
					var addrole = await _userManager.AddToRoleAsync(yeni, "User");

					if (addrole.Succeeded)
					{
						return RedirectToAction("Login", "Account");
					}
				}
				foreach (IdentityError hata in result.Errors)
				{
					ModelState.AddModelError("", hata.Description);
				}
			}
			return View(model);
		}
		public async Task<IActionResult> CikisYap([FromQuery(Name = "ReturnUrl")] string ReturnUrl = "/")
		{
			await _signInManager.SignOutAsync();
			return Redirect(ReturnUrl);
		}
	}
}
