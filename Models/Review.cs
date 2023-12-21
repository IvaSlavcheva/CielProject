using System.ComponentModel.DataAnnotations;

namespace Ciel.Models
{
    public class Review
    {
        public Review( int productId, string description)
        {
         
            ProductId = productId;
            Description = description;
        }

        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Description { get; set; }
    }
}
