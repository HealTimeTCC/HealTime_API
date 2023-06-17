using System.Text.Json.Serialization;
using WEB_API_HealTime.Models.Medicacoes.Enums;
using WEB_API_HealTime.Models.Pessoas;

namespace WEB_API_HealTime.Models.Medicacoes;

public class Medicacao
{
    public int MedicacaoId { get; set; }
    public EnumStatusMedicacao StatusMedicacao { get; set; }
    public int TipoMedicacaoId { get; set; }
    [JsonIgnore]
    public TipoMedicacao TipoMedicacao { get; set; }
    public string NomeMedicacao { get; set; }
    public string CompostoAtivoMedicacao { get; set; }
    public string LaboratorioMedicaocao { get; set; }
    public string Generico { get; set; }
    public int CodPessoaAlter { get; set; }
    [JsonIgnore]
    public PrescricaoMedicacao PrescricaoMedicacao { get; set; }
}