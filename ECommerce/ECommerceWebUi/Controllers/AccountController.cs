using Microsoft.AspNetCore.Mvc;
using ECommerceEntities;
using Microsoft.AspNetCore.Identity;
using ECommerceEntities.Dto;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;
using System.Text;
using Newtonsoft.Json;
using ECommerceEntities.ViewModels;

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
        public async Task<IActionResult> Login(LoginDto model)
        {
            if (ModelState.IsValid)
            {
                var entity = await _userManager.FindByNameAsync(model.UserName);
                if (entity != null)
                {
                    await _signInManager.SignOutAsync();
                    var sonuc = await _signInManager.PasswordSignInAsync(entity, model.Password, model.RememberMe, true);
                    if (sonuc.Succeeded)
                    {
                        await _userManager.ResetAccessFailedCountAsync(entity);
                        await _userManager.SetLockoutEndDateAsync(entity, null);
                        return RedirectToAction("Index", "Home");
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
        public async Task<IActionResult> Register(RegisterDto model)
        {
            if (ModelState.IsValid)
            {
                var yeni = new AppUser
                {
                    FirstName = model.Name,
                    LastName = model.Surname,
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
        public async Task<IActionResult> Logout([FromQuery(Name = "ReturnUrl")] string ReturnUrl = "/")
        {
            await _signInManager.SignOutAsync();
            return Redirect(ReturnUrl);
        }
    }
}
