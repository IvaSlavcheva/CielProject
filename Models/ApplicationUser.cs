using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ciel.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string EGN { get; set; }

        public int CartId { get; set; }

        [ForeignKey("CartId")]
        public Cart Cart { get; set; }
    }
}
