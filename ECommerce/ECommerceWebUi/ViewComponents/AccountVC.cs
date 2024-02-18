using ECommerceBusiness.Abstract;
using ECommerceEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ECommerceWebUi.ViewComponents
{
    public class AccountVC : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public AccountVC(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var name = HttpContext.User.Identity.Name;
            var entity = await _userManager.FindByNameAsync(name);
            return View(entity);
        }
    }
}
