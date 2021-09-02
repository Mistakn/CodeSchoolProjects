using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPetStore.Entities {
    public class Customer {

        [Key]
        public int CustomerID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

#nullable enable
        public string? Address { get; set; }

        public string? City { get; set; }

        public string? StateOrProvinceAbbr { get; set; }

        public string? Country { get; set; }

        public string? PostalCode { get; set; }

        public string? Phone { get; set; }

        [MaxLength(200)]
        public string? Email { get; set; }
#nullable disable

        public ICollection<Order> Orders { get; set; }
    }
}
