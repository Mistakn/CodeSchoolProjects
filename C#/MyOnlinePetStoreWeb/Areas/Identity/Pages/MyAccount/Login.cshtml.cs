using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MyOnlinePetStoreWeb.Models.Identity;

namespace MyOnlinePetStoreWeb.Areas.Identity.Pages.MyAccount {

    [AllowAnonymous]
    public class LoginModel : PageModel {


        private readonly SignInManager<PetStoreIdentityUser> _signInManager;


        public LoginModel(SignInManager<PetStoreIdentityUser> signInManager) {
            _signInManager = signInManager;
        }


        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }

        public IEnumerable<AuthenticationScheme> ExternalLogins { get; set; }


        public async Task OnGetAsync() {
            ExternalLogins = await _signInManager.GetExternalAuthenticationSchemesAsync();
        }


        public async Task<IActionResult> OnPostAsync() {
            if (ModelState.IsValid) {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, isPersistent: true, lockoutOnFailure: false);

                if (result.Succeeded) {
                    return LocalRedirect("/Index");
                } else {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

    }
}
