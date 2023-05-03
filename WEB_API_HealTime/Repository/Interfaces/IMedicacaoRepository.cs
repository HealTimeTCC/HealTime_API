using WEB_API_HealTime.Dto.GlobalEnums;
using WEB_API_HealTime.Models.ConsultasMedicas;
using WEB_API_HealTime.Models.Medicacoes;

namespace WEB_API_HealTime.Repository.Interfaces;

public interface IMedicacaoRepository
{
    Task<List<Medico>> ListarMedicos();
    Task<bool> MedicoExiste(int id);
    Task<int> IncluiPrescricaoPaciente(PrescricaoPaciente prescricaoPaciente);
    Task<bool> MedicacaoExiste(int id);
    Task<bool> IncluiPrescricaoMedicacao(List<PrescricaoMedicacao> listPrescricaoMedicacaos);
    Task<Medico> MedicoByCod(int medicoId);
}
