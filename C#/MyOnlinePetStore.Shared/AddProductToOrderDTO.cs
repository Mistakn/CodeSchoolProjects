using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOnlinePetStore.Shared {
    public class AddProductToOrderDTO {
        public int? UserId { get; set; }

        public string? UserName { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
