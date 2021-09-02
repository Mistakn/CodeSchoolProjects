using MyOnlinePetStoreWeb.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyOnlinePetStoreWeb.Entities {
    public class Customer {

        [Key]
        public int CustomerID { get; private set; }

        [Required]
        [MaxLength(255)]
        public string FirstName { get; private set; }

        [Required]
        [MaxLength(255)]
        public string LastName { get; private set; }

        [MaxLength(13)]
        public string? Phone { get; private set; }

        [Required]
        [MaxLength(255)]
        public string Email { get; private set; }

        public Address Address { get; set; }

        public ICollection<Order> Orders { get; set; }


        private static int Seed = 1;


        public Customer() { }
        public Customer(string firstName, string lastName, string email) {

            if (string.IsNullOrEmpty(firstName)) {
                throw new InvalidOperationException("Name is required");
            }

            if (string.IsNullOrEmpty(lastName)) {
                throw new InvalidOperationException("Last name is required");
            }

            if (string.IsNullOrEmpty(email)) {
                throw new InvalidOperationException("Email is required");
            }

            //CustomerID = Seed;
            //Seed++;

            FirstName = firstName;
            LastName = lastName;
            Email = email;
            //Orders = new List<Order>();
        }


        public void Update(string firstName, string lastName, string email, string phone) {

            if (string.IsNullOrEmpty(firstName)) {
                throw new InvalidOperationException("Name is required");
            }

            if (string.IsNullOrEmpty(lastName)) {
                throw new InvalidOperationException("Last name is required");
            }

            if (string.IsNullOrEmpty(email)) {
                throw new InvalidOperationException("Email is required");
            }

            if (string.IsNullOrEmpty(phone)) {
                throw new InvalidOperationException("Phone is required");
            }

            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
        }


        public void UpdatePhone(string phone) {
            if (string.IsNullOrEmpty(phone) || phone.Length < 10) {
                throw new InvalidOperationException("Invalid phone number");
            }

            Phone = phone ?? throw new ArgumentNullException(nameof(phone));
        }


        public Order GetOngoingOrder() {
            if (Orders != null) {
                return Orders.SingleOrDefault(order => !order.OrderFulfilled.HasValue);
            } else {
                return null;
            }
        }

    }
}
