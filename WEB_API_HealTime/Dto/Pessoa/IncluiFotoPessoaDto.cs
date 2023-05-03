using System.ComponentModel.DataAnnotations;

namespace WEB_API_HealTime.Dto.Pessoa;

public class IncluiFotoPessoaDto
{
    public int PessoaId { get; set; }
    [Required]
    public byte[] FotoPessoa { get; set; }
}
