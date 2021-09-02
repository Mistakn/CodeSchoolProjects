using Microsoft.EntityFrameworkCore;
using MyOnlinePetStore.Shared;
using MyOnlinePetStoreWeb.Data;
using MyOnlinePetStoreWeb.Entities;
using MyOnlinePetStoreWeb.Models;
using MyOnlinePetStoreWeb.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyOnlinePetStoreWeb.Services.Implementations {
    public class ShopService : IDbShopService {

        private readonly ApplicationDbContext _context;


        public ShopService(ApplicationDbContext context) {
            _context = context;
        }


        // Product Methods
        public async Task<List<Product>> GetProductsAsync() {
            return await _context.Products.ToListAsync();
        }

        public async Task<List<Product>> GetProductsByNameAsync(string name) {
            return await _context.Products.Where(p => p.Name.Contains(name)).ToListAsync();
        }

        public async Task<List<Product>> GetProductsByFilterAsync(string name, int? brand, bool order) {
            var products = await GetProductsAsync();

            if (name != null) {
                products = products.Where(p => p.Name.Contains(name)).ToList();
            }

            if (brand.HasValue) {
                products = products.Where(p => p.ProductBrandId == brand).ToList();
            }

            if (order) {
                products = products.OrderBy(p => p.Name).ToList();
            } else {
                products = products.OrderByDescending(p => p.Name).ToList();
            }

            return products;
        }

        public async Task<Product> GetProductAsync(int productID) {
            return await _context.Products.SingleOrDefaultAsync(product => product.ProductID == productID);
        }

        public async Task AddProductAsync(Product product) {
            await _context.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(Product product) {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int productID) {

            Product product = await _context.Products.SingleOrDefaultAsync(product => product.ProductID == productID);

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
        // END Product Methods


        // Customer Methods
        public async Task<List<Customer>> GetCustomersAsync() {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetCustomerAsync(string name) {
            return await _context.Customers
                .Include(customer => customer.Orders)
                .ThenInclude(order => order.ProductOrders)
                .SingleOrDefaultAsync(customer => customer.FirstName == name);
        }

        public async Task AddCustomerAsync(Customer customer) {
            await _context.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task AddOrderToCustomerAsync(Customer customer, Order order) {
            customer.Orders.Add(order);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCustomerAddressAsync(Customer customer, Address address) {
            customer.Address = address;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCustomerPhoneAsync(Customer customer, string phone) {
            customer.UpdatePhone(phone);
            await _context.SaveChangesAsync();
        }

        public async Task<Customer> IsCustomerRegisteredAsync(string name) {
            return await _context.Customers.FirstOrDefaultAsync(customer => customer.FirstName == name);
        }
        // END Customer Methods


        // Order Methods
        public async Task<List<Order>> GetOrdersAsync() {
            return await _context.Orders.Include(o => o.Customer).ToListAsync();
        }

        public async Task<Order> GetOrderAsync(int orderID) {
            return await _context.Orders.Include(o => o.Customer).SingleOrDefaultAsync(o => o.OrderID == orderID);
        }

        public async Task<Order> GetMostRecentOrderAsync() {
            return await _context.Orders.Include(o => o.Customer).OrderByDescending(o => o.OrderPlaced).Take(1).SingleOrDefaultAsync();
        }

        public async Task AddProductToOrderAsync(Order order, ProductOrder productOrder) {
            order.ProductOrders.Add(productOrder);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOrderProductQuantityAsync(Order order, int productID, int productQuantity) {
            order.UpdateProductQuantity(productID, productQuantity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOrderStatusAsync(string status, Order order) {
            order.updateStatus(status);
            await _context.SaveChangesAsync();
        }

        public async Task CompleteOrderAsync(Order order) {
            order.CompleteOrder();
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrderAsync(Order order) {
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }
        // END Order Methods


        // Product Brand Methods
        public async Task<List<ProductBrand>> GetProductBrandsAsync() {
            return await _context.ProductBrands.ToListAsync();
        }
        // END Product Brand Methods


        // Product Type Methods
        public async Task<List<ProductType>> GetProductTypessAsync() {
            return await _context.ProductTypes.ToListAsync();
        }

        // Product Type Methods

    }
}
