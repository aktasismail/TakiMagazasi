using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebUi.Controllers
{
    [Authorize]
    public class StatisticController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
