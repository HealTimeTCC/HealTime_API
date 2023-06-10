using WEB_API_HealTime.Dto.GlobalEnums;
using WEB_API_HealTime.Dto.MedicacaoDto;
using WEB_API_HealTime.Dto.Paciente;
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
    Task<List<PrescricaoMedicacao>> ListarPrescricaoMedicacoes(int codPrescricao,bool cancel = false);
    Task<List<PrescricaoPaciente>> ListarPrescricaoPacientes(int codPaciente);
    Task<StatusCodeEnum> CancelarPrescricaoPaciente(PrescricaoPaciente prescricaoCancela);
    Task<StatusCodeEnum> CancelaItemMedicacaoPrescricao(int codPrescricao, int codMedicacao);
    Task<PrescricaoMedicacao> ConsultaItemMedicaoPrescricao(int codPrescricao, int codMedicacao);
    Task<List<Medicacao>> ListarMedicacoes(int codPessoa);
    Task<List<TipoMedicacao>> ListarTipoMedicacao();
    Task<bool> ExecuteProcedureDefineHorario(GerarHorarioDto horario);
    Task<bool> HorariosDefinidos(int codPrescricaoMedicamento);
    Task<List<AndamentoMedicacao>> ListarAndamentoMedicacao(int codMedicacao, int codPrescricaoPaciente);

    //Task<StatusCodeEnum> EncerrarAndamentoMedicacao(int codAndamentoMedicacao, int codAplicador);
    Task<StatusCodeEnum> BaixaMedicacao(BaixaAndamentoMedicacaoDto baixa);
}
