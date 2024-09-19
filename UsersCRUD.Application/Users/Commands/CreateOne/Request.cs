using MediatR;
using UsersCRUD.Application.Users.Dtos;

namespace UsersCRUD.Application.Users.Commands.CreateOne;

public class Request : IRequest {
	public required UserDto User { get; set; }
}
