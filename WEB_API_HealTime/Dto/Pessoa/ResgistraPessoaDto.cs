using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WEB_API_HealTime.Models.Medicacoes;
using WEB_API_HealTime.Models.Pessoas.Enums;
using WEB_API_HealTime.Models.Pessoas;
using System.Text.Json.Serialization;

namespace WEB_API_HealTime.Dto.Pessoa;

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
