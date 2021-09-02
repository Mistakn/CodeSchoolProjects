using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPEntity.Pages {
    public class RoleRegistrationModel : PageModel {


        private readonly RoleManager<IdentityRole> _roleManager;


        public RoleRegistrationModel(RoleManager<IdentityRole> roleManager) {
            _roleManager = roleManager;
        }


        [BindProperty]
        public string Role { get; set; }


        public void OnGet() {
        }


        public async Task<IActionResult> OnPostAsync() {

            if (ModelState.IsValid) {
                var role = new IdentityRole {
                    Name = Role
                };

                var result = await _roleManager.CreateAsync(role);

                if (result.Succeeded) {
                    Role = string.Empty;
                } else {
                    foreach (var error in result.Errors) {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            return Page();
        }
    }
}
