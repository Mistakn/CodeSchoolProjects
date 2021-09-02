using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQExcercises {
    class Program {
        static void Main(string[] args) {
            // Find the words in the collection that start with the letter 'L'
            List<string> fruits = new List<string>() { "Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry" };

            IEnumerable<string> query1 =
                from fruit in fruits
                where fruit[0] == 'L'
                select fruit;

            //Console.WriteLine("Fruits that begin with the letter 'L':");
            //Console.WriteLine(String.Join(", ", query1));


            var lambda1 = fruits.Where(fruit => fruit[0] == 'L');

            Console.WriteLine("Fruits that begin with the letter 'L':");
            Console.WriteLine(String.Join(", ", lambda1));



            // Which of the following numbers are multiples of 4 or 6
            List<int> mixedNumbers = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };

            IEnumerable<int> query2 =
                from number in mixedNumbers
                where number % 4 == 0
                where number % 6 == 0
                select number;

            //Console.WriteLine();
            //Console.WriteLine("Numbers that are multiples of 4 or 6:");
            //Console.WriteLine(String.Join(", ", query2));

            var lambda2 = mixedNumbers.Where(number => (number % 4 == 0 || number % 6 == 0));

            Console.WriteLine();
            Console.WriteLine("Numbers that are multiples of 4 or 6:");
            Console.WriteLine(String.Join(", ", lambda2));


            // Output how many numbers are in this list
            List<int> numbers = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };
            Console.WriteLine();
            Console.WriteLine("Numbers in list:");
            Console.WriteLine(numbers.Count());


            // Given the same customer set, display how many millionaires per bank.
            List<Customer> customers = new List<Customer>() {
                new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
                new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
                new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
                new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
                new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
                new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
                new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
                new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
                new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
                new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
            };

            // Get the customers that their balance is more than 1000000
            var query3 =
                from customer in customers
                where customer.Balance >= 1000000
                orderby customer.Balance ascending
                group customer by customer.Bank into bankCustomers
                orderby bankCustomers.Key
                select bankCustomers;

            //Console.WriteLine();
            //foreach (var bank in query3) {
            //    Console.WriteLine($"Millionaires in {bank.Key}:");
            //    foreach (var customer in bank) {
            //        Console.WriteLine($"{customer.Name} - Balance: ${customer.Balance}");
            //    }
            //    Console.WriteLine();
            //}

            var lambda3 = customers
                .Where(customer => customer.Balance > 1000000)
                .OrderBy(customer => customer.Balance)
                .GroupBy(customer => customer.Bank);

            Console.WriteLine();
            foreach (var bank in lambda3) {
                Console.WriteLine($"Millionaires in {bank.Key}:");
                foreach (var customer in bank) {
                    Console.WriteLine($"{customer.Name} - Balance: ${customer.Balance}");
                }
                Console.WriteLine();
            }


            // Order the customers by balance
            var query4 =
                from customer in customers
                orderby customer.Balance ascending
                select customer;

            //Console.WriteLine($"Millionaires ordered by balance:");
            //foreach (var customer in query4) {
            //    Console.WriteLine($"{customer.Name} - Balance: ${customer.Balance}");
            //}


            var lambda4 = customers.OrderBy(customer => customer.Balance);

            Console.WriteLine($"Millionaires ordered by balance:");
            foreach (var customer in lambda4) {
                Console.WriteLine($"{customer.Name} - Balance: ${customer.Balance}");
            }


            // 2.Make a sum of wealth for each bank
            var query5 =
                 from customer in customers
                 group customer by customer.Bank into bankCustomers
                 select new {
                     bankName = bankCustomers.Key,
                     bankTotalSum = bankCustomers.Sum(customer => customer.Balance)
                 };

            //Console.WriteLine();
            //foreach (var bank in query5) {
            //    Console.WriteLine($"{bank.bankName} total balance: ${bank.bankTotalSum}");
            //}

            var lambda5 = customers
                .GroupBy(customer => customer.Bank)
                .Select(bankGroup => new {
                    bankName = bankGroup.Key,
                    bankTotalSum = bankGroup.Sum(bankCustomer => bankCustomer.Balance)
                });

            Console.WriteLine();
            foreach (var bank in lambda5) {
                Console.WriteLine($"{bank.bankName} total balance: ${bank.bankTotalSum}");
            }



            //3.Get the first name of the customers that their balance is less than 100000 and their bank has only 3 characters
            var query6 =
                from customer in customers
                where customer.Balance < 100000
                where customer.Bank.Length == 3
                select customer.Name.Split(' ')[0];

            //Console.WriteLine();
            //foreach (var customer in query6) {
            //    Console.WriteLine($"{customer} has less than $100000 in his account and his bank only has 3 letters.");
            //}

            var lambda6 = customers
                .Where(customer => customer.Balance < 100000 && customer.Bank.Length == 3)
                .Select(customer => customer.Name.Split(' ')[0]);

            Console.WriteLine();
            foreach (var customer in lambda6) {
                Console.WriteLine($"{customer} has less than $100000 in his account and his bank only has 3 letters.");
            }

        }
    }

    internal class Customer {
        public string Name { get; internal set; }
        public double Balance { get; internal set; }
        public string Bank { get; internal set; }
    }
}
