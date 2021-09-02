using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyOnlinePetStoreWeb.Entities {
    public class ProductOrder {

        [Key]
        public int ProductOrderID { get; set; }

        public int Quantity { get; set; }

        public int ProductID { get; set; }

        public int OrderID { get; set; }

        public Order Order { get; set; }

        public Product Product { get; set; }

    }
}
