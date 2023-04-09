using WEB_API_HealTime.Models.Pacientes;

namespace WEB_API_HealTime.Repository.Interfaces;

public interface IPacienteRepository
{
    Task<bool> SaveResponsavelPaciente(ResponsavelPaciente responsavelPaciente);
    Task<bool> SaveCuidadorPaciente(CuidadorPaciente CuidadorPaciente);
}
