using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

using System.Text.Json.Serialization;
using Healtime.Domain.Enums;

namespace Healtime.Application.Dto.Pessoa;

public class ResgistraPessoaDto
{
    [Required]
    public EnumTipoPessoa TipoPessoa { get; set; }
    [Required]
    public string CpfPessoa { get; set; }
    [Required]
    public string NomePessoa { get; set; }
    [Required]
    public string SobreNomePessoa { get; set; }
    public string PasswordString { get; set; }
    [Required]
    public DateTime DtNascPessoa { get; set; }
    //Relativo a ContatoPessoa Inicial
    public string ContatoCelular { get; set; }
    public string ContatoEmail { get; set; }
    public DateTime ContatoCriadoEm { get; set; }
}
