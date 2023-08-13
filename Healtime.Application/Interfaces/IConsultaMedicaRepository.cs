using Healtime.Application.Dto.AgendaConsulta;
using Healtime.Application.Dto.ConsultaMedica;
using Healtime.Domain.Entities.ConsultasMedicas;
using Healtime.Domain.Enums;

namespace Healtime.Application.Interfaces;

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
    Task<StatusCodeEnum> AtualizaSituacaoConsultaAgendada(AtualizaStatusConsultaDto atualiza);
    Task<Especialidade> EspecialidadeByCod(int codEspecialidade);
}
