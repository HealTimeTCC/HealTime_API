using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WEB_API_HealTime.Models.Enuns;

namespace WEB_API_HealTime.Models;

public class ContatoPessoa
{
    [Key]
    public int ContatoId { get; set; }
    
    [JsonIgnore]
    public Pessoa Pessoas { get; set; }
    //public Guid PessoaId { get; set; }
    public string PessoaId { get; set; }

    [Column(TypeName = "VARCHAR(11)")]
    public string TelefoneCelularObri { get; set; }

    [Column(TypeName = "VARCHAR(11)")]
    public string? TelefoneCelularOpcional { get; set; }

    [Column(TypeName = "VARCHAR(10)")]
    public string TelefoneFixo { get; set; }

    [Column(TypeName = "VARCHAR(70)")]
    public string EmailContato { get; set; }
    public TipoCtt TipoCtt { get; set; }
}
