namespace UsersCRUD.Domain.Users;

public readonly record struct UserSurname(string Value)
{
    public override string? ToString()
    {
        return Value;
    }
}
