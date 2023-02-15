
using System.Text.Json.Serialization;

namespace WEB_API_HealTime.Models;

public class PrescricaoMedicamento
{
    public int PrescricaoMedicamentoId { get; set; }
    public int? PrescricaoPacienteId { get; set; }
    [JsonIgnore]
    public PrescricaoPaciente PrescricaoPaciente { get; set; }
<<<<<<< HEAD
    public string NomeMedicamento { get; set; }
    public DateTime? HrInicioDtMedicacao { get; set; }
=======
    public DateTime? HrDtMedicacao { get; set; }
>>>>>>> ELABORACAO_CONTROLLERS
    public DateTime? DtTerminoTratamento { get; set; }
    public int? IntervaloMedicacao { get; set; } 
    public int? QtdDiariaMedia { get; set; }
    public bool? CheckSituacao { get; set; }
    public int MedicacaoId { get; set; }
    [JsonIgnore]
    public Medicacao Medicacao { get; set; }
    public ICollection<AndamentoMedicacao> AndamentoMedicacoes { get; set; }
}
