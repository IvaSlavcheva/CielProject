using System.ComponentModel.DataAnnotations;

namespace Ciel.Models
{
    public class Cart_Product
    {
        public Cart_Product( int cartId, int productId)
        {
           
            CartId = cartId;
            ProductId = productId;
        }

        [Key]
        public int Id { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }  

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
