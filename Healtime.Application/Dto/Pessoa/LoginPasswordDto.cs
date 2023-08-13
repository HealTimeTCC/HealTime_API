using System.ComponentModel.DataAnnotations;

namespace WEB_API_HealTime.Dto.Pessoa;

public class LoginPasswordDto
{
    [Required]
    public string Email { get; set; }
    [Required]
    public string PasswordString { get; set; }
}
