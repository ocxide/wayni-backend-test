using Microsoft.EntityFrameworkCore;
using UsersCRUD.Domain.LanguageExt;
using UsersCRUD.Domain.Users;

namespace UsersCRUD.Infrastructure.Repositories;

public class MySQLUsersRepository : IUsersRepository
{
    private readonly AppDbContext context;

    public MySQLUsersRepository(AppDbContext dbContext)
    {
        this.context = dbContext;
    }

    public async Task CreateOne(User user)
    {
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        return await context.Users.ToListAsync();
    }

    public async Task<Option<User>> GetById(UserId id)
    {
        var user = await context.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
        return user;
    }

    public async Task UpdateOne(User user)
    {
        context.Users.Update(user);
        await context.SaveChangesAsync();
    }

    public async Task DeleteOne(UserId id)
    {
        await context.Users.Where(c => c.Id == id).ExecuteDeleteAsync();
        await context.SaveChangesAsync();
    }
}
