using Ecommerce.Data.DataContext;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebApp.Controllers
{
    [ViewComponent]
    public class DanhMucViewComponent : ViewComponent
    {
        private readonly DataDbContext _context;

        public DanhMucViewComponent(DataDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _context.Categories
                                     .OrderBy(c => c.Name)
                                     .ToList();

            return View("Default", categories);
        }
    }
}
