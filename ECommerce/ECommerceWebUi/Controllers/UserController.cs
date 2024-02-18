using ECommerceBusiness.Abstract;
using ECommerceEntities;
using ECommerceWebUi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ECommerceWebUi.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ICommentService _commentService;
        private readonly IFavouriteService _favouriteService;
        private readonly IOrderService _orderService;
        public UserController(UserManager<AppUser> userManager, ICommentService commentService, IFavouriteService favouriteService, IOrderService orderService)
        {
            _userManager = userManager;
            _commentService = commentService;
            _favouriteService = favouriteService;
            _orderService = orderService;
        }
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var myorder = await _orderService.MyOrders(userId);
            return View(myorder);
        }
        public IActionResult MyComment()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var comment = _commentService.TGetListAll().Result.Where(x => x.Uid.Equals(userId));
            return View(comment);
        }
        public async Task<IActionResult> DeleteComment(int id)
        {
            var value = await _commentService.TGetByID(id);
            await _commentService.TDelete(value);
            return RedirectToAction("MyComment");
        }
        public async Task<IActionResult> EditProfile()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var user = await _userManager.FindByIdAsync(userId);

            if (user != null)
            {
                return View(new EditProfileVM
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserName = user.UserName,
                    Email = user.Email,
                });
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> EditProfile(EditProfileVM model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId != model.Id)
            {
                return RedirectToAction("Index");
            }
            var user = await _userManager.FindByIdAsync(model.Id);
            if (user != null)
            {
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.UserName = model.UserName;
                user.Email = model.Email;
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded && !string.IsNullOrEmpty(model.Password))
                {
                    await _userManager.RemovePasswordAsync(user);
                    await _userManager.AddPasswordAsync(user, model.Password);
                }
                foreach (IdentityError err in result.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                }

            }
            return RedirectToAction("Index");
        }
    }
}
