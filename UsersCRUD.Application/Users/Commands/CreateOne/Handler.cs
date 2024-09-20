using MediatR;
using UsersCRUD.Domain.LanguageExt;
using UsersCRUD.Domain.Users;

namespace UsersCRUD.Application.Users.Commands.CreateOne;

public class Handler : IRequestHandler<Request, Result<User, UserSaveError>>
{
    private readonly IUsersRepository userRepository;

    public Handler(IUsersRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    public Task<Result<User, UserSaveError>> Handle(
        Request request,
        CancellationToken cancellationToken
    )
    {
        var user = request.User.ToUser(UserId.New());
        return userRepository.CreateOne(user);
    }
}
