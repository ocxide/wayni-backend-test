namespace UsersCRUD.Infrastructure;

using Microsoft.EntityFrameworkCore;
using UsersCRUD.Domain.Users;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<User> Users { get; set; } = null!;
}
