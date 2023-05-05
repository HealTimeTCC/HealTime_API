using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Resources;
using WEB_API_HealTime.Data;
using WEB_API_HealTime.Dto.AgendaConsulta;
using WEB_API_HealTime.Dto.ConsultaMedica;
using WEB_API_HealTime.Dto.ConsultaMedica.Enums;
using WEB_API_HealTime.Models.ConsultasMedicas;
using WEB_API_HealTime.Repository.Interfaces;

namespace WEB_API_HealTime.Repository;

public class ConsultaMedicaRepository : IConsultaMedicaRepository
{
    private readonly DataContext _context;
    public ConsultaMedicaRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<EnumAtualizaStatus> AtualizaSituacaoConsultaAgendada(AtualizaStatusConsultaDto atualiza)
    {
        try
        {
            ConsultaAgendada atualizaConsulta = await _context.ConsultasAgendadas
                .FirstOrDefaultAsync(c => c.PacienteId == atualiza.PacienteId && c.ConsultasAgendadasId == atualiza.ConsultaId);
            if (atualizaConsulta is null)
                return EnumAtualizaStatus.NotFound;
            else if (atualizaConsulta.StatusConsultaId == atualiza.StatusConsultaId)
                return EnumAtualizaStatus.NotUpdate;
            if (atualiza.StatusConsultaId == 2)
            {

                atualizaConsulta.StatusConsultaId = 2;
                var attach = _context.ConsultasAgendadas.Attach(atualizaConsulta);
                attach.Property(canc => canc.ConsultasAgendadasId).IsModified = false;
                attach.Property(canc => canc.StatusConsultaId).IsModified = true;
                attach.Property(canc => canc.PacienteId).IsModified = false;
                ConsultaCancelada cancelada = new()
                {
                    ConsultaAgendadaId = atualiza.ConsultaId,
                    DataCancelamento = DateTime.Now,
                    MotivoCancelamento = atualiza.MotivoAlteracao
                };
                await _context.ConsultaCanceladas.AddAsync(cancelada);
                await _context.SaveChangesAsync();
                return EnumAtualizaStatus.Close;
            }
            else
            {
                atualizaConsulta.StatusConsultaId = atualiza.StatusConsultaId;
                var attach = _context.ConsultasAgendadas.Attach(atualizaConsulta);
                attach.Property(up => up.ConsultasAgendadasId).IsModified = false;
                attach.Property(up => up.StatusConsultaId).IsModified = true;
                attach.Property(up => up.PacienteId).IsModified = false;
                await _context.SaveChangesAsync();
                return EnumAtualizaStatus.Update;
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<List<Especialidade>> BuscarEspecialidades()
    {
        return await _context.Especialidades.ToListAsync();
    }

    public async Task<ConsultaAgendada> ConsultaAgendadaByCodConsultaCodPessoa(int idpessoa, int idconsulta)
    {
        try
        {
            ConsultaAgendada consulta = await _context.ConsultasAgendadas.FirstOrDefaultAsync(x => x.ConsultasAgendadasId == idconsulta && x.PacienteId == idpessoa);
            return consulta;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<Especialidade> EspecialidadeByCod(int codEspecialidade)
    {
        try
        {
            return await _context.Especialidades.FirstOrDefaultAsync(x =>x.EspecialidadeId == codEspecialidade); 
        }
        catch (Exception){ throw; }
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

    public async Task<int> IncluiMedico(IncluiMedicoDto medico, string uf)
    {
        Medico saveMedico = new()
        {
            CrmMedico = medico.CrmMedico,
            NmMedico = medico.NmMedico,
            UfCrmMedico = uf,
        };

        await _context.Set<Medico>().AddAsync(saveMedico);
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

    public async Task<Medico> VerificaMedico(string crmMedico = "", string ufCrmMedico = "", int codMedico = 0)
    {
        if(codMedico == 0)
        {
            return await _context.Medicos
            .FirstOrDefaultAsync(crm => crm.CrmMedico == crmMedico
            && crm.UfCrmMedico.ToUpper().Trim() == ufCrmMedico.ToUpper().Trim());
        }
        else
        {
            return await _context.Medicos
            .FirstOrDefaultAsync(crm => crm.MedicoId == codMedico);
        }
        
    }

    public async Task<StatusConsulta> VerificaStatusConsulta(int statusId)
    {
        return await _context.StatusConsultas.FirstOrDefaultAsync(st => st.StatusConsultaId == statusId) as StatusConsulta;
    }


}
