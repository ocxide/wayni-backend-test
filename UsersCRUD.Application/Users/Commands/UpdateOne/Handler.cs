using MediatR;
using UsersCRUD.Domain.Users;

namespace UsersCRUD.Application.Users.Commands.UpdateOne;

public class Handler : IRequestHandler<Request>
{
    private readonly IUsersRepository userRepository;

    public Handler(IUsersRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    public Task Handle(Request request, CancellationToken cancellationToken) => userRepository.UpdateOne(request.User);
}
