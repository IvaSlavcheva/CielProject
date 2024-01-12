using Microsoft.AspNetCore.Identity;

namespace Ciel.Models
{
    public class User : IdentityUser
    {
        public string NationalId { get; set; } 
        List<Order> Orders { get; set; }

        public User()
        {
            Orders = new List<Order>();
        }
    }
}
