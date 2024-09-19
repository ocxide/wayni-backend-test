using MediatR;
using UsersCRUD.Domain.Users;

namespace UsersCRUD.Application.Users.Commands.UpdateOne;

public class Request : IRequest
{
    public required User User { get; init; }
}
