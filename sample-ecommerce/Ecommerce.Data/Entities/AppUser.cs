using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Data.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? FullName { get; set; }
        public DateTimeOffset? DateOfBirth { get; set; }
        public string? Address { get; set; }
        public string? UrlAvatar { get; set; }
    }
}
