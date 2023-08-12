namespace WEB_API_HealTime.Models;

public class ControleEstadoAndamentoMedicacao
{
    public int CodControle { get; set; }
    public DateTime DataContagem { get; set; }
    public int QtdeHorarios { get; set; }
    public int CodPrescricaoMedicamento { get; set; }
}
