using WEB_API_HealTime.Models;

namespace WEB_API_HealTime.Dto;

public class DtoPrescricaoPaciente
{
    public int MedicoId { get; set; }
    public int PacienteId { get; set; }
    public DateTime CriadoEm { get; set; }
    public DateTime Emissao { get; set; }
    public DateTime Validade { get; set; }
    public string DescFichaPessoa { get; set; }
}
