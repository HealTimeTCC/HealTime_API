using Newtonsoft.Json;

namespace WEB_API_HealTime.Models;

public class Medicacao
{
    public int MedicacaoId { get; set; }
    public int StatusMedicacaoId { get; set; }
    [JsonIgnore]
    public StatusMedicacao StatusMedicacao { get; set; }
    public int TipoMedicacaoId { get; set; }
    [JsonIgnore]
    public TipoMedicacao TipoMedicacao { get; set; }
    public string NomeMedicacao { get; set; }
    public string CompostoAtivoMedicacao { get; set; }
    public string LaboratorioMedicaocao { get; set; }
    public string Generico { get; set; }
    [JsonIgnore]
    public PrescricaoMedicacao PrescricaoMedicacao { get; set; }
}
