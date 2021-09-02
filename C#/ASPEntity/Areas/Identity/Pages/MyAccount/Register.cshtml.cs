using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASPEntity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;

namespace ASPEntity.Areas.Identity.Pages.MyAccount {
    public class RegisterModel : PageModel {

        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager) {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }


        public class InputModel {
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

                var user = new ApplicationUser { UserName = Input.Email, Email = Input.Email };

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
