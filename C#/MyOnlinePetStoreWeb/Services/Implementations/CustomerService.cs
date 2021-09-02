using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyOnlinePetStoreWeb.Data;
using MyOnlinePetStoreWeb.Entities;
using MyOnlinePetStoreWeb.Models;
using MyOnlinePetStoreWeb.Models.Identity;
using MyOnlinePetStoreWeb.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyOnlinePetStoreWeb.Services.Implementations {
    public class CustomerService : IDbCustomerService {


        private readonly ApplicationDbContext _context;
        private readonly UserManager<PetStoreIdentityUser> _userManager;

        public CustomerService(ApplicationDbContext context, UserManager<PetStoreIdentityUser> userManager) {
            _context = context;
            _userManager = userManager;
        }


        public async Task<Customer> GetCustomerAsync(int customerID) {
            return await _context.Customers.SingleOrDefaultAsync(customer => customer.CustomerID == customerID);
        }

        public async Task<PetStoreIdentityUser> GetCustomerAsync(string email) {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<List<Customer>> GetCustomersAsync() {
            return await _context.Customers.ToListAsync();
        }

        public async Task AddCustomerAsync(Customer customer) {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCustomerAsync(Customer customer) {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCustomerAddressAsync(Customer customer, AddressDTO address) {
            customer.Address.Update(address.StreetAddress, address.City, address.StateOrProvinceAbbr, address.Country, address.PostalCode);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCustomerAsync(int customerID) {
            Customer customer = await _context.Customers.SingleOrDefaultAsync(customer => customer.CustomerID == customerID);

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }
    }
}
