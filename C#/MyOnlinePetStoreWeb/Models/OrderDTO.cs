using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyOnlinePetStoreWeb.Models {
    public class OrderDTO {

        public int OrderID { get; set; }
        public string Customer { get; set; }
        public decimal Total { get; set; }
        public IEnumerable<ProductDTO> Products { get; set; }
        public string Status { get; private set; }

    }
}
