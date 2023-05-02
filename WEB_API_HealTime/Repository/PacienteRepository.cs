using WEB_API_HealTime.Utility.EnumsGlobal;
using WEB_API_HealTime.Data;
using WEB_API_HealTime.Dto.Paciente;
using WEB_API_HealTime.Models.Pacientes;
using WEB_API_HealTime.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using WEB_API_HealTime.Models.Medicacoes;
using WEB_API_HealTime.Models.Pessoas;
using WEB_API_HealTime.Models.Pessoas.Enums;
using WEB_API_HealTime.Querry.PacienteQuerry;
using Microsoft.Extensions.Options;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WEB_API_HealTime.Repository;

public class PacienteRepository : IPacienteRepository
{
    private readonly DataContext _context;
    public PacienteRepository(DataContext context, IPessoaRepository pessoaRepository)
    {
        _context = context;
    }

    #region Incluir Observações
    public async Task<bool> IncluirObservacoes(IncluiObservacaoDto observacao)
    {
        try
        {
            ObservacaoPaciente obs = new()
            {
                MtObservacao = DateTime.Now,
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
    #endregion
    #region Inclusao de cuidador paciente
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
    #endregion
    #region Inclusao de responsavel paciente
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
    #endregion
    #region Executando procedure de gerador de horarios
    public async Task<bool> ExecuteProcedureDefineHorario(GerarHorarioDto horario)
    {
        //Ordem @PRESCRICAOPACIENTEID INT, @PRESCRICAOMEDICAMENTOID INT, @MEDICAMENTOID 
        try
        {
            await _context.Database.ExecuteSqlRawAsync("EXEC CALCULA_HORARIO_MEDICACAO @PRESCRICAOPACIENTEID, @PRESCRICAOMEDICAMENTOID, @MEDICAMENTOID ",
            new SqlParameter("@PRESCRICAOPACIENTEID", horario.PrescricaoPacienteId),
            new SqlParameter("@PRESCRICAOMEDICAMENTOID", horario.PrescricaoMedicamentoId),
            new SqlParameter("@MEDICAMENTOID", horario.MedicamentoId)
           );
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }
    #endregion
    #region Consulta situação horario -> Verificar pq voce fez isso
    public async Task<bool> ConsultaSituacaoHorarioPrescricao(int prescricaoMedicamentoId)
    {
        try
        {
            bool status = await _context.PrescricoesMedicacoes
                   .Where(x => x.PrescricaoMedicacaoId == prescricaoMedicamentoId)
                   .Select(x => x.HorariosDefinidos)
                   .FirstOrDefaultAsync();
            if (!status)
                return false;
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }
    #endregion
    #region Listar TODOS os andamento medicações
    public async Task<List<AndamentoMedicacao>> ListarAndamentoMedicacao(int codRemedio = 0, int codPrescricaoPaciente = 0)
    {
        try
        {
            return codRemedio == 0 && codPrescricaoPaciente == 0 
                ? await _context.AndamentoMedicacoes.ToListAsync() 
                : await _context.AndamentoMedicacoes.Where(x => x.PrescricaoPacienteId == codPrescricaoPaciente && x.MedicacaoId == codRemedio).ToListAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }
    #endregion
    #region Listar paciente by cod responsavel ou cuidador
    public async Task<List<Pessoa>> ListPacienteByCodResposavelOrCuidador(EnumTipoPessoa enumTipoPessoa, int codResOrCuidador)
    {
        var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        string connectionString = configuration.GetConnectionString("dan");
        List<Pessoa> listPacientes = new List<Pessoa>();
        using (SqlConnection connection = new(connectionString))
        {
            try
            {
                await connection.OpenAsync();
                SqlCommand command = new(QuerryPaciente.SelectPacienteByCodResponsavelCuidador(codResOrCuidador, enumTipoPessoa), connection);
                SqlDataReader reader = await command.ExecuteReaderAsync();
                while (reader.Read())
                {
                    Pessoa paciente = new()
                    {
                        PessoaId = int.Parse(reader["PessoaId"].ToString()),
                        TipoPessoa = (EnumTipoPessoa)int.Parse(reader["TipoPessoa"].ToString()),
                        CpfPessoa = reader["CpfPessoa"].ToString(),
                        NomePessoa = reader["NomePessoa"].ToString(),
                        SobreNomePessoa = reader["SobreNomePessoa"].ToString(),
                        DtNascPessoa = DateTime.Parse(reader["DtNascPessoa"].ToString())
                    };
                    listPacientes.Add(paciente);
                }
                return listPacientes;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                await connection.DisposeAsync();
                await connection.CloseAsync();
            }
        }
    }
    #endregion
}
