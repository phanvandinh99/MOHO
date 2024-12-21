using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Data.Entities
{
    public class Article
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Slug { get; set; }

        public string Content { get; set; }

        public string Image { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }

        public bool IsPublished { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
