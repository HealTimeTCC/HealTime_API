namespace Healtime.Domain.Entities;

public class ControleEstadoAndamentoMedicacao
{
    public int CodControle { get; set; }
    public DateTime DataContagem { get; set; }
    public int QtdeHorarios { get; set; }
    public int CodPrescricaoMedicamento { get; set; }
}
