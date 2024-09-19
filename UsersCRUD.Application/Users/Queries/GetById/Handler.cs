using MediatR;
using UsersCRUD.Domain.LanguageExt;
using UsersCRUD.Domain.Users;

namespace UsersCRUD.Application.Users.Queries.GetById;

public class Handler : IRequestHandler<Request, Option<User>>
{
    private readonly IUsersRepository userRepository;

    public Handler(IUsersRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    public Task<Option<User>> Handle(Request request, CancellationToken cancellationToken)
    {
        return userRepository.GetById(request.Id);
    }
}
