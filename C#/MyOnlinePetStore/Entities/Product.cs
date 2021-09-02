using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOnlinePetStore.Entities {
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

        private static int Seed = 1;


        public Product() { }
        public Product(string name, string description, decimal price) {

            //ProductID = Seed;
            //Seed++;

            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Price = price > 0 ? price : throw new InvalidOperationException(nameof(price));
        }


        public void Update(string name, string description, decimal price) {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Price = price > 0 ? price : throw new InvalidOperationException(nameof(price));
        }
    }
}
