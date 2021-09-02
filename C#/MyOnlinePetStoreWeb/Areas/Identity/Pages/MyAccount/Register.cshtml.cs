using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using MyOnlinePetStoreWeb.Models.Identity;

namespace MyOnlinePetStoreWeb.Areas.Identity.Pages.MyAccount {

    [AllowAnonymous]
    public class RegisterModel : PageModel {


        private readonly SignInManager<PetStoreIdentityUser> _signInManager;
        private readonly UserManager<PetStoreIdentityUser> _userManager;


        public RegisterModel(
            UserManager<PetStoreIdentityUser> userManager,
            SignInManager<PetStoreIdentityUser> signInManager) {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        [BindProperty]
        public InputModel Input { get; set; }


        public class InputModel {
            [Required]
            [MaxLength(200)]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Required]
            [MaxLength(200)]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            public string Role { get; set; }
        }


        public void OnGet() {
        }


        public async Task<IActionResult> OnPostAsync() {
            if (ModelState.IsValid) {

                var user = new PetStoreIdentityUser {
                    FirstName = Input.FirstName,
                    LastName = Input.LastName,
                    UserName = Input.Email,
                    Email = Input.Email
                };

                var userResult = await _userManager.CreateAsync(user, Input.Password);

                if (userResult.Succeeded) {
                    // Assign role
                    var roleResult = await _userManager.AddToRoleAsync(user, Input.Role);

                    if (roleResult.Succeeded) {
                        await _signInManager.SignInAsync(user, isPersistent: true);
                        return RedirectToPage("/Index");
                    } else {
                        await _userManager.DeleteAsync(user);
                        ModelState.AddModelError(string.Empty, "User could not be created");
                    }
                }

                foreach (var error in userResult.Errors) {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
