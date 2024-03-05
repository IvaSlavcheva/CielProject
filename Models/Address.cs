using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ciel.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Държава")]
        public string Country { get; set; }
        [Required]
        [DisplayName("Град")]
        public string City { get; set; }
        [Required]
        [DisplayName("Пощенски код")]
        public string ZipCode { get; set; }
        [Required]
        [DisplayName("Улица")]
        public string Street { get; set; }
    }
}
