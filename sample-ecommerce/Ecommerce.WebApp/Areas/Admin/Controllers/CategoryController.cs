using Ecommerce.Common;
using Ecommerce.Data.DataContext;
using Ecommerce.Data.Entities;
using Ecommerce.Data.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/category")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly DataDbContext _context;

        public CategoryController(DataDbContext context)
        {
            _context = context;
        }

        [Route("index")]
        [Route("")]
        public async Task<IActionResult> Index(string q)
        {
            var item = from m in _context.Categories
                       select m;

            if (!String.IsNullOrEmpty(q))
            {
                item = item.Where(s => s.Name.Contains(q));
            }

            return View(await item.OrderByDescending(p => p.Id).ToListAsync());
        }

        [Route("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                Category item = new Category()
                {
                    Name = model.Name,
                    Slug = TextHelper.ToUnsignString(model.Name).ToLower(),
                    Status = true
                };

                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [Route("update/{id}")]
        public IActionResult Update(int id)
        {
            var item = _context.Categories.Where(s => s.Id == id).First();
            return View(item);
        }

        [Route("update/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, UpdateCategoryViewModel model)
        {
            Category item = _context.Categories.Where(s => s.Id == id).First();
            item.Name = model.Name;
            _context.Update(item);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Category");
        }

        [HttpGet("delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Category item = _context.Categories.Where(s => s.Id == id).First();
                _context.Categories.Remove(item);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (System.Exception)
            {
                return RedirectToAction("Index");
            }

        }

        [HttpPost("delete-selected")]
        public async Task<IActionResult> DeleteSelected(int[] listDelete)
        {
            foreach (int id in listDelete)
            {
                var doctors = await _context.Categories.FindAsync(id);
                _context.Categories.Remove(doctors);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


    }
}
