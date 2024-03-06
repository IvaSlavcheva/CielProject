using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.ComponentModel;

namespace Ciel.Models
{
    public class Order
    {
            [Key]
            public int Id { get; set; }

            [Required]
            [ForeignKey("UserId")]
            public string UserId { get; set; }

            [Required]
            [Range(0.00, double.MaxValue, ErrorMessage = "Цената трябва да бъде положително число.")]
            [DisplayName("Цена")]
            public double TotalPrice { get; set; }

            [Required]
            [DisplayName("Адрес")]
            public int AddressId { get; set; }

            [ForeignKey("AddressId")]
            public Address? Address { get; set; }
            [Required]
            public DateTime CreatedDate = DateTime.Now.Date;

            [Required]
            [Display(Name ="Очаквана дата за доставка: ")]

            public DateTime ExceptedDeliveryDate = DateTime.Now.Date.AddDays(10);
            public List<OrderProduct> Products { get; set; } = new List<OrderProduct>();
    }
}

