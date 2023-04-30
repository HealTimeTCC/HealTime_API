using WEB_API_HealTime.Dto.Paciente;
using WEB_API_HealTime.Models.Medicacoes;
using WEB_API_HealTime.Models.Pacientes;
using WEB_API_HealTime.Models.Pessoas.Enums;
using WEB_API_HealTime.Models.Pessoas;

namespace WEB_API_HealTime.Repository.Interfaces;

public interface IPacienteRepository
{
    Task<bool> SaveResponsavelPaciente(ResponsavelPaciente responsavelPaciente);
    Task<bool> SaveCuidadorPaciente(CuidadorPaciente CuidadorPaciente);
    Task<List<ResponsavelPaciente>> ListOfResponsavel(int codigoResponsavel);
    Task<List<CuidadorPaciente>> ListOfCuidador(int codigoCuidador);
    Task<bool> IncluirObservacoes(IncluiObservacaoDto observacao);
    Task<bool> ExecuteProcedureDefineHorario(GerarHorarioDto horario);
    Task<bool> ConsultaSituacaoHorarioPrescricao(int prescricaoMedicamentoId);
    Task<List<AndamentoMedicacao>> ListarAndamentoMedicacao();
    Task<List<Pessoa>> ListPacienteByCodResposavelOrCuidador(EnumTipoPessoa enumTipoPessoa, int codResOrCuidador);

}
