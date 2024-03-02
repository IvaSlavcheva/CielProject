using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ciel.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required(ErrorMessage = "Полето е задължително.")]
        [MaxLength(64, ErrorMessage = "Полето {0} не може да има повече от {1} символа.")]
        [Display(Name = "Име")]
        public string Name { get; set; }
        [MaxLength(30)]
        [Required]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
        [MaxLength(10)]
        [Required]
        [Display(Name = "ЕГН")]
        public string EGN { get; set; }
    }
}
