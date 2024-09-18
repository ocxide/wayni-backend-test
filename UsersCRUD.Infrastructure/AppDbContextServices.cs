using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace UsersCRUD.Infrastructure;

public static class AppDbContextServices
{
    public static IServiceCollection AddAppDbContext(
        this IServiceCollection services,
        IConfiguration Configuration
    )
    {
        services.AddDbContext<AppDbContext>(opts =>
            opts.UseMySql(
                Configuration.GetConnectionString("DefaultConnection"),
                new MySqlServerVersion(new Version(8, 0))
            )
        );
        return services;
    }
}
