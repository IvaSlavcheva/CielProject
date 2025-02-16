﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ciel.Models
{
    public class Catalog
    {
        [Key]
        public int Id { get; set; }

		[Required(ErrorMessage = "Полето е задължително")]
		[DisplayName("Име")]
        public string CatalogName { get; set; }
    }
}
