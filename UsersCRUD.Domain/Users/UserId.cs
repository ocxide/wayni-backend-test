namespace UsersCRUD.Domain.Users;

public readonly record struct UserId(Guid Value)
{
    public static UserId New() => new(Guid.NewGuid());
}
