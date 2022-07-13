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
            await roleManager.CreateAsync(new IdentityRole("User"));

            var defaultUserName = "rjnay1984@gmail.com";
            var defaultUser = new ApplicationUser 
            {
                UserName = defaultUserName,
                Email = defaultUserName,
                EmailConfirmed = true,
            };
            await userManager.CreateAsync(defaultUser, "P@ssw0rd");
            defaultUser = await userManager.FindByNameAsync(defaultUserName);
            await userManager.AddToRoleAsync(defaultUser, "User");

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