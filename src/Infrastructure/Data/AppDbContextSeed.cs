using Microsoft.EntityFrameworkCore;
using YelpcampNet.ApplicationCore.Entities;

namespace YelpcampNet.Infrastructure.Data
{
    public class AppDbContextSeed
    {
        public static async Task SeedAsync(AppDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            if (!await context.Campgrounds.AnyAsync())
            {
                await context.Campgrounds.AddRangeAsync(SeedCampgrounds());
                await context.SaveChangesAsync();
            }
        }

        static IEnumerable<Campground> SeedCampgrounds()
        {
            return new List<Campground>
            {
                new Campground()
                {
                    Title = "Campground 1",
                    Teaser = "Campground 1 Teaser",
                    Description = "Campground 1 description is here."
                },

                new Campground()
                {
                    Title = "Campground 2",
                    Teaser = "Campground 2 Teaser",
                    Description = "Campground 2 description goes here."
                }
            };
        }
    }
}