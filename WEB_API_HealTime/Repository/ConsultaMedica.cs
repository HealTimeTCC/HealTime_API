using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Resources;
using WEB_API_HealTime.Data;
using WEB_API_HealTime.Dto.AgendaConsulta;
using WEB_API_HealTime.Models.ConsultasMedicas;
using WEB_API_HealTime.Repository.Interfaces;

namespace WEB_API_HealTime.Repository;

public class ConsultaMedica : IConsultaMedica
{
    private readonly DataContext _context;
    public ConsultaMedica(DataContext context)
    {
        _context = context;
    }

    public async Task<List<Especialidade>> BuscarEspecialidades()
    {
        return await _context.Especialidades.ToListAsync();
    }

    public async Task<ConsultaAgendada> IncluiConsulta(ConsultaAgendada consultaAgendada)
    {
        await _context.ConsultasAgendadas.AddAsync(consultaAgendada);
        await _context.SaveChangesAsync();
        return consultaAgendada;
    }

    public async Task<string> IncluiEspecialidade(Especialidade especialidade)
    {
        await _context.Especialidades.AddAsync(especialidade);
        await _context.SaveChangesAsync();
        return especialidade.DescEspecialidade;
    }

    public async Task<int> IncluiMedico(Medico medico)
    {
        await _context.Set<Medico>().AddAsync(medico);
        int linhas = await _context.SaveChangesAsync();
        return linhas;
    }

    public async Task<List<ConsultaAgendada>> ListAgendamentosPacientes(ListConsultasDTO listConsultasDTO)
    {
        if (listConsultasDTO.StatusConsultaId is null || listConsultasDTO.StatusConsultaId == 0)
        {
            return await _context
            .Set<ConsultaAgendada>()
            .AsNoTracking()
            .Where(x => x.PacienteId == listConsultasDTO.PacienteId).ToListAsync();
        }
        else
        {
            return await _context
                .Set<ConsultaAgendada>()
                .AsNoTracking()
                .Where(x => x.PacienteId == listConsultasDTO.PacienteId
                && x.StatusConsultaId == listConsultasDTO.StatusConsultaId).ToListAsync();
        }
    }

    public async Task<Especialidade> VerificaEspecialidade(int especId)
    {
        return await _context.Especialidades.FirstOrDefaultAsync(st => st.EspecialidadeId == especId) as Especialidade;
    }

    public async Task<Medico> VerificaMedico(string crmMedico, string ufCrmMedico)
    {
        return await _context.Medicos
            .FirstOrDefaultAsync(crm => crm.CrmMedico == crmMedico
            && crm.UfCrmMedico.ToUpper().Trim() == ufCrmMedico.ToUpper().Trim()) as Medico;
    }

    public async Task<StatusConsulta> VerificaStatusConsulta(int statusId)
    {
        return await _context.StatusConsultas.FirstOrDefaultAsync(st => st.StatusConsultaId == statusId) as StatusConsulta;
    }
}
