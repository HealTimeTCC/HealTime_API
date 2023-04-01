using WEB_API_HealTime.Dto.AgendaConsulta;
using WEB_API_HealTime.Models.ConsultasMedicas;

namespace WEB_API_HealTime.Repository.Interfaces;

public interface IConsultaMedica
{
    Task<int> IncluiMedico(Medico medico);
    Task<List<ConsultaAgendada>> ListAgendamentosPacientes(ListConsultasDTO listConsultasDTO);
    Task<Medico> VerificaMedico(string crm, string ufCrmMedico);
    Task<StatusConsulta> VerificaStatusConsulta(int statusId);
    Task<Especialidade> VerificaEspecialidade(int especialidadeId);
    Task<ConsultaAgendada> IncluiConsulta(ConsultaAgendada consultaAgendada);
    Task<List<Especialidade>> BuscarEspecialidades();
    Task<string> IncluiEspecialidade(Especialidade especialidade);
}
