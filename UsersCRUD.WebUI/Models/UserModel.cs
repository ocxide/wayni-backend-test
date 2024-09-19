using System.ComponentModel.DataAnnotations;
using UsersCRUD.Application.Users.Dtos;

namespace UsersCRUD.WebUI.Models;

public class UserModel
{
    [Required]
    public required string Name { get; set; }

    [Required]
    public required string Surname { get; set; }

    [Required]
    [RegularExpression(@"[0-9]{8}", ErrorMessage = "DNI must have 8 digits")]
    [StringLength(8, MinimumLength = 8, ErrorMessage = "DNI must have 8 digits")]
    public required string DNI { get; set; }

    public UserDto ToDto() =>
        new()
        {
            Name = new(Name),
            Surname = new(Surname),
            DNI = new(DNI),
        };
}
