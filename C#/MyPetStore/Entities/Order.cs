using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPetStore.Entities {
    public class Order {

        [Key]
        public int OrderID { get; set; }

        public DateTime OrderPlaced { get; set; }

        public DateTime OrderFilfilled { get; set; }

        public Customer Customer { get; set; }

        public ICollection<ProductOrder> ProductOrders { get; set; }
    }
}
