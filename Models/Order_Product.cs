using System.ComponentModel.DataAnnotations;

namespace Ciel.Models
{
    public class Order_Product
    {
        public Order_Product( int orderId, int productId)
        {
           
            OrderId = orderId;
            ProductId = productId;
        }

        [Key]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }  

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
