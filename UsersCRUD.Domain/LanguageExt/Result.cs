namespace UsersCRUD.Domain.LanguageExt;

public abstract class Result<T, E>
{
    public static Result<T, E> Ok(T value) => new Ok<T, E> { Value = value };

    public static Result<T, E> Err(E err) => new Err<T, E> { Error = err };

    public static implicit operator Result<T, E>(T value) => Ok(value);

    public static implicit operator Result<T, E>(E err) => Err(err);

    public U Match<U>(Func<T, U> ok, Func<E, U> err)
    {
        if (this is Ok<T, E> okVal)
        {
            return ok(okVal.Value);
        }

        var errVal = (this as Err<T, E>)!.Error;
        return err(errVal);
    }
}

public sealed class Ok<T, E> : Result<T, E>
{
    public required T Value { get; init; }
}

public sealed class Err<T, E> : Result<T, E>
{
    public required E Error { get; init; }
}
