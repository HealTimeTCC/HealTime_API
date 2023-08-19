using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Healtime.Application.Interfaces;
using Healtime.Application.Services;
using Healtime.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Healtime.Infra.IoC;
public static class DepedencyInjection
{
    public static IServiceCollection AddDependecyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        #region DbContext
        //string? connection = configuration.GetConnectionString("DANMARZO-01");
        services.AddDbContext<DataContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("dan"));
        });
        #endregion
        #region Container de Injeção de dependencia 
        services.AddTransient<IPessoaRepository, PessoaRepository>();
        services.AddTransient<IConsultaMedicaRepository, ConsultaMedicaRepository>();
        services.AddTransient<IPacienteRepository, PacienteRepository>();
        services.AddTransient<IMedicacaoRepository, MedicacaoRepository>();
        #endregion
        return services;
    }
}
