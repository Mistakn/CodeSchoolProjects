using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyOnlinePetStoreWeb.Data {
    public enum OrderStatusesEnum {
        Pending,
        Preparing,
        Sent,
        Completed,
        Cancelled
    }
}
