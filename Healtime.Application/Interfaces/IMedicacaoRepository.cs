using Healtime.Application.Dto.MedicacaoDto;
using Healtime.Application.Dto.Paciente;
using Healtime.Domain.Entities.ConsultasMedicas;
using Healtime.Domain.Entities.Medicacoes;
using Healtime.Domain.Enums;

namespace Healtime.Application.Interfaces;

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
    Task<List<PrescricaoMedicacao>> ListarPrescricaoMedicacoes(int codPrescricao, bool cancel = false);
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
