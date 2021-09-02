using MyOnlinePetStoreWeb.Entities;
using MyOnlinePetStoreWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyOnlinePetStoreWeb.Services.Interfaces {
    public interface IDbReportService {

        // Customer Methods
        Task<Customer> GetCustomerWithMostOrdersAsync();

        Task<Customer> GetCustomerWithMostBuysAsync();
        // END Customer Methods


        // Order methods
        Task<List<Order>> GetOrdersByMonthAsync(DateTime firstDayOfMonth, DateTime lastDayOfMonth);

        Task<List<OrderDTO>> GetOrdersOfMonthAsync();

        Task<string> GetCountryWithMostOrdersAsync();
        // END Order methods


        // Product methods
        Task<Product> GetMostSoldProductAsync();
        // END Product methods

    }
}
