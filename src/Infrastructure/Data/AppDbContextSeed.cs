using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using YelpcampNet.ApplicationCore.Constants;
using YelpcampNet.ApplicationCore.Entities;
using YelpcampNet.Infrastructure.Identity;

namespace YelpcampNet.Infrastructure.Data
{
    public class AppDbContextSeed
    {
        public static async Task SeedAsync(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            var campgroundMgr = await userManager.FindByEmailAsync(IdentityConstants.CAMPGROUND_MANAGER);
            var campgroundUsr = await userManager.FindByEmailAsync(IdentityConstants.CAMPGROUND_USER);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            if (!await context.Campgrounds.AnyAsync())
            {
                await context.Campgrounds.AddRangeAsync(SeedCampgrounds(campgroundMgr));
                await context.SaveChangesAsync();
            }

            if (!await context.Comments.AnyAsync())
            {
                await context.Comments.AddRangeAsync(SeedComments(campgroundUsr));
                await context.SaveChangesAsync();
            }
        }

        static IEnumerable<Campground> SeedCampgrounds(ApplicationUser campgroundMgr)
        {
            return new List<Campground>
            {
                new Campground()
                {
                    Title = "Campground 1",
                    Teaser = "Campground 1 Teaser",
                    Description = "Campground 1 description is here.",
                    UserId = campgroundMgr.Id
                },

                new Campground()
                {
                    Title = "Campground 2",
                    Teaser = "Campground 2 Teaser",
                    Description = "Campground 2 description goes here.",
                    UserId = campgroundMgr.Id
                }
            };
        }

        static IEnumerable<Comment> SeedComments(ApplicationUser campgroundUsr)
        {
            return new List<Comment>
            {
                new Comment()
                {
                    Title = "Campground 1 Comment",
                    Text = "Campground 1 comment text.",
                    CampgroundId = 1,
                    UserId = campgroundUsr.Id
                },

                new Comment()
                {
                    Title = "Campground 1 Comment 2",
                    Text = "Campground 1 comment 2 text.",
                    CampgroundId = 1,
                    UserId = campgroundUsr.Id
                },

                new Comment()
                {
                    Title = "Campground 2 Comment",
                    Text = "Campground 2 comment text.",
                    CampgroundId = 2,
                    UserId = campgroundUsr.Id
                }
            };
        }
    }
}