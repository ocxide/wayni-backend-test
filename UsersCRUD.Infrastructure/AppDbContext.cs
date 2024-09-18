namespace UsersCRUD.Infrastructure;

using Microsoft.EntityFrameworkCore;
using UsersCRUD.Domain.Users;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var users = modelBuilder.Entity<User>();

        users.Property(u => u.Id).HasConversion(id => id.Value, id => new(id));
				users.Property(u => u.Name).HasConversion(name => name.Value, name => new(name));
				users.Property(u => u.Surname).HasConversion(surname => surname.Value, surname => new(surname));
        users.Property(u => u.DNI).HasConversion(dni => dni.Value, dni => new(dni));

        base.OnModelCreating(modelBuilder);
    }
}
