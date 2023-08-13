using System.ComponentModel.DataAnnotations;

namespace Healtime.Application.Dto.Pessoa;

public class LoginPasswordDto
{
    [Required]
    public string Email { get; set; }
    [Required]
    public string PasswordString { get; set; }
}
