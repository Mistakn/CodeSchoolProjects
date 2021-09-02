using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPEntity.Data {
    public class ApplicationContext : IdentityDbContext<ApplicationUser> {
        protected ApplicationContext() : base() {
        }

        public ApplicationContext(DbContextOptions options) : base(options) {
        }
    }
}
