
using Newtonsoft.Json;

namespace WEB_API_HealTime.Models;

public class Estoque
{
    public int MedicacaoId { get; set; }
    [JsonIgnore]
    public Medicacao Medicacao { get; set; }
    public int QtdEstoque { get; set; }
    public string Nome { get; set; }
    public string Desc { get; set; }
    public DateTime AtualizadoEm { get; set; }
    public DateTime CriadoEm { get; set; }
}
