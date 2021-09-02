using Microsoft.AspNetCore.Identity;
using MyOnlinePetStoreWeb.Entities;
using MyOnlinePetStoreWeb.Models.Identity;
using MyOnlinePetStoreWeb.Services.Implementations;
using MyOnlinePetStoreWeb.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyOnlinePetStoreWeb.Data {
    public class ApplicationContextSeed {

        public static async Task SeedIdentityAsync(UserManager<PetStoreIdentityUser> userManager, RoleManager<IdentityRole> roleManager, IDbShopService shopService) {

            string[] rolesToInsert = Enum.GetNames<RolesEnum>();

            foreach (var role in rolesToInsert) {

                var roleData = new IdentityRole { Name = role };

                var roleExists = await roleManager.RoleExistsAsync(roleData.Name);
                if (!roleExists) {
                    await roleManager.CreateAsync(roleData);
                }

                if (role != RolesEnum.Customer.ToString()) {
                    // Create user of created role
                    var userData = new {
                        Email = $"{role}@{role}.com",
                        Password = role
                    };

                    var userExists = await userManager.GetUsersInRoleAsync(role);
                    if (userExists.Count == 0) {

                        var user = new PetStoreIdentityUser {
                            FirstName = "Cuit",
                            LastName = "Rodriguez",
                            UserName = userData.Email,
                            Email = userData.Email
                        };

                        var userResult = await userManager.CreateAsync(user, userData.Password);
                        if (userResult.Succeeded) {
                            // Assign role
                            var roleResult = await userManager.AddToRoleAsync(user, role);

                            if (!roleResult.Succeeded) {
                                await userManager.DeleteAsync(user);
                            }
                        }

                    }
                }
            }

            // Create Seed customer order
            var customer = await shopService.GetCustomerAsync("Cuit");

            // Check to see if customer has an ongoing order
            Order ongoingOrder = customer.GetOngoingOrder();

            if (!(ongoingOrder is Order)) {
                // Customer doesn't have an ongoing order, create new 
                Order order = new(customer.CustomerID, 2, 5, OrderStatusesEnum.Pending.ToString());
                order.AddProduct(2, 5);

                try {
                    await shopService.AddOrderToCustomerAsync(customer, order);
                    Console.WriteLine("Client order updated");
                } catch (Exception ex) {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            customer = await shopService.GetCustomerAsync("Cuitlahuac");

            // Check to see if customer has an ongoing order
            ongoingOrder = customer.GetOngoingOrder();

            if (!(ongoingOrder is Order)) {
                // Customer doesn't have an ongoing order, create new 
                Order order = new(customer.CustomerID, 2, 5, OrderStatusesEnum.Pending.ToString());
                order.AddProduct(2, 5);

                try {
                    await shopService.AddOrderToCustomerAsync(customer, order);
                    Console.WriteLine("Client order updated");
                } catch (Exception ex) {
                    Console.WriteLine($"Error: {ex.Message}");
                }

            }
        }


        public static async Task SeedAsync(ApplicationDbContext context) {
            if (context.ProductBrands.Count() == 0) {
                await context.ProductBrands.AddRangeAsync(
                    new List<ProductBrand> {
                        new ProductBrand{ Name = "Purina" },
                        new ProductBrand{ Name = "Da Dog" },
                        new ProductBrand{ Name = "Kirkland" },
                        new ProductBrand{ Name = "Dogchow" },
                        new ProductBrand{ Name = "Catchow" },
                    });
            }

            if (context.ProductTypes.Count() == 0) {
                await context.ProductTypes.AddRangeAsync(
                    new List<ProductType> {
                        new ProductType{ Name = "Food" },
                        new ProductType{ Name = "Toy" },
                        new ProductType{ Name = "Accessory" },
                        new ProductType{ Name = "Clothing" },
                        new ProductType{ Name = "Cleaning" },
                    });
            }

            await context.SaveChangesAsync();
        }

    }
}
