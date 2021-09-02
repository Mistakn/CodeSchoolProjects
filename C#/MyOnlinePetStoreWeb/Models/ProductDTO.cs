using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyOnlinePetStoreWeb.Models {
    public class ProductDTO {

        public int ProductID { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public IFormFile Image { get; set; }

        public string ImageURL { get; set; }

        public int Quantity { get; set; }

    }
}