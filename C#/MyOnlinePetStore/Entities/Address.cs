using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOnlinePetStore.Entities {
    public class Address {

        [Key]
        public int AddressID { get; set; }

        [Required]
        [MaxLength(255)]
        public string StreetAddress { get; private set; }

        [Required]
        [MaxLength(255)]
        public string City { get; private set; }

        [Required]
        [MaxLength(3)]
        public string StateOrProvinceAbbr { get; private set; }

        [Required]
        [MaxLength(255)]
        public string Country { get; private set; }

        [Required]
        [MaxLength(5)]
        public string PostalCode { get; private set; }

        public Customer Customer { get; private set; }

        private static int Seed = 1;


        public Address() { }
        public Address(string streetAddress, string city, string stateOrProvinceAbbr, string country, string postalCode) {

            if (string.IsNullOrEmpty(streetAddress)) {
                throw new InvalidOperationException("Street address is required");
            }

            if (string.IsNullOrEmpty(city)) {
                throw new InvalidOperationException("City is required");
            }

            if (string.IsNullOrEmpty(stateOrProvinceAbbr)) {
                throw new InvalidOperationException("State or Province Abbreviation is required");
            }

            if (string.IsNullOrEmpty(country)) {
                throw new InvalidOperationException("Country is required");
            }

            if (string.IsNullOrEmpty(postalCode)) {
                throw new InvalidOperationException("Postal Code is required");
            }

            //AddressID = Seed;
            //Seed++;

            StreetAddress = streetAddress;
            City = city;
            StateOrProvinceAbbr = stateOrProvinceAbbr;
            Country = country;
            PostalCode = postalCode;

        }


        public void Update(string streetAddress, string city, string stateOrProvinceAbbr, string country, string postalCode) {

            if (string.IsNullOrEmpty(streetAddress)) {
                throw new InvalidOperationException("Street address is required");
            }

            if (string.IsNullOrEmpty(city)) {
                throw new InvalidOperationException("City is required");
            }

            if (string.IsNullOrEmpty(stateOrProvinceAbbr)) {
                throw new InvalidOperationException("State or Province Abbreviation is required");
            }

            if (string.IsNullOrEmpty(country)) {
                throw new InvalidOperationException("Country is required");
            }

            if (string.IsNullOrEmpty(postalCode)) {
                throw new InvalidOperationException("Postal Code is required");
            }

            StreetAddress = streetAddress;
            City = city;
            StateOrProvinceAbbr = stateOrProvinceAbbr;
            Country = country;
            PostalCode = postalCode;

        }
    }
}
