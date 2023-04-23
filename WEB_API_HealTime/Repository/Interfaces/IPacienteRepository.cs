using WEB_API_HealTime.Dto.Paciente;
using WEB_API_HealTime.Models.Pacientes;

namespace WEB_API_HealTime.Repository.Interfaces;

public interface IPacienteRepository
{
    Task<bool> SaveResponsavelPaciente(ResponsavelPaciente responsavelPaciente);
    Task<bool> SaveCuidadorPaciente(CuidadorPaciente CuidadorPaciente);
    Task<List<ResponsavelPaciente>> ListOfResponsavel(int codigoResponsavel);
    Task<List<CuidadorPaciente>> ListOfCuidador(int codigoCuidador);
    Task<bool> IncluirObservacoes(IncluiObservacaoDto observacao);
    Task<bool> ExecuteProcedureDefineHorario(int prescricaoPacienteId, int prescricaoMedicamentoId, int medicamentoId);
    Task<bool> ConsultaSituacaoHorarioPrescricao(int prescricaoMedicamentoId);
}
