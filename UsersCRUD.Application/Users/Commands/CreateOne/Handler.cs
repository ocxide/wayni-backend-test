using MediatR;
using UsersCRUD.Domain.Users;

namespace UsersCRUD.Application.Users.Commands.CreateOne;

public class Handler : IRequestHandler<Request, int>
{
    private readonly IUsersRepository userRepository;

    public Handler(IUsersRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    public async Task<int> Handle(Request request, CancellationToken cancellationToken)
    {
        var user = request.User.ToUser(UserId.New());
        await userRepository.CreateOne(user);
				return 2;
    }
}
