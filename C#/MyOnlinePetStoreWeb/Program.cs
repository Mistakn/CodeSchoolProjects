using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MyOnlinePetStoreWeb.Data;
using MyOnlinePetStoreWeb.Models.Identity;
using MyOnlinePetStoreWeb.Services.Implementations;
using MyOnlinePetStoreWeb.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyOnlinePetStoreWeb {
    public class Program {
        public static async Task Main(string[] args) {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope()) {
                var services = scope.ServiceProvider;

                var userManager = services.GetRequiredService<UserManager<PetStoreIdentityUser>>();
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                var shopService = services.GetService<IDbShopService>();
                var context = services.GetRequiredService<ApplicationDbContext>();

                await ApplicationContextSeed.SeedIdentityAsync(userManager, roleManager, shopService);
                await ApplicationContextSeed.SeedAsync(context);
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
