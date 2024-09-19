using UsersCRUD.Domain.Users;

namespace UsersCRUD.Infrastructure.Repositories;

public class MySQLUsersRepository : IUsersRepository
{
    private readonly AppDbContext dbContext;

    public MySQLUsersRepository(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task CreateOne(User user)
    {
        await dbContext.Users.AddAsync(user);
				await dbContext.SaveChangesAsync();
    }
}
