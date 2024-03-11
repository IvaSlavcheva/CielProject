using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ciel.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Полето е задължително")]
        [DisplayName("Държава")]
        public string Country { get; set; }
		[Required(ErrorMessage = "Полето е задължително")]
		[DisplayName("Град")]
        public string City { get; set; }
		[Required(ErrorMessage = "Полето е задължително")]
		[DisplayName("Пощенски код")]
        public string ZipCode { get; set; }
		[Required(ErrorMessage = "Полето е задължително")]
		[DisplayName("Улица")]
        public string Street { get; set; }
    }
}
