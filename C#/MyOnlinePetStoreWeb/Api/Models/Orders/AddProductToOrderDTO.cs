using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyOnlinePetStoreWeb.Api.Models.Orders {
    public class AddProductToOrderDTO {

        public int UserId { get; set; }

        public string UserName { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
