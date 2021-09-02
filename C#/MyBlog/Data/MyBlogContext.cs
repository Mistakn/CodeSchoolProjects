using Microsoft.EntityFrameworkCore;
using MyBlog.Config;
using MyBlog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Data {
    public class MyBlogContext : DbContext {

        public DbSet<Blog> Blog { get; set; }

        public DbSet<Post> Post { get; set; }

        public DbSet<Category> Category { get; set; }

        // Forma de asignar constraints a columnas sin modificar entidades
        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            // Ignora una tabla al momento de generar la base de datos
            //modelBuilder.Ignore<Post>();

            new BlogEntityTypeConfiguration().Configure(modelBuilder.Entity<Blog>());
            new PostEntityTypeConfiguration().Configure(modelBuilder.Entity<Post>());
            new CategoryEntityTypeConfiguration().Configure(modelBuilder.Entity<Category>());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=MyBlogDB;Integrated Security=True");
        }
    }
}
