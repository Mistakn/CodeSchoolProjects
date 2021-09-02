using MyOnlinePetStoreWeb.Entities;
using MyOnlinePetStoreWeb.Models;
using MyOnlinePetStoreWeb.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyOnlinePetStoreWeb.Services.Interfaces {
    public interface IDbCustomerService {

        Task<List<Customer>> GetCustomersAsync();

        Task<Customer> GetCustomerAsync(int customerID);

        Task<PetStoreIdentityUser> GetCustomerAsync(string email);

        Task AddCustomerAsync(Customer customer);

        Task UpdateCustomerAsync(Customer customer);

        Task UpdateCustomerAddressAsync(Customer customer, AddressDTO address);

        Task DeleteCustomerAsync(int customerID);

    }
}
