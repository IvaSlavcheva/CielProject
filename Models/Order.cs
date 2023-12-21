using System.ComponentModel.DataAnnotations;

namespace Ciel.Models
{
    public class Order
    {
        public Order(int userId, double price, DateTime shipping)
        {
           
            UserId = userId;
            Price = price;
            Shipping = shipping;
            this.Products =new List<Product>();
        }

        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public double Price { get; set; }
        [DataType(DataType.Date)]
        public DateTime Shipping { get; set; }

        //Relacii
        public ICollection<Product> Products { get; set; }
    }
}
