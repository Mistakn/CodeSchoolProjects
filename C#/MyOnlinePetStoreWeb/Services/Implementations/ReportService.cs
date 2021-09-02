using Microsoft.EntityFrameworkCore;
using MyOnlinePetStoreWeb.Data;
using MyOnlinePetStoreWeb.Entities;
using MyOnlinePetStoreWeb.Models;
using MyOnlinePetStoreWeb.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyOnlinePetStoreWeb.Services.Implementations {
    public class ReportService : IDbReportService {

        private readonly ApplicationDbContext _context;


        public ReportService(ApplicationDbContext context) {
            _context = context;
        }


        // Customer Methods
        public async Task<Customer> GetCustomerWithMostOrdersAsync() {
            return await _context.Customers
                .Include(customer => customer.Orders)
                .OrderByDescending(customer => customer.Orders.Count)
                .FirstOrDefaultAsync();
        }

        public async Task<Customer> GetCustomerWithMostBuysAsync() {
            return await _context.Customers
                .OrderByDescending(customer => customer.Orders.Count)
                .FirstOrDefaultAsync();
        }
        // END Customer Methods


        // Order methods
        public async Task<List<Order>> GetOrdersByMonthAsync(DateTime firstDayOfMonth, DateTime lastDayOfMonth) {
            return await _context.Orders
                .Include(order => order.ProductOrders)
                .ThenInclude(productOrders => productOrders.Product)
                .Where(order => order.OrderFulfilled >= firstDayOfMonth && order.OrderFulfilled <= lastDayOfMonth).ToListAsync();
        }

        public async Task<List<OrderDTO>> GetOrdersOfMonthAsync() {
            return await _context.Orders
                .Where(order => order.OrderPlaced.Month == DateTime.Now.Month && order.OrderPlaced.Year == DateTime.Now.Year)
                .Select(order => new OrderDTO {
                    OrderID = order.OrderID,
                    Customer = order.Customer.FirstName + " " + order.Customer.LastName,
                    Total = order.ProductOrders.Sum(
                        productOrder => (productOrder.Product.Price * productOrder.Quantity)),
                    Products = order.ProductOrders.Select(
                        productOrder => new ProductDTO {
                            Name = productOrder.Product.Name,
                            Quantity = productOrder.Quantity
                        })
                }).ToListAsync();
        }

        public async Task<string> GetCountryWithMostOrdersAsync() {
            var countryWithMostSoldOrders = await _context.Orders
                .Include(order => order.Customer)
                .GroupBy(order => order.Customer.Address.Country)
                .Select(x => new { country = x.Key, orderCount = x.Count() })
                .OrderByDescending(x => x.orderCount)
                .SingleOrDefaultAsync();

            return countryWithMostSoldOrders.country;
        }
        // END Order methods


        // Product methods
        public async Task<Product> GetMostSoldProductAsync() {
            var highestSoldProductID = await _context.ProductOrders
                .Include(productOrder => productOrder.Product)
                .GroupBy(productOrder => productOrder.ProductID)
                .Select(x => new { productID = x.Key, productCount = x.Count() })
                .OrderByDescending(x => x.productCount)
                .FirstOrDefaultAsync();

            return await _context.Products
                .SingleOrDefaultAsync(product => product.ProductID == highestSoldProductID.productID);
        }
        // END Product methods

    }
}
