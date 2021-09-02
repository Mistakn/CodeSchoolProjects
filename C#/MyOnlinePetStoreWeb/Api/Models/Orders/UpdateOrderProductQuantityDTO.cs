using MyOnlinePetStoreWeb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyOnlinePetStoreWeb.Api.Models.Orders {
    public class UpdateOrderProductQuantityDTO {

        public int UserId { get; set; }

        public string UserName { get; set; }

        public int ProductID { get; set; }

        public int Quantity { get; set; }
    }
}
