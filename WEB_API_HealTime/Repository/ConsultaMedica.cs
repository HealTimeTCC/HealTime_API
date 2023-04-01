using Microsoft.EntityFrameworkCore;
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
    public async Task<int> IncluiMedico(Medico medico)
    {
        await _context.Set<Medico>().AddAsync(medico);
        int linhas =   await _context.SaveChangesAsync();
        return linhas;
    }

    public async Task<List<ConsultaAgendada>> ListAgendamentosPacientes(ListConsultasDTO listConsultasDTO)
    {
        return await _context
            .Set<ConsultaAgendada>()
            .AsNoTracking()
            .Where(x => x.PacienteId == listConsultasDTO.PacienteId
            && x.StatusConsultaId == listConsultasDTO.StatusConsultaId).ToListAsync();
    }

    public async Task<Medico> VerificaMedico(string crmMedico, string ufCrmMedico)
    {
        Medico medico = await _context.Medicos
            .FirstOrDefaultAsync(crm => crm.CrmMedico == crmMedico
            && crm.UfCrmMedico.ToUpper().Trim() == ufCrmMedico.ToUpper().Trim());
        return medico;
    }
}
