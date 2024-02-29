using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ciel.Models
{
    public class Product
    {
        public Product() { }

        [Key]
        public int Id { get; set; }
        [DisplayName("Име")]
        public string ProductName { get; set; }
        [DisplayName("Описание")]
        public string Description { get; set; }
        [DisplayName("Снимка")]
        public string Picture { get; set; }
        [DisplayName("Цена")]
        public double Price { get; set; }
        
        public int CatalogId { get; set; }
        [DisplayName("Каталог")]
        public Catalog Catalog { get; set; }
    
        //Relacii
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Cart_Product> Orders { get; set; }
    }
}
