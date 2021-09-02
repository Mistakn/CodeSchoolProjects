using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPEntity.Data {
    public class ApplicationUser : IdentityUser {

        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Country { get; set; }

    }
}
