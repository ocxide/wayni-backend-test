using MediatR;
using UsersCRUD.Domain.Users;

namespace UsersCRUD.Application.Users.Queries.GetAll;

public class Handler : IRequestHandler<Request, IEnumerable<User>>
{
    private readonly IUsersRepository userRepository;

    public Handler(IUsersRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    public Task<IEnumerable<User>> Handle(Request request, CancellationToken cancellationToken)
    {
        var users = userRepository.GetAll();
        return users;
    }
}
