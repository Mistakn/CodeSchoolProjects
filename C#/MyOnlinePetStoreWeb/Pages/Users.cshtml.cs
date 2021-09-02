using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyOnlinePetStoreWeb.Models.Identity;

namespace MyOnlinePetStoreWeb.Pages {
    public class UsersModel : PageModel {


        private readonly UserManager<PetStoreIdentityUser> _userManager;


        public UsersModel(
            UserManager<PetStoreIdentityUser> userManager) {
            _userManager = userManager;
        }


        public List<PetStoreIdentityUser> Users { get; set; }


        public async Task OnGetAsync() {
            //Users = await _userManager.Users.Include(u => u.UserRoles).ThenInclude(ur => ur.Role).ToListAsync();
            Users = await _userManager.Users.ToListAsync();
        }
    }
}
