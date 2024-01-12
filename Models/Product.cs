using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Ciel.Models
{
    public class Product
    {
        public Product() { }


        public Product( string productName, string description, string picture, double price, Catalog catalog)
        {
            
            ProductName = productName;
            Description = description;
            Picture = picture;
            Price = price;
            Catalog = catalog;
            //Reviews = new List<Review>();
            //Orders = new List<Order_Product>();
        }

        [Key]
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public double Price { get; set; }
        public int CatalogId { get; set; }
        public Catalog Catalog { get; set; }
    
        //Relacii
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Order_Product> Orders { get; set; }
    }
}
