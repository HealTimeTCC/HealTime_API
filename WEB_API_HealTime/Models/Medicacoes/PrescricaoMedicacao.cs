using System.Text.Json.Serialization;

namespace WEB_API_HealTime.Models.Medicacoes;

public class PrescricaoMedicacao
{
    public int PrescricaoPacienteId { get; set; }
    [JsonIgnore]
    public PrescricaoPaciente PrescricaoPaciente { get; set; }
    public int MedicacaoId { get; set; }
    [JsonIgnore]
    public Medicacao Medicacao { get; set; }
    public int Qtde { get; set; }//perguntar como fica os liquidos
    public int Intervalo { get; set; }
    public int Duracao { get; set; }//Por interpretamos como duracao de dias
}
