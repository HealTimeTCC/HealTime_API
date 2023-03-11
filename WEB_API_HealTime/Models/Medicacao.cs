namespace WEB_API_HealTime.Models;

public class Medicacao
{
    public int MedicacaoId { get; set; }
    public int StatusMedicacaoId { get; set; }
    public int TipoMedicacaoId { get; set; }
    public string NomeMedicacao { get; set; }
    public string CompostoAtivoMedicacao { get; set; }
    public string LaboratorioMedicaocao { get; set; }
    public string Generico { get; set; }
}
