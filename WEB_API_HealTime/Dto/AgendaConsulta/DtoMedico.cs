using WEB_API_HealTime.Models.ConsultasMedicas;

namespace WEB_API_HealTime.Dto.AgendaConsulta;


public class DtoMedico
{
    public int MedicoId { get; set; }
    public Medico Medico { get; set; }
    public int PacienteId { get; set; }
    public DateTime CriadoEm { get; set; }
    public DateTime Emissao { get; set; }
    public DateTime Validade { get; set; }
    public string DescFichaPessoa { get; set; }
}
