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

            if (!await context.Comments.AnyAsync())
            {
                await context.Comments.AddRangeAsync(SeedComments());
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

        static IEnumerable<Comment> SeedComments()
        {
            return new List<Comment>
            {
                new Comment()
                {
                    Title = "Campground 1 Comment",
                    Text = "Campground 1 comment text.",
                    CampgroundId = 1
                },

                new Comment()
                {
                    Title = "Campground 1 Comment 2",
                    Text = "Campground 1 comment 2 text.",
                    CampgroundId = 1
                },

                new Comment()
                {
                    Title = "Campground 2 Comment",
                    Text = "Campground 2 comment text.",
                    CampgroundId = 2
                }
            };
        }
    }
}