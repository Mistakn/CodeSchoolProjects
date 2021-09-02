using MyOnlinePetStore.Models;
using System.Collections.Generic;

namespace MyOnlinePetStore.Services {
    public class OrderDTO {
        public int OrderID { get; set; }
        public string Customer { get; set; }
        public decimal Total { get; set; }
        public IEnumerable<ProductDTO> Products { get; set; }
    }
}