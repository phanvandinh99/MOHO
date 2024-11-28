using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin")]
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
