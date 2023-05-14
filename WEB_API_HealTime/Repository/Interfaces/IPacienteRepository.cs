using WEB_API_HealTime.Dto.Paciente;
using WEB_API_HealTime.Models.Medicacoes;
using WEB_API_HealTime.Models.Pacientes;
using WEB_API_HealTime.Models.Pessoas.Enums;
using WEB_API_HealTime.Models.Pessoas;
using WEB_API_HealTime.Dto.GlobalEnums;

namespace WEB_API_HealTime.Repository.Interfaces;

public interface IPacienteRepository
{
    Task<bool> SaveResponsavelPaciente(ResponsavelPaciente responsavelPaciente);
    Task<bool> SaveCuidadorPaciente(CuidadorPaciente CuidadorPaciente);
    Task<bool> IncluirObservacoes(IncluiObservacaoDto observacao);
    Task<bool> ExecuteProcedureDefineHorario(GerarHorarioDto horario);
    Task<bool> ConsultaSituacaoHorarioPrescricao(int prescricaoMedicamentoId);
    Task<List<AndamentoMedicacao>> ListarAndamentoMedicacao(int codRemedio = 0, int codPrescricaoPaciente= 0);
    Task<List<Pessoa>> ListPacienteByCodResposavelOrCuidador(EnumTipoPessoa enumTipoPessoa, int codResOrCuidador);
    //Task<List<AndamentoMedicacao>> ListHorarioMedicamentosByCod(BaixaHorarioMedicacaoDto medicacao);
    Task<StatusCodeEnum> BaixaAndamentoMedicacao(BaixaHorarioMedicacaoDto medicacao);
    Task<StatusCodeEnum> EncerrarRelacaoCuidadorPaciente(EncerrarCuidadorPacienteDto encerrarCuidadorPaciente);
    Task<UltimaDosagemDto> HoraUltimaDoseAplicada(int codAplicador);
}
