namespace UsersCRUD.Domain.Users;

public interface IUsersRepository
{
    Task CreateOne(User user);
}
