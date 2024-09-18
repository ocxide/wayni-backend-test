namespace UsersCRUD.Domain.Users;

public class User {
	public required Guid Id { get; set; }
	public required string Name { get; set; }
	public required string Surname { get; set; }
	public required UserDNI DNI { get; set; }
}
