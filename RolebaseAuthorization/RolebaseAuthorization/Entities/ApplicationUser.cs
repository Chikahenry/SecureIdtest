using Microsoft.AspNetCore.Identity;

namespace RolebaseAuthorization.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() { }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
    }
}
