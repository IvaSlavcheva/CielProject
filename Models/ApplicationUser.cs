using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ciel.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(64)]
        [Display(Name = "Име")]
        public string Name { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [MaxLength(10)]
        [Required]
        [Display(Name = "ЕГН")]
        public string EGN { get; set; }
    }
}
