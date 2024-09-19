namespace UsersCRUD.Domain.Users;

public readonly record struct UserName(string Value)
{
    public override string? ToString()
    {
        return Value;
    }
}
