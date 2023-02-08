using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WEB_API_HealTime.Models.Enuns;

namespace WEB_API_HealTime.Models;

public class Pessoa
{
    public int PessoaId { get; set; }

    public TipoPessoa TipoPessoa { get; set; }

    [Display(Name ="Nome")]
    public string NomePessoa { get; set; }

    [Display(Name ="Sobre nome")]
    public string SobrenomePessoa { get; set; }

    [Display(Name ="CPF")]
    public string CpfPessoa { get; set; }

    [Display(Name = "Ultimo Acesso")]
    public DateTime? DtUltimoAcesso { get; set; }

    public DateTime? DtNascimentoPessoa { get; set; }

    public Generos? GeneroPessoa { get; set; }

    public string ObsPacienteIncapaz { get; set; }

    public string EnderecoPessoa { get; set; }

    public string BairroEnderecoPessoa { get; set; }

    public string CidadeEnderecoPessoa { get; set; }

    public string ComplementoPessoa { get; set; }

    public string CepEndereco { get; set; }

    public UFs? UfEndereco { get; set; }

    [JsonIgnore]
    public List<ContatoPessoa> ContatosPessoas { get; set; }
    [JsonIgnore]
    public List<ResponsavelPaciente> PacienteIdInRe { get; set; }
    [JsonIgnore]
    public List<ResponsavelPaciente> ResponsavelIdRe { get; set; }
    [JsonIgnore]
    public List<CuidadorPaciente> CuidadorIdCpRE { get; set; }
    [JsonIgnore]
    public List<CuidadorPaciente> ResponsavelIdCpRE { get; set; }
    [JsonIgnore]
    public List<CuidadorPaciente> PacienteInIdCpRE { get; set; }
}