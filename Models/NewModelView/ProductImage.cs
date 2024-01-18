using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Ciel.Models.NewModelView
{
    public class ProductImage
    {

        [Key]
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }

        public IFormFile Picture { get; set; }
        public double Price { get; set; }
        public int CatalogId { get; set; }

		[ValidateNever]
		public Catalog Catalog { get; set; }

        //Relacii

        [ValidateNever]
        public ICollection<Review> Reviews { get; set; }
		
        [ValidateNever]
		public ICollection<Cart_Product> Orders { get; set; }

    }
}
