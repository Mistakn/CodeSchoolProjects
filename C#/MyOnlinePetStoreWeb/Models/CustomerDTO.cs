using MyOnlinePetStoreWeb.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyOnlinePetStoreWeb.Models {
    public class CustomerDTO {

        public int CustomerID { get; set; }

        [Required]
        [MaxLength(255)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(255)]
        public string LastName { get; set; }

        [MaxLength(13)]
        public string? Phone { get; set; }

        [Required]
        [MaxLength(255)]
        public string Email { get; set; }

    }
}
