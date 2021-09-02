using Microsoft.AspNetCore.Identity;
using MyOnlinePetStoreWeb.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyOnlinePetStoreWeb.Models.Identity {

    public class PetStoreIdentityUser : IdentityUser {

        [Required]
        [MaxLength(200)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(200)]
        public string LastName { get; set; }

        public int? CustomerId { get; set; }

        public Customer Customer { get; set; }
    }

}
