using MediatR;
using UsersCRUD.Domain.LanguageExt;
using UsersCRUD.Domain.Users;

namespace UsersCRUD.Application.Users.Queries.GetById;

public class Request : IRequest<Option<User>>
{
    public required UserId Id { get; init; }
}
