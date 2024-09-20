using UsersCRUD.Domain.LanguageExt;

namespace UsersCRUD.Domain.Users;

public interface IUsersRepository
{
    Task CreateOne(User user);
    Task DeleteOne(UserId id);
    Task<IEnumerable<User>> GetAll();
    Task<Option<User>> GetById(UserId id);
    Task UpdateOne(User user);
}
