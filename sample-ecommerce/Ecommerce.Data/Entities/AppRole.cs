using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Data.Entities
{
    public class AppRole : IdentityRole<Guid>
    {
        public string? Description { get; set; }
    }
}
