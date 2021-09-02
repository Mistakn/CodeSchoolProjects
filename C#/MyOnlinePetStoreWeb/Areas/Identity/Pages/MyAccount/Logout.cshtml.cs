using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MyOnlinePetStoreWeb.Models.Identity;

namespace MyOnlinePetStoreWeb.Areas.Identity.Pages.MyAccount {
    [AllowAnonymous]
    public class LogoutModel : PageModel {

        private readonly SignInManager<PetStoreIdentityUser> _signInManager;


        public LogoutModel(SignInManager<PetStoreIdentityUser> signInManager) {
            _signInManager = signInManager;
        }


        public async Task<IActionResult> OnGetAsync() {
            await _signInManager.SignOutAsync();
            return RedirectToPage("/Index");
        }

    }
}
