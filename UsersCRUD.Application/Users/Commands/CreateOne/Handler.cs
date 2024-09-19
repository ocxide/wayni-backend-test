using MediatR;
using UsersCRUD.Domain.Users;

namespace UsersCRUD.Application.Users.Commands.CreateOne;

public class Handler : IRequestHandler<Request>
{
    private readonly IUserRepository userRepository;

    public Handler(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    public Task Handle(Request request, CancellationToken cancellationToken)
    {
        var user = request.User.ToUser(UserId.New());
				return userRepository.CreateOne(user);
    }
}
