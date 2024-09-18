namespace UsersCRUD.Domain.Users;

public class User {
	public required UserId Id { get; set; }
	public required UserName Name { get; set; }
	public required UserSurname Surname { get; set; }
	public required UserDNI DNI { get; set; }
}
