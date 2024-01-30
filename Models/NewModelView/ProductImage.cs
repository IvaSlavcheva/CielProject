using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ciel.Models.NewModelView
{
    public class ProductImage
    {

        [Key]
        public int Id { get; set; }
        [DisplayName("Име")]
        public string ProductName { get; set; }
        [DisplayName("Описание")]
        public string Description { get; set; }
        [DisplayName("Снимка")]
        [ValidateNever]
        public IFormFile? Picture { get; set; }
        [DisplayName("Цена")]
        public double Price { get; set; }
        [DisplayName("Каталог")]
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
