using MediatR;
using UsersCRUD.Domain.LanguageExt;
using UsersCRUD.Domain.Users;

namespace UsersCRUD.Application.Users.Commands.UpdateOne;

public class Request : IRequest<Result<User, UserSaveError>>
{
    public required User User { get; init; }
}
