using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace YelpcampNet.Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedAsync(
            AppIdentityDbContext identityDbContext, UserManager<ApplicationUser> userManager, 
            RoleManager<IdentityRole> roleManager)
        {
            identityDbContext.Database.Migrate();

            await roleManager.CreateAsync(new IdentityRole("Admin"));

            var defaultUser = new ApplicationUser 
            {
                UserName = "rjnay1984@gmail.com",
                Email = "rjnay1984@gmail.com",
                EmailConfirmed = true,
            };
            await userManager.CreateAsync(defaultUser, "P@ssw0rd");

            var adminUserName = "admin@yelpcamp.com";
            var adminUser = new ApplicationUser 
            { 
                UserName = adminUserName, 
                Email = adminUserName, 
                EmailConfirmed = true 
            };
            await userManager.CreateAsync(adminUser, "P@ssw0rd");
            adminUser = await userManager.FindByNameAsync(adminUserName);
            await userManager.AddToRoleAsync(adminUser, "Admin");
        }
    }
}