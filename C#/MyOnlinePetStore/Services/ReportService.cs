using Microsoft.EntityFrameworkCore;
using MyOnlinePetStore.Data;
using MyOnlinePetStore.Entities;
using MyOnlinePetStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOnlinePetStore.Services {
    class ReportService : IDisposable {

        private readonly ApplicationContext _context;

        public ReportService() {
            _context = new ApplicationContext();
        }


        // Customer Methods
        public Customer GetCustomerWithMostOrders() {
            return _context.Customers
                .Include(customer => customer.Orders)
                .OrderByDescending(customer => customer.Orders.Count)
                //.GroupBy(customer => customer.CustomerID)
                //.Select(x => new { customerID = x.Key, orderCount = x.Count() })
                //.OrderByDescending(x => x.orderCount)
                .First();

            //return _context.Customers
            //    .Include(customer => customer.Orders)
            //    .SingleOrDefault(customer => customer.CustomerID == highestOrderCountCustomer.customerID);
        }


        public Customer GetCustomerWithMostBuys() {
            return _context.Customers
                .OrderByDescending(customer => customer.Orders.Count())
                .FirstOrDefault();
        }
        // END Customer Methods



        // Order methods
        public List<Order> GetOrdersByMonth(DateTime firstDayOfMonth, DateTime lastDayOfMonth) {
            return _context.Orders
                .Include(order => order.ProductOrders)
                .ThenInclude(productOrders => productOrders.Product)
                .Where(order => order.OrderFulfilled >= firstDayOfMonth && order.OrderFulfilled <= lastDayOfMonth).ToList();
        }


        public List<OrderDTO> GetOrdersOfMonth() {
            return _context.Orders
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
                }).ToList();
        }


        public string GetCountryWithMostOrders() {
            var countryWithMostSoldOrders = _context.Orders
                .Include(order => order.Customer)
                .GroupBy(order => order.Customer.Address.Country)
                .Select(x => new { country = x.Key, orderCount = x.Count() })
                .OrderByDescending(x => x.orderCount)
                .Single();

            return countryWithMostSoldOrders.country;
        }
        // END Order methods



        // Product methods
        public Product GetMostSoldProduct() {
            var highestSoldProductID = _context.ProductOrders
                .Include(productOrder => productOrder.Product)
                .GroupBy(productOrder => productOrder.ProductID)
                .Select(x => new { productID = x.Key, productCount = x.Count() })
                .OrderByDescending(x => x.productCount)
                .First();

            return _context.Products
                .SingleOrDefault(product => product.ProductID == highestSoldProductID.productID);
        }
        // END Product methods

        public void Dispose() {
            _context.Dispose();
        }
    }
}
