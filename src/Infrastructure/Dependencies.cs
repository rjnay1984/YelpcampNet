using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using YelpcampNet.Infrastructure.Identity;

namespace YelpcampNet.Infrastructure;

public static class Dependencies
{
    public static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
    {
        services.AddDbContext<AppIdentityDbContext>(options => 
            options.UseNpgsql(configuration.GetConnectionString("IdentityConnection")));
    }
}