using System.ComponentModel.DataAnnotations.Schema;

namespace UsersCRUD.Domain.Users;

[ComplexType]
public record UserDNI(string Document)
{
    public string Document { get; init; } =
        (Document.Count() == 8 && Document.All(char.IsDigit))
            ? Document
            : throw new ArgumentException("DNI must have 8 digits");
}
