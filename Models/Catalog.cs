using System.ComponentModel.DataAnnotations;

namespace Ciel.Models
{
    public class Catalog
    {
        [Key]
        public int Id { get; set; }
        public string CatalogName { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
        public Catalog( string catalogName)
        {
           
            CatalogName = catalogName;
        }
    }
}
