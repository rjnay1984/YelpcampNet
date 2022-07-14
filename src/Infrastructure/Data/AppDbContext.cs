using Microsoft.EntityFrameworkCore;
using YelpcampNet.ApplicationCore.Entities;

namespace YelpcampNet.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Campground> Campgrounds { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}