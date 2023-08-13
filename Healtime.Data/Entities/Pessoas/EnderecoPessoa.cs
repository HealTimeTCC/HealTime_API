using Newtonsoft.Json;

namespace Healtime.Domain.Entities.Pessoas;

public class EnderecoPessoa
{
    public int PessoaId { get; set; }
    [JsonIgnore]
    public Pessoa Pessoa { get; set; }
    public string Logradouro { get; set; }
    public int NroLogradouro { get; set; }
    public string Complemento { get; set; }
    public string BairroLogradouro { get; set; }
    public string CidadeEndereco { get; set; }
    public string UFEndereco { get; set; }
    public string CEPEndereco { get; set; }
}
