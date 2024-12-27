using Ecommerce.Data.DataContext;
using Ecommerce.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ecommerce.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataDbContext _context;

        public HomeController(ILogger<HomeController> logger, DataDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.ListProducts = _context.Products.OrderByDescending(c => c.Id).ToList();

            // Hiển thị danh sách bài viết (3 bài viết mới nhất)
            ViewBag.ListArticles = _context.Articles.OrderByDescending(c => c.Id).ToList().Take(4);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult LienHe()
        {
            return View();
        }
    }
}