namespace UsersCRUD.Domain.Users;

public abstract class UserSaveError { }

public class DuplicatedDNI : UserSaveError { }
