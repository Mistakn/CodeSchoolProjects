using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPEntity.Data {
    public class ApplicationContextSeed {

        public static async Task SeedIdentityAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager) {

            string[] rolesToInsert = Enum.GetNames<RolesEnum>();

            foreach (var role in rolesToInsert) {

                var roleData = new IdentityRole { Name = role };

                //var roleExists = roleManager.Roles.Any(role => role.Name == roleData.Name);
                var roleExists = await roleManager.RoleExistsAsync(roleData.Name);

                if (!roleExists) {
                    await roleManager.CreateAsync(roleData);
                }
            }


            var adminData = new {
                Email = "admin@admin.com",
                Password = "administrator"
            };

            var adminUserExists = await userManager.GetUsersInRoleAsync(RolesEnum.Administrator.ToString());

            if (adminUserExists.Count == 0) {

                var user = new ApplicationUser { UserName = adminData.Email, Email = adminData.Email };

                var userResult = await userManager.CreateAsync(user, adminData.Password);

                if (userResult.Succeeded) {
                    // Assign role
                    var roleResult = await userManager.AddToRoleAsync(user, RolesEnum.Administrator.ToString());

                    if (!roleResult.Succeeded) {
                        await userManager.DeleteAsync(user);
                    }
                }

            }
        }

    }
}
