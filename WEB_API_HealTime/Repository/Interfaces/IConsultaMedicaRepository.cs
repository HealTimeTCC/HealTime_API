using WEB_API_HealTime.Dto.AgendaConsulta;
using WEB_API_HealTime.Dto.ConsultaMedica;
using WEB_API_HealTime.Dto.ConsultaMedica.Enums;
using WEB_API_HealTime.Models.ConsultasMedicas;

namespace WEB_API_HealTime.Repository.Interfaces;

public interface IConsultaMedicaRepository
{
    Task<int> IncluiMedico(IncluiMedicoDto medico, string uf);
    Task<List<ConsultaAgendada>> ListAgendamentosPacientes(ListConsultasDTO listConsultasDTO);
    Task<Medico> VerificaMedico(string crmMedico = "", string ufCrmMedico = "", int codMedico = 0);
    Task<StatusConsulta> VerificaStatusConsulta(int statusId);
    Task<Especialidade> VerificaEspecialidade(int especialidadeId);
    Task<ConsultaAgendada> IncluiConsulta(ConsultaAgendada consultaAgendada);
    Task<List<Especialidade>> BuscarEspecialidades();
    Task<string> IncluiEspecialidade(Especialidade especialidade);
    Task<ConsultaAgendada> ConsultaAgendadaByCodConsultaCodPessoa(int idpessoa, int idconsulta);
    Task<EnumAtualizaStatus> AtualizaSituacaoConsultaAgendada(AtualizaStatusConsultaDto atualiza);
    Task<Especialidade> EspecialidadeByCod(int codEspecialidade);
}
