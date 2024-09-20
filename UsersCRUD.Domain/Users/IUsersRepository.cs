using UsersCRUD.Domain.LanguageExt;

namespace UsersCRUD.Domain.Users;

public interface IUsersRepository
{
    Task<Result<User, UserSaveError>> CreateOne(User user);
    Task DeleteOne(UserId id);
    Task<IEnumerable<User>> GetAll();
    Task<Option<User>> GetById(UserId id);
    Task<Result<User, UserSaveError>> UpdateOne(User user);
}
