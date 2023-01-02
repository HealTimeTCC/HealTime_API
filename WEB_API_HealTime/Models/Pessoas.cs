using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WEB_API_HealTime.Models.Enuns;

namespace WEB_API_HealTime.Models;

public class Pessoas
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int PessoaId { get; set; }

    [Required(ErrorMessage ="Tipo de pessoa é obrigatório")]
    public TipoPessoa TipoPessoa { get; set; }

    [Required(ErrorMessage ="Nome é obrigatório")]
    [Column(TypeName = "varchar(25)")]
    public string NomePessoa { get; set; }

    [Required(ErrorMessage = "Sobrenome é obrigatório")]
    [Column(TypeName = "varchar(40)")]
    public string SobrenomePessoa { get; set; }

    [Required(ErrorMessage = "Data nascimento é obrigatório")]
    [Column(TypeName = "date")]
    public DateTime dtNascimentoPesssoa { get; set; }
    public Generos GeneroPessoa { get; set; }

    [Column(TypeName = "varchar(350)")]
    public string ObsPacienteIncapaz { get; set; }

    [Required]
    [Column(TypeName = "varchar(45)")]
    public string EnderecoPessoa { get; set; }

    [Required]
    [Column(TypeName = "varchar(30)")]
    public string BairroEnderecoPessoa { get; set; }

    [Required]
    [Column(TypeName = "varchar(20)")]
    public string CidadeEnderecoPessoa { get; set; }

    [Column(TypeName = "varchar(45)")]
    public string ComplementoPessoa { get; set; }

    [Required]
    [Column(TypeName = "char(8)")]
    public string CepEndereco { get; set; }

    [Required]
    public UFs UfEndereco { get; set; }

    //public List<ResponsavelPaciente> Pacientes { get; set; }
    //public List<ResponsavelPaciente> Responsaveis { get; set; }
}
