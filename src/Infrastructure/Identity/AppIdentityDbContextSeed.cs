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
            await roleManager.CreateAsync(new IdentityRole("CampManager"));
            await roleManager.CreateAsync(new IdentityRole("User"));

            var password = "P@ssw0rd";

            var defaultUserName = "rjnay1984@gmail.com";
            var defaultUser = new ApplicationUser
            {
                UserName = defaultUserName,
                Email = defaultUserName,
                EmailConfirmed = true,
            };
            await userManager.CreateAsync(defaultUser, password);
            defaultUser = await userManager.FindByNameAsync(defaultUserName);
            await userManager.AddToRoleAsync(defaultUser, "User");

            var campManagerUserName = "campmanager1@yelpcamp.com";
            var campManagerUser = new ApplicationUser
            {
                UserName = campManagerUserName,
                Email = campManagerUserName,
                EmailConfirmed = true,
            };
            await userManager.CreateAsync(campManagerUser, password);
            campManagerUser = await userManager.FindByNameAsync(campManagerUserName);
            await userManager.AddToRoleAsync(campManagerUser, "CampManager");

            var adminUserName = "admin@yelpcamp.com";
            var adminUser = new ApplicationUser
            {
                UserName = adminUserName,
                Email = adminUserName,
                EmailConfirmed = true
            };
            await userManager.CreateAsync(adminUser, password);
            adminUser = await userManager.FindByNameAsync(adminUserName);
            await userManager.AddToRoleAsync(adminUser, "Admin");
        }
    }
}