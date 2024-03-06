using Ciel.Models;
using Microsoft.AspNetCore.Identity;

namespace Ciel.CreateRoles
{
    public class SeedData
    {
        public static void Seed(UserManager<ApplicationUser> userManager,
     RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }
        public static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            if (userManager.FindByNameAsync("Admin").Result == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "Admin",
                    Name = "Admin",
                    LastName = "Administrator",
                    Email = "admin@gmail.com",
                    PhoneNumber = "0878806961",
                    EGN = "0505153457"
                };

                var result = userManager.CreateAsync(user, "Admin123*").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }
        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                var role = new IdentityRole
                {
                    Name = "Admin"
                };
                var result = roleManager.CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Customer").Result)
            {
                var role = new IdentityRole
                {
                    Name = "Customer"
                };
                var result = roleManager.CreateAsync(role).Result;
            }
        }
    }
}
