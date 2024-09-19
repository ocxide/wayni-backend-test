namespace UsersCRUD.Domain.Users;

public readonly record struct UserDNI(string Value)
{
    public string Value { get; init; } =
        (Value.Count() == 8 && Value.All(char.IsDigit))
            ? Value
            : throw new ArgumentException("DNI must have 8 digits");

		public override string? ToString()
		{
				return Value;
		}
}
