using Microsoft.AspNetCore.Http;

namespace Ecommerce.Data.ViewModel
{
    public class CreateArticleViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Slug { get; set; }

        public string Content { get; set; }

        public IFormFile Image { get; set; }

        public DateTime PublishDate { get; set; }

        public bool IsPublished { get; set; }
    }
}