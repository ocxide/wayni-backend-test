namespace UsersCRUD.Domain.LanguageExt;

public abstract class Option<T>
{
    public static Option<T> Some(T value) => new Some<T> { Value = value };

    public static Option<T> None() => new None<T>();

    public static implicit operator Option<T>(T? value) => value is null ? None() : Some(value);

    public T Unwrap()
    {
        if (this is Some<T> some)
            return some.Value;
        else
            throw new InvalidOperationException("Option is None");
    }
}

public sealed class Some<T> : Option<T>
{
    public required T Value { get; init; }
}

public sealed class None<T> : Option<T> { }
