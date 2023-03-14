using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEB_API_HealTime.Models.Medicacoes;

public class Pessoa
{
    public int PessoaId { get; set; }
    public int? TipoPessoaId { get; set; }
    public string CpfPessoa { get; set; }
    public string NomePessoa { get; set; }
    public string SobreNomePessoa { get; set; }
    [NotMapped]
    public string PasswordString { get; set; }
    [JsonIgnore]
    public byte[] PasswordHash { get; set; }
    [JsonIgnore]
    public byte[] PasswordSalt { get; set; }
    public DateTime? DtNascPessoa { get; set; }
    [NotMapped]
    public string TokenJwt { get; set; }
    [JsonIgnore]
    public List<PrescricaoPaciente> PrescricaoPacientes { get; set; }
}
