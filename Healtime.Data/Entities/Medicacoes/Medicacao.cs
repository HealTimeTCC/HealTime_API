using Healtime.Domain.Entities.Medicacoes.Enums;
using System.Text.Json.Serialization;

namespace Healtime.Domain.Entities.Medicacoes;

public class Medicacao
{
    public int MedicacaoId { get; set; }
    public EnumStatusMedicacao StatusMedicacao { get; set; }
    public int TipoMedicacaoId { get; set; }
    public TipoMedicacao TipoMedicacao { get; set; }
    public string NomeMedicacao { get; set; }
    public string CompostoAtivoMedicacao { get; set; }
    public string LaboratorioMedicacao { get; set; }
    public string Generico { get; set; }
    public int CodPessoaAlter { get; set; }
    [JsonIgnore]
    public PrescricaoMedicacao PrescricaoMedicacao { get; set; }
}
