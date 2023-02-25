using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using WEB_API_HealTime.Models.Enuns;

namespace WEB_API_HealTime.Models;

public class Medicacao
{
    public int MedicacaoId { get; set; }
    public string Nome { get; set; }
    public int TipoMedicacaoId { get; set; }
    [JsonIgnore]
    public TipoMedicacao TipoMedicacao { get; set; }
    public ComposicoesEnum? Composicao { get; set; }
    public bool? StatusMedicacao { get; set; }
    [NotMapped]
    public string Fabricante { get; set; }
    [NotMapped]
    public string Desc { get; set; }
    [NotMapped]
    public int? QtdMedicacao { get; set; }
    [JsonIgnore]
    public PrescricaoMedicamento? PrescricaoMedicamento { get; set; }
    [JsonIgnore]
    public Estoque Estoque { get; set; }
}   
