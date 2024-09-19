namespace UsersCRUD.Domain.Users;

public interface IUserRepository
{
    Task CreateOne(User user);
}
