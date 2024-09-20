using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UsersCRUD.Domain.Users;
using UsersCRUD.Infrastructure.Repositories;

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
                    new MySqlServerVersion(new Version(8, 0)),
                    cfg => cfg.EnableRetryOnFailure()
                )
                .EnableDetailedErrors()
        );

        services.AddScoped<IUsersRepository, MySQLUsersRepository>();

        return services;
    }

    public static IServiceProvider UseDbMigrations(this IServiceProvider services)
    {
			Console.WriteLine("UseDbMigrations2");
        var scope = services.CreateScope();
        scope.ServiceProvider.GetRequiredService<AppDbContext>().Database.Migrate();

        return services;
    }
}
