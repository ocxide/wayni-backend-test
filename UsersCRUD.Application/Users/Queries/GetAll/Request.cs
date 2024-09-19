using MediatR;
using UsersCRUD.Domain.Users;

namespace UsersCRUD.Application.Users.Queries.GetAll;

public class Request : IRequest<IEnumerable<User>> { }
