using Microsoft.EntityFrameworkCore;
using MyOnlinePetStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOnlinePetStore.Data {
    public class ApplicationContext : DbContext {

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductOrder> ProductOrders { get; set; }

        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            // Relacion 1 to 1
            // Este comando le dice a Entity que el adrress no se va a poder consultar por si solo, sino que siempre tendra que pasar por customer primero
            modelBuilder.Entity<Customer>().OwnsOne(customer => customer.Address);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=MyOnlinePetStoreDB;Integrated Security=True");
        }
    }
}
