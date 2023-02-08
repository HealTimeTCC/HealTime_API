using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WEB_API_HealTime.Models.Enuns;

namespace WEB_API_HealTime.Models;

public class ContatoPessoa
{
    public int ContatoId { get; set; }
    public int PessoaId { get; set; }
    [JsonIgnore]
    public Pessoa Pessoa { get; set; }
    public string TelefoneCelularObri { get; set; }
    public string TelefoneCelularOpcional { get; set; }
    public string TelefoneFixo { get; set; }
    public string EmailContato { get; set; }
    public TipoCtt? TipoCtt { get; set; }
}
