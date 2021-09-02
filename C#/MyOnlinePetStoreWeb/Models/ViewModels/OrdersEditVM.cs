using MyOnlinePetStoreWeb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyOnlinePetStoreWeb.Models.ViewModels {
    public class OrdersEditVM {

        public Order Order { get; set; }

        public Order MostRecentOrder { get; set; }

    }
}
