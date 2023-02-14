
using Newtonsoft.Json;

namespace WEB_API_HealTime.Models;

public class BaixaHistoricoEstoque
{
    public int BaixaHistoricoEstoqueId { get; set; }
    public int EstoqueId { get; set;}
    [JsonIgnore]
    public Estoque Estoque { get; set; }
    public DateTime? BaixaEm { get; set; }
    public string DescBaixa { get; set; }
}
