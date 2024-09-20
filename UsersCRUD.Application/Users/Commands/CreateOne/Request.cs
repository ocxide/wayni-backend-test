using MediatR;
using UsersCRUD.Application.Users.Dtos;
using UsersCRUD.Domain.LanguageExt;
using UsersCRUD.Domain.Users;

namespace UsersCRUD.Application.Users.Commands.CreateOne;

public class Request : IRequest<Result<User, UserSaveError>> {
	public required UserDto User { get; set; }
}
