using UsersCRUD.Domain.Users;

namespace UsersCRUD.Application.Users.Dtos;

public class UserDto
{
    public required UserName Name { get; init; }
    public required UserSurname Surname { get; init; }
    public required UserDNI DNI { get; init; }

    public User ToUser(UserId id) =>
        new User
        {
            Id = id,
            Name = Name,
            Surname = Surname,
            DNI = DNI,
        };
}
