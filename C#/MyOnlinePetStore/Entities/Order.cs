using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOnlinePetStore.Entities {
    public class Order {

        [Key]
        public int OrderID { get; private set; }

        [Required]
        public DateTime OrderPlaced { get; private set; }

        public DateTime? OrderFulfilled { get; private set; }

        [Required]
        public int CustomerID { get; private set; }

        public Customer Customer { get; private set; }

        public ICollection<ProductOrder> ProductOrders { get; private set; }

        private static int Seed = 1;


        public Order() { }

        public Order(int customerID, int productID, int quantity) {

            //OrderID = Seed;
            //Seed++;

            OrderPlaced = DateTime.Now;
            CustomerID = customerID;

            if (quantity > 0) {
                ProductOrders = new List<ProductOrder> {
                new ProductOrder {
                    ProductID = productID,
                    Quantity = quantity
                }
            };
            } else {
                throw new InvalidOperationException("Incorrect quantity value");
            }
        }


        public List<ProductOrder> GetProductOrders() {
            return ProductOrders.ToList();
        }


        public bool ProductIsInOrder(int productID) {
            return ProductOrders.Any(product => product.ProductID == productID);
        }


        public void AddProduct(int productID, int quantity) {
            if (quantity > 0) {
                ProductOrders.Add(new ProductOrder {
                    ProductID = productID,
                    Quantity = quantity
                });
            } else {
                throw new InvalidOperationException("Incorrect quantity value");
            }
        }


        //public decimal GetTotal() {
        //    decimal total = 0;

        //    foreach (var productOrder in ProductOrders) {
        //        var productPrice = productOrder.Product.Price;
        //        var quantity = productOrder.Quantity;

        //        total += (productPrice * quantity);
        //    }

        //    return total;
        //}

        public decimal GetTotal() {
            return ProductOrders.Sum(productOrder => productOrder.Quantity * productOrder.Product.Price);
        }


        public void UpdateProductQuantity(int productID, int quantity) {
            var itemToBeUpdated = ProductOrders.SingleOrDefault(productOrder => productOrder.ProductID == productID);

            if (itemToBeUpdated is ProductOrder) {
                if (quantity > 0) {
                    itemToBeUpdated.Quantity = quantity;
                } else if (quantity == 0) {
                    RemoveProduct(productID);
                } else {
                    throw new InvalidOperationException("Incorrect quantity value");
                }
            } else {
                throw new ArgumentNullException("Product does not exist");
            }

            Console.WriteLine("Product quantity updated successfully");
        }


        public void RemoveProduct(int productID) {
            var itemToBeRemoved = ProductOrders.SingleOrDefault(productOrder => productOrder.ProductID == productID);

            if (itemToBeRemoved is ProductOrder) {
                ProductOrders.Remove(itemToBeRemoved);
            } else {
                throw new ArgumentNullException("Product does not exist");
            }

            Console.WriteLine("Product removed");
        }


        public void CompleteOrder() {

            // Must be a nullable field
            //if (OrderFulfilled.HasValue) {
            //}

            if (string.IsNullOrEmpty(OrderFulfilled.ToString())) {
                OrderFulfilled = DateTime.Now;
            } else {
                throw new InvalidOperationException("Order has already been fulfilled");
            }

            Console.WriteLine("The order has been completed successfully");
        }
    }
}
