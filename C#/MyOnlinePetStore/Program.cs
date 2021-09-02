using MyOnlinePetStore.Data;
using MyOnlinePetStore.Entities;
using MyOnlinePetStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyOnlinePetStore {
    class Program {

        public static List<Product> shopProducts = new List<Product> {
                new Product("Product 1", "The description 1", 9.99m),
                new Product("Product 2", "The description 2", 19.99m),
                new Product("Product 3", "The description 3", 19.99m)
            };

        public static ShopService _shopService = new();
        public static ReportService _reportService = new();

        static void Main(string[] args) {

            // If no products, add them
            if (!_shopService.GetProducts().Any()) {
                foreach (var product in shopProducts) {
                    try {
                        _shopService.AddProduct(product);
                        Console.WriteLine($"Product {product.Name} with price {product.Price} has been added");
                    } catch (Exception ex) {
                        Console.WriteLine($"Error {ex.Message}");
                    }
                }
            }

            var showMenu = true;
            while (showMenu) {
                showMenu = MainMenu(showMenu);
            }

        }


        private static bool MainMenu(bool showMenu) {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1.- Register client");
            Console.WriteLine("2.- Register client address");
            Console.WriteLine("3.- Update client's phone number");
            Console.WriteLine("4.- See all products");
            Console.WriteLine("5.- See all customers");
            Console.WriteLine("6.- Add a product to a client's order");
            Console.WriteLine("7.- Update a product's quantity in a client's order");
            Console.WriteLine("8.- Finish a client's order");
            Console.WriteLine("9.- Get monthly orders (Products, total and grand total)");
            Console.WriteLine("10.- Customer with the most orders");
            Console.WriteLine("11.- Most sold product");
            Console.WriteLine("12.- Country with most orders");
            Console.WriteLine("13.- Exit");

            var optionSelected = Console.ReadLine();

            switch (optionSelected) {

                case "1":
                    RegisterCustomer();
                    break;

                case "2":
                    UpdateCustomerAddress();
                    break;

                case "3":
                    UpdateCustomerPhone();
                    break;

                case "4":
                    ListProducts();
                    break;

                case "5":
                    ListCustomers();
                    break;

                case "6":
                    AddProductToCustomerOrder();
                    break;

                case "7":
                    UpdateClientProductOrderQuantity();
                    break;

                case "8":
                    CompleteClientOrder();
                    break;

                case "9":
                    GetMonthlyOrders();
                    break;

                case "10":
                    GetCustomerWithMostOrders();
                    break;

                case "11":
                    GetMostSoldProduct();
                    break;

                case "12":
                    GetCountryWithMostOrders();
                    break;

                case "13":
                    showMenu = false;
                    Console.WriteLine("We hope to see you again. :)");
                    break;

                default:
                    break;
            }
            Console.ReadLine();
            return showMenu;
        }


        private static Customer RegisterCustomer() {
            Console.WriteLine("Insert first name");
            var firstName = Console.ReadLine();

            Console.WriteLine("Insert last name");
            var lastName = Console.ReadLine();

            Console.WriteLine("Insert email");
            var email = Console.ReadLine();

            try {
                Customer customer = new(firstName, lastName, email);
                _shopService.AddCustomer(customer);
                Console.WriteLine($"Customer {customer.FirstName} {customer.LastName} has been added");

                return customer;
            } catch (Exception ex) {
                Console.WriteLine($"Error: {ex}");
                throw;
            }
        }


        private static void ListCustomers() {
            List<Customer> customers = _shopService.GetCustomers();

            Console.WriteLine("Showing all customers...");
            Console.WriteLine();
            Console.WriteLine("First Name\tLast Name\t\tPhone\t\tE-Mail");
            foreach (var customer in customers) {
                Console.WriteLine($"{customer.FirstName}\t\t{customer.LastName}\t\t{(!string.IsNullOrEmpty(customer.Phone) ? customer.Phone : "N/A")}\t\t{customer.Email}");
            }
        }


        private static void GetCustomerWithMostOrders() {
            var customerWithMostOrders = _reportService.GetCustomerWithMostOrders();

            Console.WriteLine($"The customer with the most orders is {customerWithMostOrders.FirstName} {customerWithMostOrders.LastName}, with a total of {customerWithMostOrders.Orders.Count} orders.");
        }


        private static void UpdateCustomerAddress() {
            ListCustomers();

            Console.WriteLine("Enter the name of the customer to change his/her address");
            var customerName = Console.ReadLine();

            var customer = _shopService.GetCustomer(customerName);

            if (!(customer is Customer)) {
                throw new Exception("Customer not found");
            }

            Console.WriteLine("Please update your street address");
            var streetAddress = Console.ReadLine();

            Console.WriteLine("Please update your city");
            var city = Console.ReadLine();

            Console.WriteLine("Please update your state or province abbreviation");
            var stateOrProvinceAbbr = Console.ReadLine();

            Console.WriteLine("Please update your country");
            var country = Console.ReadLine();

            Console.WriteLine("Please update your postal code");
            var postalCode = Console.ReadLine();

            try {
                Address address = new(streetAddress, city, stateOrProvinceAbbr, country, postalCode);
                _shopService.UpdateCustomerAddress(customer, address);

                Console.WriteLine("Address updated successfully");
            } catch (Exception ex) {
                Console.WriteLine($"Error: {ex}");
            }
        }


        private static void UpdateCustomerPhone() {
            ListCustomers();

            Console.WriteLine("Enter the name of the customer to change his/her phone number");
            var customerName = Console.ReadLine();

            var customer = _shopService.GetCustomer(customerName);

            if (!(customer is Customer)) {
                throw new Exception("Customer not found");
            }

            Console.WriteLine("Please enter your phone number");
            var phoneNumber = Console.ReadLine();

            try {
                _shopService.UpdateCustomerPhone(customer, phoneNumber);
                Console.WriteLine("Phone number updated successfully");
            } catch (Exception ex) {
                Console.WriteLine($"Error: {ex}");
                throw;
            }
        }


        private static void ListProducts() {
            List<Product> products = _shopService.GetProducts();

            Console.WriteLine("Showing all products...");
            Console.WriteLine();
            Console.WriteLine("ID\tName\t\tDescription\t\tPrice");
            foreach (var product in products) {
                Console.WriteLine($"{product.ProductID}\t{product.Name}\t{product.Description}\t${product.Price}");
            }
        }


        private static void GetMostSoldProduct() {
            var mostSoldProduct = _reportService.GetMostSoldProduct();

            Console.WriteLine($"The most sold product of all time is {mostSoldProduct.Name}");
        }


        private static void ListOrderProducts(List<ProductOrder> ProductOrders) {

            Console.WriteLine("Showing all products in ongoing order...");
            Console.WriteLine();
            Console.WriteLine("Product ID\tProduct Name\tQuantity");
            foreach (var product in ProductOrders) {
                Product productDetails = _shopService.GetProduct(product.ProductID);

                if (!(productDetails is Product)) {
                    throw new InvalidOperationException("Product not found");
                }

                Console.WriteLine($"{product.ProductID}\t{productDetails.Name}\t{product.Quantity}");
            }
        }


        private static void GetMonthlyOrders() {

            Console.WriteLine("Enter year to show report (1995, 2021, etc...)");
            var yearNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter number of month to show report (January = 1, February = 2, etc...)");
            var monthNumber = int.Parse(Console.ReadLine());

            if (monthNumber >= 1 && monthNumber <= 12) {
                var firstDayOfMonth = new DateTime(yearNumber, monthNumber, 1);
                var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

                List<Order> monthlyOrders = _reportService.GetOrdersByMonth(firstDayOfMonth, lastDayOfMonth);

                if (monthlyOrders.Count > 0) {
                    Console.WriteLine($"Orders completed in {firstDayOfMonth:MMMM} of {yearNumber}");
                    Console.WriteLine();

                    foreach (var order in monthlyOrders) {
                        Console.WriteLine($"Order with ID {order.OrderID}");

                        foreach (var productOrder in order.ProductOrders) {
                            var product = productOrder.Product;
                            Console.WriteLine($"\t{product.Name}x{productOrder.Quantity} \t{product.Price} \t{product.Price * productOrder.Quantity}");
                        }

                        var orderTotal = order.ProductOrders
                            .Sum(productOrder => (productOrder.Product.Price * productOrder.Quantity));
                        Console.WriteLine($"Order total: {orderTotal}");
                        Console.WriteLine();
                    }

                    var grandTotal = monthlyOrders
                        .Sum(order => order.ProductOrders
                            .Sum(productOrder => (productOrder.Product.Price * productOrder.Quantity)));

                    Console.WriteLine($"Total sales value in {firstDayOfMonth:MMMM}: {grandTotal}");
                    Console.WriteLine();

                } else {
                    Console.WriteLine($"No orders where made in {firstDayOfMonth:MMMM} of {yearNumber}");
                }
            } else {
                throw new ArgumentOutOfRangeException("Number inputed does not correspond to a month");
            }

        }


        private static void GetCountryWithMostOrders() {
            var countryWithMostOrders = _reportService.GetCountryWithMostOrders();

            Console.WriteLine($"The country with the most orders is {countryWithMostOrders}");
        }


        private static void AddProductToCustomerOrder() {

            ListProducts();

            Console.WriteLine("Enter the ID of the product you would like to add to your order");
            var productID = Console.ReadLine();

            Product product = _shopService.GetProduct(int.Parse(productID));

            if (!(product is Product)) {
                throw new InvalidOperationException("Product ID doesn't exist");
            }

            Console.WriteLine("How much of that product would you like to add to the order?");
            var productQuantity = Console.ReadLine();

            ListCustomers();

            Console.WriteLine("Enter the name of the customer to add the product to his/her order");
            var customerName = Console.ReadLine();

            var customer = _shopService.GetCustomer(customerName);

            if (!(customer is Customer)) {
                throw new Exception("Customer not found");
            }

            try {
                // Check to see if customer has an ongoing order
                Order ongoingOrder = customer.GetOngoingOrder();

                if (!(ongoingOrder is Order)) {
                    // Customer doesn't have an ongoing order, create new 
                    Order order = new(customer.CustomerID, int.Parse(productID), int.Parse(productQuantity));

                    order.AddProduct(int.Parse(productID), int.Parse(productQuantity));

                    try {
                        _shopService.AddOrderToCustomer(customer, order);
                        Console.WriteLine("Client order updated");
                    } catch (Exception ex) {
                        Console.WriteLine($"Error: {ex.Message}");
                    }

                } else {
                    // Customer has ongoing order, check if product doesn't exist in order yet
                    var productIsInOrder = ongoingOrder.ProductIsInOrder(int.Parse(productID));

                    if (productIsInOrder) {
                        Console.WriteLine("Product already exists in order, product can only be updated");
                        UpdateClientProductOrderQuantity();
                    } else {
                        // If product isn't in order, add product to order
                        ProductOrder productOrder = new() {
                            ProductID = int.Parse(productID),
                            Quantity = int.Parse(productQuantity)
                        };

                        try {
                            _shopService.AddProductToOrder(ongoingOrder, productOrder);
                            Console.WriteLine("Client order updated");
                        } catch (Exception ex) {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                    }
                }

            } catch (Exception ex) {
                Console.WriteLine($"Error: {ex}");
            }
        }


        private static void UpdateClientProductOrderQuantity() {

            ListCustomers();

            Console.WriteLine("Enter the name of the customer to update his/her order");
            var customerName = Console.ReadLine();

            var customer = _shopService.GetCustomer(customerName);

            if (!(customer is Customer)) {
                throw new Exception("Customer not found");
            }

            try {

                // Check to see if customer has an ongoing order
                Order ongoingOrder = customer.GetOngoingOrder();

                if (ongoingOrder is Order) {
                    // Customer has ongoing order, list products currently in order
                    ListOrderProducts(ongoingOrder.GetProductOrders());

                    Console.WriteLine("Enter the ID of the product you would like to update the quantity");
                    var productID = Console.ReadLine();

                    Product product = _shopService.GetProduct(int.Parse(productID));

                    if (!(product is Product)) {
                        throw new InvalidOperationException("Product ID doesn't exist");
                    }

                    Console.WriteLine("Enter the new quantity for the selected product");
                    var productQuantity = Console.ReadLine();

                    try {
                        _shopService.UpdateOrderProductQuantity(ongoingOrder, int.Parse(productID), int.Parse(productQuantity));
                    } catch (Exception ex) {
                        Console.WriteLine($"Error:{ ex.Message}");
                    }

                } else {
                    // Customer doesn't have an ongoing order
                    throw new InvalidOperationException("Customer doesn't have an ongoing order");
                }

            } catch (Exception ex) {
                Console.WriteLine($"Error: {ex}");
            }
        }


        private static void CompleteClientOrder() {

            ListCustomers();

            // Check if customer has an ongoing 
            Console.WriteLine("Enter the name of the customer to complete his/her order");
            var customerName = Console.ReadLine();

            var customer = _shopService.GetCustomer(customerName);

            if (!(customer is Customer)) {
                throw new Exception("Customer not found");
            }

            // Check to see if customer has an ongoing order
            Order ongoingOrder = customer.GetOngoingOrder();

            if (ongoingOrder is Order) {
                // If customer has ongoing order, complete it
                try {
                    _shopService.CompleteOrder(ongoingOrder);
                } catch (Exception ex) {
                    Console.WriteLine($"Error: {ex.Message}");
                }

            } else {
                // Customer doesn't have an ongoing order
                throw new InvalidOperationException("Customer doesn't have an ongoing order");
            }
        }


        static void MyPetStoreInMemoryTest() {
            var localProducts = new List<Product>();

            // Register client
            var client = new Customer("Cuit", "Rodriguez", "cuit.rodriguez@hotmail.com");

            // Add Address and Phone
            client.Address = new Address("Street 1", "City 1", "C1", "Country 1", "29087");
            client.UpdatePhone("2342342349");

            // Add and Find product in inventory
            var product1 = new Product("Chew toy", "It's a chew toy", 9.99M);
            localProducts.Add(product1);

            var product2 = new Product("Squeaky toy", "It's a squeaky toy", 7.99M);
            localProducts.Add(product2);

            var chewToyProduct = localProducts.SingleOrDefault(product => product.Name == "Chew toy");

            // New Order and add 2 products to order
            var order = new Order(client.CustomerID, product1.ProductID, 5);
            order.AddProduct(product2.ProductID, 2);

            // Modify product 1 quantity
            order.UpdateProductQuantity(product1.ProductID, 2);

            // Complete order
            order.CompleteOrder();
        }

    }
}
