using WEB_API_HealTime.Utility.EnumsGlobal;
using WEB_API_HealTime.Data;
using WEB_API_HealTime.Dto.Paciente;
using WEB_API_HealTime.Models.Pacientes;
using WEB_API_HealTime.Repository.Interfaces;


namespace WEB_API_HealTime.Repository;

public class PacienteRepository : IPacienteRepository
{
    private readonly DataContext _context;
    public PacienteRepository(DataContext context, IPessoaRepository pessoaRepository)
    {
        _context = context;
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
