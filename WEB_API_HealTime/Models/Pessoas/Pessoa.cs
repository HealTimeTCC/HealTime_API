using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using WEB_API_HealTime.Models.Medicacoes;
using WEB_API_HealTime.Models.Pacientes;
using WEB_API_HealTime.Models.Pessoas.Enums;

namespace WEB_API_HealTime.Models.Pessoas;

public class Pessoa
{
    public int PessoaId { get; set; }
    public EnumTipoPessoa TipoPessoa { get; set; }
    public string CpfPessoa { get; set; }
    public string NomePessoa { get; set; }
    public string SobreNomePessoa { get; set; }
    [NotMapped]
    public string PasswordString { get; set; }
    [JsonIgnore]
    public byte[] PasswordHash { get; set; }
    [JsonIgnore]
    public byte[] PasswordSalt { get; set; }
    public DateTime DtNascPessoa { get; set; }
    [NotMapped]
    public string TokenJwt { get; set; }
    [JsonIgnore]
    public List<PrescricaoPaciente> PrescricaoPacientes { get; set; }
    [JsonIgnore]
    public EnderecoPessoa EnderecoPessoa { get; set; } 
    [JsonIgnore]
    public ContatoPessoa ContatoPessoa { get; set; }
    [JsonIgnore]
    public List<ObservacaoPaciente> ObservacoesPacientes { get; set; }
    public List<ResponsavelPaciente> ResponsavelPacientes_Responsaveis { get; set; }
    public List<ResponsavelPaciente> ResponsavelPacientes_Pacientes { get; set; }
    
}
