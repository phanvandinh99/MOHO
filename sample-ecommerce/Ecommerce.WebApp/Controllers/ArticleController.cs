using Ecommerce.Data.DataContext;
using Ecommerce.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.WebApp.Controllers
{
    [Route("article")]
    public class ArticleController : Controller
    {
        private readonly DataDbContext _context;

        public ArticleController(DataDbContext context)
        {
            _context = context;
        }

        [Route("")]
        public async Task<IActionResult> Index()
        {
            List<Article> articles = await _context.Articles.ToListAsync();
            return View(articles);
        }

        [Route("{id}")]
        public async Task<IActionResult> Detail(int id)
        {
            var article = await _context.Articles.FindAsync(id);
            return View(article);
        }
    }
}
