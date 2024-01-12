using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ciel.Models
{
    public class Order
    {
        public Order(string userId, double price, DateTime shipping)
        {
           
            UserId = userId;
            Price = price;
            Shipping = shipping;
            this.Products =new List<Order_Product>();
        }

        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }
        public double Price { get; set; }
      
        [DataType(DataType.Date)]
        public DateTime Shipping { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        public ICollection<Order_Product> Products { get; set; }
    }
}
