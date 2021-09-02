using MyOnlinePetStore.Shared;
using MyOnlinePetStoreWeb.Data;
using MyOnlinePetStoreWeb.Entities;
using MyOnlinePetStoreWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyOnlinePetStoreWeb.Services.Interfaces {
    public interface IDbShopService {

        // Product Methods
        Task<List<Product>> GetProductsAsync();
        Task<List<Product>> GetProductsByNameAsync(string name);
        Task<List<Product>> GetProductsByFilterAsync(string name, int? brand, bool order);
        Task<Product> GetProductAsync(int productID);
        Task AddProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int productID);
        // END Product Methods


        // Customer Methods
        Task<List<Customer>> GetCustomersAsync();
        Task<Customer> GetCustomerAsync(string name);
        Task AddCustomerAsync(Customer customer);
        Task AddOrderToCustomerAsync(Customer customer, Order order);
        Task UpdateCustomerAddressAsync(Customer customer, Address address);
        Task UpdateCustomerPhoneAsync(Customer customer, string phone);
        Task<Customer> IsCustomerRegisteredAsync(string name);
        // END Customer Methods


        // Order Methods
        Task<List<Order>> GetOrdersAsync();
        Task<Order> GetOrderAsync(int orderID);
        Task<Order> GetMostRecentOrderAsync();
        Task AddProductToOrderAsync(Order order, ProductOrder productOrder);
        Task UpdateOrderProductQuantityAsync(Order order, int productID, int productQuantity);
        Task UpdateOrderStatusAsync(string status, Order order);
        Task CompleteOrderAsync(Order order);
        Task DeleteOrderAsync(Order order);
        // END Order Methods


        // Product Brand Methods
        Task<List<ProductBrand>> GetProductBrandsAsync();
        // END Product Brand Methods


        // Product Type Methods
        Task<List<ProductType>> GetProductTypessAsync();
        // Product Type Methods

    }
}
