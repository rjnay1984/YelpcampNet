using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using YelpcampNet.ApplicationCore.Constants;

namespace YelpcampNet.Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedAsync(
            AppIdentityDbContext identityDbContext, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            identityDbContext.Database.Migrate();

            await roleManager.CreateAsync(new IdentityRole(IdentityConstants.ADMIN_USER_ROLE));
            await roleManager.CreateAsync(new IdentityRole(IdentityConstants.CAMPGROUND_MANAGER_ROLE));
            await roleManager.CreateAsync(new IdentityRole(IdentityConstants.CAMPGROUND_USER_ROLE));

            var password = IdentityConstants.DEFAULT_PASSWORD;

            var defaultUserName = IdentityConstants.CAMPGROUND_USER;
            var defaultUser = new ApplicationUser
            {
                UserName = defaultUserName,
                Email = defaultUserName,
                EmailConfirmed = true,
            };
            await userManager.CreateAsync(defaultUser, password);
            defaultUser = await userManager.FindByNameAsync(defaultUserName);
            await userManager.AddToRoleAsync(defaultUser, IdentityConstants.CAMPGROUND_USER_ROLE);

            var campManagerUserName = IdentityConstants.CAMPGROUND_MANAGER;
            var campManagerUser = new ApplicationUser
            {
                UserName = campManagerUserName,
                Email = campManagerUserName,
                EmailConfirmed = true,
            };
            await userManager.CreateAsync(campManagerUser, password);
            campManagerUser = await userManager.FindByNameAsync(campManagerUserName);
            await userManager.AddToRoleAsync(campManagerUser, IdentityConstants.CAMPGROUND_MANAGER_ROLE);

            var adminUserName = IdentityConstants.ADMIN_USER;
            var adminUser = new ApplicationUser
            {
                UserName = adminUserName,
                Email = adminUserName,
                EmailConfirmed = true
            };
            await userManager.CreateAsync(adminUser, password);
            adminUser = await userManager.FindByNameAsync(adminUserName);
            await userManager.AddToRoleAsync(adminUser, IdentityConstants.ADMIN_USER_ROLE);
        }
    }
}