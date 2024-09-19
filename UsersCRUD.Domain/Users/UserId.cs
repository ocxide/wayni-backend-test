using System.Diagnostics.CodeAnalysis;

namespace UsersCRUD.Domain.Users;

public readonly record struct UserId : IParsable<UserId>
{
    public Guid Value { get; }

    public UserId(Guid value)
    {
        this.Value = value;
    }

    public static UserId New()
    {
        return new UserId(Guid.NewGuid());
    }

    public override string? ToString()
    {
        return Value.ToString();
    }

    public static UserId Parse(string s, IFormatProvider? provider)
    {
				return new UserId(Guid.Parse(s));
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out UserId result)
    {
        var parsed = Guid.TryParse(s, out var id);
        result = new UserId(id);
        return parsed;
    }
}
