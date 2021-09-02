using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ASPEntity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPEntity.Areas.Identity.Pages.MyAccount {
    public class ExternalLoginModel : PageModel {


        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public ExternalLoginModel(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager) {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [BindProperty]
        public string Provider { get; set; }


        public void OnGet() {
        }


        public IActionResult OnPost(string provider, string returnUrl = null) {
            // properties se encarga de configurar el redireccionamiento hacia el login externo
            var redirectURL = Url.Page("./ExternalLogin", pageHandler: "Callback");
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(Provider, redirectURL);
            return new ChallengeResult(Provider, properties);
        }


        public async Task<IActionResult> OnGetCallbackAsync(string returnUrl, string remoteError) {
            var info = await _signInManager.GetExternalLoginInfoAsync();

            if (info == null) {
                return RedirectToPage("./Login");
            }

            var externalLoginResult = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: true);

            if (externalLoginResult.Succeeded) {
                return RedirectToPage("/Index");

            } else {
                if (info.Principal.HasClaim(c => c.Type == ClaimTypes.Email)) {
                    var user = new ApplicationUser {
                        Email = info.Principal.FindFirstValue(ClaimTypes.Email),
                        UserName = info.Principal.FindFirstValue(ClaimTypes.Email)
                    };

                    var createUserResult = await _userManager.CreateAsync(user);

                    if (createUserResult.Succeeded) {
                        var loginResult = await _userManager.AddLoginAsync(user, info);

                        if (loginResult.Succeeded) {
                            await _signInManager.SignInAsync(user, isPersistent: true, info.LoginProvider);
                            return RedirectToPage("/Index");
                        }
                    }
                }
            }

            return RedirectToPage("/AccessDenied");
        }
    }
}
