using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ciel.Models
{
    public class ApplicationUser : IdentityUser
    {
        //public ApplicationUser()
        //{
        //    Cart userCart = new Cart();
        //}

        [MaxLength(30)]
        [Required]
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

        //public int CartId { get; set; }

        //[ForeignKey("CartId")]
        //public Cart Cart { get; set; }
    }
}
