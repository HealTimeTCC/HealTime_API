using System.ComponentModel.DataAnnotations;

namespace WEB_API_HealTime.Dto.Pessoa;

public class ResetPasswordDto
{
    public string Email { get; set; }
    [Required]
    public string PasswordString { get; set; }    
    [Required]
    public string NewPasswordString { get; set; }
    public int? PessoaId { get; set; }
}
