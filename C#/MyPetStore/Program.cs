using MyPetStore.Data;
using MyPetStore.Entities;
using System;
using System.Linq;

namespace MyPetStore {
    class Program {
        static void Main(string[] args) {

            using MyPetStoreContext contextDB = new MyPetStoreContext();

            Product boneTreat = new Product {
                Name = "Bone Treat",
                Price = 12.99M
            };

            // contextDB.Products.Add(boneTreat);

            Product tennisBalls = new Product {
                Name = "Tennis Balls - Pack of 3",
                Price = 8.99M
            };

            //contextDB.Products.Add(tennisBalls);


            var products = contextDB.Products.Where(product => product.Price >= 5).OrderBy(product => product.Name);

            foreach (var product in products) {
                Console.WriteLine($"ID:\t{product.ProductID}");
                Console.WriteLine($"Product Name:\t{product.Name}");
                Console.WriteLine($"Price:\t{product.Price}");
                Console.WriteLine(new string('-', 20));
            }

            //var productFeo = from product in contextDB.Products
            //                 where product.Name.Contains("Bone Treat")
            //                 orderby product.Name
            //                 select product;

            var product2 = contextDB.Products.Where(product => product.Name == "Bone Treat").First();

            Console.WriteLine($"ID:\t{product2.ProductID}");
            Console.WriteLine($"Product Name:\t{product2.Name}");
            Console.WriteLine($"Price:\t{product2.Price}");
            Console.WriteLine(new string('-', 20));

            // BD UPDATE

            Product tenisBalls = contextDB.Products
                .FirstOrDefault(product => product.ProductID == 2);

            if (tenisBalls != null) {
                tenisBalls.Price = 9.99M;
            }


            // BD Remove

            Product tenisBalls2 = contextDB.Products
                .FirstOrDefault(product => product.ProductID == 2);

            if (tenisBalls2 is Product) {
                contextDB.Remove(tenisBalls2);
            }

            contextDB.SaveChanges();

        }
    }
}
