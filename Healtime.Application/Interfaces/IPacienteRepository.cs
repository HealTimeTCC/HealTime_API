using Healtime.Application.Dto.Paciente;
using Healtime.Domain.Entities.Pacientes;
using Healtime.Domain.Entities.Pessoas;
using Healtime.Domain.Enums;

namespace Healtime.Application.Interfaces;

public interface IPacienteRepository
{
    Task<bool> SaveResponsavelPaciente(ResponsavelPaciente responsavelPaciente);
    Task<bool> SaveCuidadorPaciente(CuidadorPaciente cuidadorPaciente);
    Task<bool> IncluirObservacoes(IncluiObservacaoDto observacao);
    Task<bool> ConsultaSituacaoHorarioPrescricao(int prescricaoMedicamentoId);
    Task<List<Pessoa>> ListPacienteByCodResposavelOrCuidador(EnumTipoPessoa enumTipoPessoa, int codResOrCuidador);
    Task<StatusCodeEnum> BaixaAndamentoMedicacao(BaixaHorarioMedicacaoDto medicacao);
    Task<StatusCodeEnum> EncerrarRelacaoCuidadorPaciente(EncerrarCuidadorPacienteDto encerrarCuidadorPaciente);
    Task<UltimaDosagemDto> HoraUltimaDoseAplicada(int codAplicador);
}
