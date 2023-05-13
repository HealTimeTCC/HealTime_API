using WEB_API_HealTime.Models.ConsultasMedicas;
using WEB_API_HealTime.Models.Medicacoes;

namespace WEB_API_HealTime.Dto.PrescricaoDTO;
public class PrescricaoDTO
{
    public PrescricaoPaciente PrescricaoPaciente { get; set; }
    public List<PrescricaoMedicacao> PrescricoesMedicacoes { get; set; }
    public List<int> MedicacoesId { get; set; }
}
