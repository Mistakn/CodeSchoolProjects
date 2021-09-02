using MyOnlinePetStoreWeb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyOnlinePetStoreWeb.Models.ViewModels {
    public class OrdersVM {

        public List<Order> Orders { get; set; }

        public string SearchQuery { get; set; }

        public Order MostRecentOrder { get; set; }

    }
}
