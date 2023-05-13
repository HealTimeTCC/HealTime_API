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
using WEB_API_HealTime.Dto.GlobalEnums;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace WEB_API_HealTime.Repository;

public class PacienteRepository : IPacienteRepository
{
    private readonly DataContext _context;
    public PacienteRepository(DataContext context)
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
    #region Listar andamento by cod medicacao (COMENTADO PARA ANALISE)
    //public async Task<List<AndamentoMedicacao>> ListHorarioMedicamentosByCod(BaixaHorarioMedicacaoDto medicacao)
    //{
    //    throw new NotImplementedException();
    //}
    #endregion
    #region Baixa de ANDAMENTO MEDICACAO
    public async Task<StatusCodeEnum> BaixaAndamentoMedicacao(BaixaHorarioMedicacaoDto momentoBaixa)
    {
        try
        {
            AndamentoMedicacao andamentoMedicacao = await _context
            .AndamentoMedicacoes
            .FirstOrDefaultAsync(x => x.AndamentoMedicacaoId == momentoBaixa.AndamentoMedicacaoId
            && x.PrescricaoPacienteId == momentoBaixa.PrescricaoPacienteId
            && x.MedicacaoId == momentoBaixa.MedicamentoId);
            if (andamentoMedicacao != null)
                return StatusCodeEnum.NotFound;
            andamentoMedicacao.MtBaixaMedicacao = DateTime.Now;
            andamentoMedicacao.BaixaAndamentoMedicacao = true;
            var attach = _context.Attach(andamentoMedicacao);
            attach.Property(canc => canc.MedicacaoId).IsModified = false;
            attach.Property(canc => canc.PrescricaoPacienteId).IsModified = false;
            attach.Property(canc => canc.AndamentoMedicacaoId).IsModified = false;
            attach.Property(up => up.MtBaixaMedicacao).IsModified = true;
            attach.Property(up => up.BaixaAndamentoMedicacao).IsModified = true;
            await _context.SaveChangesAsync();
            return StatusCodeEnum.Success;
        }
        catch (Exception)
        {
            return StatusCodeEnum.BadRequest;
        }
    }
    #endregion
    #region Encerrar RelacaoCuidadorPaciente
    public async Task<StatusCodeEnum> EncerrarRelacaoCuidadorPaciente(EncerrarCuidadorPacienteDto encerrarCuidadorPaciente)
    {
        try
        {
            CuidadorPaciente finalizadoCuidador = await _context.CuidadorPacientes
                .FirstOrDefaultAsync(c => c.CuidadorId == encerrarCuidadorPaciente.CuidadorId && c.PacienteId == encerrarCuidadorPaciente.PacienteId);

            if (finalizadoCuidador == null)
                return StatusCodeEnum.NotFound;
            else if (finalizadoCuidador.FinalizadoEm != null)
                return StatusCodeEnum.NotContent;

            finalizadoCuidador.FinalizadoEm = DateTime.Now;
            EntityEntry<CuidadorPaciente> attach = _context.Attach(finalizadoCuidador);
            attach.Property(x => x.FinalizadoEm).IsModified = true;
            attach.Property(x => x.PacienteId).IsModified = false;
            attach.Property(x => x.CuidadorId).IsModified = false;
            await _context.SaveChangesAsync();
            return StatusCodeEnum.Update;
        }
        catch
        {
            return StatusCodeEnum.BadRequest;
        }
    }
    #endregion

    #region 
    public async Task<DateTime?> HoraUltimaDoseAplicada(int codCuidador)
    {
        try
        {
            return null;//_context.AndamentoMedicacoes.
        }
        catch (Exception)
        {
            throw;
        }

    }
    #endregion
}
