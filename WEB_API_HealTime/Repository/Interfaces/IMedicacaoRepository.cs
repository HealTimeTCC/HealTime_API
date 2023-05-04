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
    Task<bool> IncluiMedicacao(List<Medicacao> medicacaos);
    Task<List<PrescricaoPaciente>> ListPrescricaoByCod(int cod, bool pacienteId = false);
    Task<Medicacao> MedicacaoById(int codMedicacao);
    Task<PrescricaoPaciente> PrescricaoByCod(int codPrescricacao);
    Task<StatusCodeEnum> CancelaPrescricaoMedicacao(int pacienteId);
    Task<List<PrescricaoMedicacao>> ListarPrescricaoMedicacoes(int codPessoa);
    Task<StatusCodeEnum> CancelarPrescricaoPaciente(PrescricaoPaciente prescricaoCancela);
    Task<StatusCodeEnum> CancelaItemMedicacaoPrescricao(int codPrescricao, int codMedicacao);
    Task<PrescricaoMedicacao> ConsultaItemMedicaoPrescricao(int codPrescricao, int codMedicacao);
}
