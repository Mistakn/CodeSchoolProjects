using Microsoft.EntityFrameworkCore;
using MyOnlinePetStore.Data;
using MyOnlinePetStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOnlinePetStore.Services {
    class ShopService : IDisposable {

        private readonly ApplicationContext _context;

        public ShopService() {
            _context = new ApplicationContext();
        }


        // Product Methods
        public List<Product> GetProducts() {
            return _context.Products.ToList();
        }


        public Product GetProduct(int productID) {
            return _context.Products.SingleOrDefault(product => product.ProductID == productID);
        }


        public void AddProduct(Product product) {
            _context.Add(product);
            _context.SaveChanges();
        }
        // END Product Methods



        // Customer Methods
        public List<Customer> GetCustomers() {
            return _context.Customers.ToList();
        }


        public Customer GetCustomer(string name) {
            return _context.Customers
                .Include(customer => customer.Orders)
                .ThenInclude(order => order.ProductOrders)
                .SingleOrDefault(customer => customer.FirstName == name);
        }


        public void AddCustomer(Customer customer) {
            _context.Add(customer);
            _context.SaveChanges();
        }


        public void AddOrderToCustomer(Customer customer, Order order) {
            customer.Orders.Add(order);
            _context.SaveChanges();
        }


        public void UpdateCustomerAddress(Customer customer, Address address) {
            customer.Address = address;
            _context.SaveChanges();
        }


        public void UpdateCustomerPhone(Customer customer, string phone) {
            customer.UpdatePhone(phone);
            _context.SaveChanges();
        }


        public Customer IsCustomerRegistered(string name) {
            return _context.Customers.FirstOrDefault(customer => customer.FirstName == name);
        }
        // END Customer Methods



        // Order Methods
        public void AddProductToOrder(Order order, ProductOrder productOrder) {
            order.ProductOrders.Add(productOrder);
            _context.SaveChanges();
        }


        public void UpdateOrderProductQuantity(Order order, int productID, int productQuantity) {
            order.UpdateProductQuantity(productID, productQuantity);
            _context.SaveChanges();
        }


        public void CompleteOrder(Order order) {
            order.CompleteOrder();
            _context.SaveChanges();
        }
        // END Order Methods


        public void Dispose() {
            _context.Dispose();
        }
    }
}
