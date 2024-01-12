using Microsoft.AspNetCore.Identity;

namespace Ciel.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string EGN { get; set; }
    }
}
