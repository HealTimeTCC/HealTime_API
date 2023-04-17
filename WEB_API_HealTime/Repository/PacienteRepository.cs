using WEB_API_HealTime.Utility.EnumsGlobal;
using WEB_API_HealTime.Data;
using WEB_API_HealTime.Dto.Paciente;
using WEB_API_HealTime.Models.Pacientes;
using WEB_API_HealTime.Repository.Interfaces;
using WEB_API_HealTime.Models.Pessoas;
using Microsoft.EntityFrameworkCore;

namespace WEB_API_HealTime.Repository;

public class PacienteRepository : IPacienteRepository
{
    private readonly DataContext _context;
    public PacienteRepository(DataContext context, IPessoaRepository pessoaRepository)
    {
        _context = context;
    }

    public async Task<bool> IncluirObservacoes(IncluiObservacaoDto observacao)
    {
        try
        {
            ObservacaoPaciente obs = new ObservacaoPaciente()
            {
                MtObservacao = observacao.MtObservacao,
                Observacao = observacao.Observacao,
                PacienteId = observacao.PacienteId,
            };

            await _context.ObservacoesPacientes.AddAsync(obs);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {

            throw ex.InnerException;
        }
    }

    public async Task<List<CuidadorPaciente>> ListOfCuidador(int codigoCuidador)
    {
        List<CuidadorPaciente> listSobCuidado = await _context
            .CuidadorPacientes
            .Include(c => c.PessoaCuidador)
            .Where(c => c.CuidadorId == codigoCuidador).ToListAsync();
        return listSobCuidado;
    }

    public async Task<List<ResponsavelPaciente>> ListOfResponsavel(int codigoResponsavel)
    {
        List<ResponsavelPaciente> listSobCuidado = await _context
            .ResponsaveisPacientes
            .Include(c => c.Responsavel)
            .Where(c => c.ResponsavelId == codigoResponsavel).ToListAsync();
        return listSobCuidado;
    }

    public async Task<bool> SaveCuidadorPaciente(CuidadorPaciente CuidadorPaciente)
    {
        try
        {
            await _context.CuidadorPacientes.AddAsync(CuidadorPaciente);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<bool> SaveResponsavelPaciente(ResponsavelPaciente responsavelPaciente)
    {
        try
        {
            await _context.ResponsaveisPacientes.AddAsync(responsavelPaciente);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
