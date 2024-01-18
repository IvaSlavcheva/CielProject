using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ciel.Models
{
    public class Cart
    {
  /*      public Cart(string userId, double price, DateTime shipping)
        {
           
            UserId = userId;
            Price = price;
            Shipping = shipping;
            this.Products =new List<Cart_Product>();
        }*/

        [Key]
        public int Id { get; set; }

        public double Price { get; set; }
      
        [DataType(DataType.Date)]
        public DateTime Shipping { get; set; }

        public ApplicationUser User { get; set; }

        public ICollection<Cart_Product> Products { get; set; }
    }
}
