using MediatR;
using UsersCRUD.Domain.Users;

namespace UsersCRUD.Application.Users.Commands.DeleteOne;

public record struct Request(UserId Id) : IRequest;
