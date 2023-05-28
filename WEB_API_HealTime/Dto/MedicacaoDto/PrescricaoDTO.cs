using WEB_API_HealTime.Dto.MedicacaoDto;
using WEB_API_HealTime.Models.ConsultasMedicas;
using WEB_API_HealTime.Models.Medicacoes;

namespace WEB_API_HealTime.Dto.PrescricaoDTO;
public class PrescricaoDTO
{
    public int PrescricaoPacienteId { get; set; }
    public int MedicoId { get; set; }
    public int PacienteId { get; set; }
    public DateTime? CriadoEm { get; set; }
    public DateTime Emissao { get; set; }
    public DateTime Validade { get; set; }
    public string DescFichaPessoa { get; set; }
    public bool? FlagStatusAtivo { get; set; }
    public List<PrescricaoMedicacaoDto> PrescricoesMedicacoesDto { get; set; }
}
