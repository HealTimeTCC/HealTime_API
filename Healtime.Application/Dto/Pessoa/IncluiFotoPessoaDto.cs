using System.ComponentModel.DataAnnotations;

namespace Healtime.Application.Dto.Pessoa;

public class IncluiFotoPessoaDto
{
    public int PessoaId { get; set; }
    [Required]
    public byte[] FotoPessoa { get; set; }
}
