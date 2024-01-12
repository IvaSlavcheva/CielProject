namespace Ciel.Models
{
    public class Catalog_Product
    {
        public int CatalogId { get; set; }
        public Catalog Catalog { get; set; }    
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
