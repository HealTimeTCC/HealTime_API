
using Newtonsoft.Json;
using WEB_API_HealTime.Models.Enuns;

namespace WEB_API_HealTime.Models;

public class EnderecoPessoa
{
    public int? PessoaId { get; set; }
    [JsonIgnore]
    public Pessoa? Pessoa { get; set; }
    public string Endereco { get; set; }
    public string BairroEndereco { get; set; }
    public string CidadeEndereco { get; set; }
    public string Complemento { get; set; }
    public string CepEndereco { get; set; }
    public UFs? UfEndereco { get; set; }

}
