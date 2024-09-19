using Microsoft.EntityFrameworkCore;
using UsersCRUD.Domain.LanguageExt;
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

    public async Task<IEnumerable<User>> GetAll()
    {
        return await dbContext.Users.ToListAsync();
    }

    public async Task<Option<User>> GetById(UserId id)
    {
        var user = await dbContext.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
				return user;
    }

    public async Task UpdateOne(User user)
    {
				dbContext.Users.Update(user);
				await dbContext.SaveChangesAsync();
    }
}
