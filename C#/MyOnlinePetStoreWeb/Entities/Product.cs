using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyOnlinePetStoreWeb.Entities {
    public class Product {

        [Key]
        public int ProductID { get; private set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; private set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; private set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; private set; }

        public DateTime CreatedDate { get; private set; } = DateTime.Now;

        [MaxLength(1000)]
        public string ImageURL { get; private set; }

        public int? ProductBrandId { get; private set; }

        public ProductBrand Brand { get; private set; }

        public int? ProductTypeId { get; private set; }

        public ProductType Type { get; private set; }


        public Product() { }
        public Product(string name, string description, decimal price) {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Price = price > 0 ? price : throw new InvalidOperationException(nameof(price));
        }



        public void Update(string name, string description, decimal price) {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Price = price > 0 ? price : throw new InvalidOperationException(nameof(price));
        }


        public void UpdateImage(string imageURL) {
            ImageURL = imageURL ?? throw new ArgumentNullException(nameof(imageURL));
        }


        public void UpdateType(int typeId) {
            ProductTypeId = typeId;
        }

        public void UpdateBrand(int brandId) {
            ProductBrandId = brandId;
        }
    }
}
