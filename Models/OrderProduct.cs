using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ciel.Models
{
    public class OrderProduct
    {
            [Key]
            public int Id { get; set; }
            [Display(Name = "Продукт")]
            public int ProductId { get; set; }

            [ForeignKey("ProductId")]
            public Product? Product { get; set; }

            [Display(Name = "Поръчка")]
            public int OrderId { get; set; }

            [ForeignKey("OrderId")]
            public Order? Order { get; set; }
        
    }
}

