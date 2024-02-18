using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebUi.ViewComponents
{
    public class NavbarVC :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
