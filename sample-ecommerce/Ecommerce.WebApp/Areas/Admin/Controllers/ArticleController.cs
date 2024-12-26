using Ecommerce.Common;
using Ecommerce.Data.DataContext;
using Ecommerce.Data.Entities;
using Ecommerce.Data.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ecommerce.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/article")]
    [Authorize(Roles = "Admin")]
    public class ArticleController : Controller
    {
        private readonly DataDbContext _context;

        public ArticleController(DataDbContext context)
        {
            _context = context;
        }

        [Route("index")]
        [Route("")]
        public async Task<IActionResult> Index()
        {
            var item = _context.Articles.OrderByDescending(p => p.Id).ToList();
            return View(item);
        }

        [Route("create")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateArticleViewModel model)
        {
            string POST_IMAGE_PATH = "article/";

            if (model.Image != null)
            {

                var image = UploadImage.UploadImageFile(model.Image, POST_IMAGE_PATH);

                Article item = new Article()
                {
                    Title = model.Title,
                    Slug = TextHelper.ToUnsignString(model.Title).ToLower(),
                    Content = model.Content,
                    Image = image,
                    PublishDate = DateTime.Now,
                    IsPublished = true,
                    CreatedAt = DateTime.Now
                };

                _context.Add(item);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        // Cập nhật bài viết
        [Route("update/{id}")]
        [HttpGet]
        public IActionResult Update(int id)
        {
            var item = _context.Articles.Find(id);
            return View(item);
        }

        [Route("update/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, CreateArticleViewModel model)
        {
            Article item = _context.Articles.Find(id);
            item.Title = model.Title;
            item.Content = model.Content;
            _context.Update(item);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Article");
        }

        [Route("update-image/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateImage(int id, IFormFile UrlImage)
        {
            string POST_IMAGE_PATH = "article/";

            if (UrlImage != null)
            {

                var image = UploadImage.UploadImageFile(UrlImage, POST_IMAGE_PATH);

                Article item = _context.Articles.Find(id);
                item.Image = image;
                _context.Update(item);
                await _context.SaveChangesAsync();
                return Redirect("/admin/article/update/" + id);
            }
            return Redirect("/admin/article/update/" + id);
        }


        [HttpGet("delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Article item = _context.Articles.Find(id);
                _context.Articles.Remove(item);
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
                var item = await _context.Articles.FindAsync(id);
                _context.Articles.Remove(item);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }




    }
}
