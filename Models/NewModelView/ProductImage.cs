using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ciel.Models.NewModelView
{
    public class ProductImage
    {

        [Key]
        public int Id { get; set; }
		[Required(ErrorMessage = "Полето е задължително")]
		[DisplayName("Име")]
        public string ProductName { get; set; }
		[Required(ErrorMessage = "Полето е задължително")]
		[DisplayName("Описание")]
        public string Description { get; set; }
		[Required(ErrorMessage = "Полето е задължително")]
		[DisplayName("Снимка")]
        [ValidateNever]
        public IFormFile? Picture { get; set; }
		[Required(ErrorMessage = "Полето е задължително")]
		[DisplayName("Цена")]
        public double Price { get; set; }
		[Required(ErrorMessage = "Полето е задължително")]
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
