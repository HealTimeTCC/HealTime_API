using Healtime.Application.Dto.MedicacaoDto;
using Healtime.Application.Dto.Paciente;
using Healtime.Application.Interfaces;
using Healtime.Domain.Entities.ConsultasMedicas;
using Healtime.Domain.Entities.Medicacoes;
using Healtime.Domain.Entities.Medicacoes.Enums;
using Healtime.Domain.Enums;
using Healtime.Infra.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Healtime.Application.Services;
public class MedicacaoRepository : IMedicacaoRepository
{
    private readonly DataContext _context;
    public MedicacaoRepository(DataContext context) { _context = context; }
    public async Task<StatusCodeEnum> CancelaPrescricaoMedicacao(int codPaciente)
    {
        try
        {
            List<PrescricaoMedicacao> listOff = await ListarPrescricaoMedicacoes(codPaciente, cancel: true);
            if (listOff.Count == 0) return StatusCodeEnum.NotFound;
            listOff.ForEach(x => x.StatusMedicacaoFlag = false);
            _context.UpdateRange(listOff);
            await _context.SaveChangesAsync();
            return StatusCodeEnum.Success;
        }
        catch (Exception)
        {
            return StatusCodeEnum.BadRequest;
        }
    }
    public async Task<List<PrescricaoPaciente>> ListarPrescricaoPacientes(int codPaciente)
    {
        try
        {
            return await _context.PrescricaoPacientes
                .Where(x => x.PacienteId == codPaciente).ToListAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }
    public async Task<List<PrescricaoPaciente>> ListPrescricaoByCod(int cod, bool pacienteId = false)
    {
        try
        {
            switch (pacienteId)
            {
                case true:
                    return await _context.PrescricaoPacientes
                .Include(p => p.PrescricoesMedicacoes)
                .ThenInclude(p => p.Medicacao)
                .Where(x => x.PacienteId == cod).ToListAsync();
                case false:
                    return await _context.PrescricaoPacientes
                .Include(p => p.PrescricoesMedicacoes)
                .ThenInclude(p => p.Medicacao)
                .Where(x => x.PrescricaoPacienteId == cod).ToListAsync();
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    public async Task<bool> IncluiMedicacao(List<Medicacao> medicacaos)
    {
        try
        {
            if (medicacaos.Count == 0)
                return false;

            if (await _context.Pessoas.FirstOrDefaultAsync(x => x.PessoaId == medicacaos[0].CodPessoaAlter && x.TipoPessoa != EnumTipoPessoa.PacienteIncapaz) is null)
                return false;

            await _context.Medicacoes.AddRangeAsync(medicacaos);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public async Task<bool> IncluiPrescricaoMedicacao(List<PrescricaoMedicacao> listPrescricaoMedicacaos)
    {
        try
        {
            await _context.PrescricoesMedicacoes
                .AddRangeAsync(listPrescricaoMedicacaos);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {

            throw;
        }
    }
    public async Task<int> IncluiPrescricaoPaciente(PrescricaoPaciente prescricaoPaciente)
    {
        try
        {
            await _context.PrescricaoPacientes.AddRangeAsync(prescricaoPaciente);
            await _context.SaveChangesAsync();
            return prescricaoPaciente.PrescricaoPacienteId;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public async Task<List<Medico>> ListarMedicos()
    {
        try
        {
            return await _context.Medicos.ToListAsync();//Como não havera muitos medicos esse endpoint pode ir assim mesmo
        }
        catch (Exception)
        {
            throw;
        }
    }
    public async Task<Medicacao> MedicacaoById(int codMedicacao)
    {
        try
        {
            return await _context.Medicacoes.FirstOrDefaultAsync(x => x.MedicacaoId == codMedicacao);
        }
        catch (Exception)
        {
            throw;
        }
    }
    public async Task<bool> MedicacaoExiste(int idMedicacao)
    {
        try
        {
            int id = await _context.Medicacoes
                    .Where(x => x.MedicacaoId == idMedicacao)
                    .Select(x => x.MedicacaoId)
                    .FirstOrDefaultAsync();
            return id != 0;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public async Task<Medico> MedicoByCod(int medicoId)
    {
        try
        {
            return await _context.Medicos.FirstOrDefaultAsync(x => x.MedicoId == medicoId);
        }
        catch (Exception) { throw; }
    }
    public async Task<bool> MedicoExiste(int id)
    {
        try
        {
            string crm = string.Empty;
            crm = await _context.Medicos
                    .Where(x => x.MedicoId == id)
                    .Select(c => c.CrmMedico)
                    .FirstOrDefaultAsync();
            return crm != string.Empty;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public async Task<PrescricaoPaciente> PrescricaoByCod(int codPrescricacao)
    {
        try
        {
            return await _context.PrescricaoPacientes
                    .FirstOrDefaultAsync(can => can.PrescricaoPacienteId == codPrescricacao);
        }
        catch (Exception)
        {
            throw;
        }
    }
    public async Task<StatusCodeEnum> CancelarPrescricaoPaciente(PrescricaoPaciente prescricaoCancela)
    {
        try
        {
            prescricaoCancela.FlagStatusAtivo = false;
            _context.PrescricaoPacientes.Update(prescricaoCancela);
            await _context.SaveChangesAsync();
            return StatusCodeEnum.Success;
        }
        catch (Exception)
        {
            return StatusCodeEnum.BadRequest;
        }
    }
    #region (2 para uma função) -> Cancelar item Prescricao
    public async Task<StatusCodeEnum> CancelaItemMedicacaoPrescricao(int codPrescricao, int codMedicacao)
    {
        try
        {
            var prescricaoMedicacao = await ConsultaItemMedicaoPrescricao(codPrescricao, codMedicacao);
            if (prescricaoMedicacao is null)
                return StatusCodeEnum.NotFound;
            /*Alterando status*/
            prescricaoMedicacao.StatusMedicacaoFlag = false;
            prescricaoMedicacao.Medicacao.StatusMedicacao = EnumStatusMedicacao.INATIVO;

            //salvando e definindo o que foi mudado
            var attachMedicao = _context.Attach(prescricaoMedicacao.Medicacao);
            attachMedicao.Property(med => med.MedicacaoId).IsModified = false;
            attachMedicao.Property(med => med.NomeMedicacao).IsModified = false;
            attachMedicao.Property(med => med.StatusMedicacao).IsModified = true;

            var attachPrescricao = _context.Attach(prescricaoMedicacao);
            attachPrescricao.Property(pre => pre.PrescricaoPacienteId).IsModified = false;
            attachPrescricao.Property(pre => pre.MedicacaoId).IsModified = false;
            attachPrescricao.Property(pre => pre.StatusMedicacaoFlag).IsModified = true;
            int linhasAfetadas = await _context.SaveChangesAsync();
            return StatusCodeEnum.Success;
        }
        catch (Exception)
        {
            return StatusCodeEnum.BadRequest;
        }
    }
    public async Task<PrescricaoMedicacao> ConsultaItemMedicaoPrescricao(int codPrescricao, int codMedicacao)
    {
        try
        {
            return await _context.PrescricoesMedicacoes
            .Include(x => x.Medicacao)
            .FirstOrDefaultAsync(m => m.PrescricaoPacienteId == codPrescricao && m.MedicacaoId == codMedicacao);
        }
        catch (Exception)
        {
            throw;
        }
    }
    #endregion
    public async Task<List<Medicacao>> ListarMedicacoes(int codPessoa)
    {
        try
        {
            return await _context.Medicacoes.Include(x => x.TipoMedicacao).Where(x => x.CodPessoaAlter == codPessoa).ToListAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }
    public async Task<List<TipoMedicacao>> ListarTipoMedicacao()
    {
        return await _context.TiposMedicacoes.ToListAsync();
    }
    public async Task<List<PrescricaoMedicacao>> ListarPrescricaoMedicacoes(int codPrescricao, bool cancel = false)
    {
        try
        {
            if (cancel)
                return await _context.PrescricoesMedicacoes.Where(x => x.PrescricaoPacienteId == codPrescricao).ToListAsync();
            else
                return await _context.PrescricoesMedicacoes
                      .Include(x => x.Medicacao)
                      .ThenInclude(x => x.TipoMedicacao)
                  .Where(x => x.PrescricaoPacienteId == codPrescricao).ToListAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }
    #region Executando procedure de gerador de horarios
    public async Task<bool> ExecuteProcedureDefineHorario(GerarHorarioDto horario)
    {
        //Ordem @PRESCRICAOPACIENTEID INT, @PRESCRICAOMEDICAMENTOID INT, @MEDICAMENTOID 
        try
        {
            PrescricaoMedicacao updatePrescription = await _context
                .PrescricoesMedicacoes
                .FirstOrDefaultAsync(x => x.PrescricaoMedicacaoId == horario.PrescricaoMedicamentoId
                && x.PrescricaoPacienteId == horario.PrescricaoPacienteId);

            if (updatePrescription != null)
            {
                if (!updatePrescription.HorariosDefinidos)
                {
                    int linhasAfetadas = await _context.Database.ExecuteSqlRawAsync("EXEC CALCULA_HORARIO_MEDICACAO @PRESCRICAOPACIENTEID, @PRESCRICAOMEDICAMENTOID, @MEDICAMENTOID ",
                    new SqlParameter("@PRESCRICAOPACIENTEID", horario.PrescricaoPacienteId),
                    new SqlParameter("@PRESCRICAOMEDICAMENTOID", horario.PrescricaoMedicamentoId),
                    new SqlParameter("@MEDICAMENTOID", horario.MedicamentoId)
                    );
                    if (linhasAfetadas > 0)
                    {
                        updatePrescription.HorariosDefinidos = true;
                        var attach = _context.Attach(updatePrescription);
                        attach.Property(u => u.HorariosDefinidos).IsModified = true;
                        await _context.SaveChangesAsync();
                        return true;
                    }
                    else return false;
                }
                else return false;
            }
            else return false;
        }
        catch (Exception)
        {
            throw;
        }
    }
    #endregion
    public async Task<bool> HorariosDefinidos(int codPrescricaoMedicamento)
    {
        try
        {
            return await _context.PrescricoesMedicacoes
                .Where(x => x.PrescricaoMedicacaoId == codPrescricaoMedicamento)
                .Select(x => x.HorariosDefinidos)
                .FirstOrDefaultAsync();
        }
        catch (Exception)
        {

            throw;
        }
    }
    #region Listar TODOS os andamento medicações
    public async Task<List<AndamentoMedicacao>> ListarAndamentoMedicacao(int codMedicacao, int codPrescricaoPaciente)
    {
        try
        {
            return await _context.AndamentoMedicacoes.Where(x => x.PrescricaoPacienteId == codPrescricaoPaciente && x.MedicacaoId == codMedicacao).ToListAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }
    #endregion

    //public async Task<StatusCodeEnum> EncerrarAndamentoMedicacao(int codAndamentoMedicacao, int codAplicador)
    //{
    //    try
    //    {
    //        AndamentoMedicacao baixa = 
    //            await _context.AndamentoMedicacoes
    //            .FirstOrDefaultAsync(x => x.AndamentoMedicacaoId == codAndamentoMedicacao);

    //        if (baixa == null)
    //            return StatusCodeEnum.NotFound;
    //        else if(baixa.BaixaAndamentoMedicacao && baixa.CodAplicadorMedicacao != null)
    //            return StatusCodeEnum.NotContent;
    //        else
    //        {
    //            baixa.CodAplicadorMedicacao = codAplicador;
    //            baixa.MtBaixaMedicacao = DateTime.Now;
    //            baixa.BaixaAndamentoMedicacao = true;

    //            var attach = _context.Attach(baixa);
    //            attach.Property(x => x.CodAplicadorMedicacao).IsModified = true;
    //            attach.Property(x => x.MtBaixaMedicacao).IsModified = true;
    //            attach.Property(x => x.BaixaAndamentoMedicacao).IsModified = true;
    //            await _context.SaveChangesAsync();

    //            return StatusCodeEnum.Success;

    //        }
    //    }
    //    catch (Exception)
    //    {
    //        throw;
    //    }
    //}

    public async Task<StatusCodeEnum> BaixaMedicacao(BaixaAndamentoMedicacaoDto baixa)
    {
        try
        {
            AndamentoMedicacao buscaBaixa =
                await _context.AndamentoMedicacoes
                .FirstOrDefaultAsync(x => x.AndamentoMedicacaoId == baixa.CodAndamentoMedicacao);

            if (baixa == null)
                return StatusCodeEnum.NotFound;
            else if (buscaBaixa.BaixaAndamentoMedicacao && buscaBaixa.CodAplicadorMedicacao != null)
                return StatusCodeEnum.NotContent;
            else
            {
                buscaBaixa.CodAplicadorMedicacao = baixa.CodAplicador;
                buscaBaixa.MtBaixaMedicacao = DateTime.Now;
                buscaBaixa.BaixaAndamentoMedicacao = true;

                var attach = _context.Attach(buscaBaixa);
                attach.Property(x => x.CodAplicadorMedicacao).IsModified = true;
                attach.Property(x => x.MtBaixaMedicacao).IsModified = true;
                attach.Property(x => x.BaixaAndamentoMedicacao).IsModified = true;
                await _context.SaveChangesAsync();

                return StatusCodeEnum.Success;

            }
        }
        catch (Exception)
        {
            throw;
        }
    }
}
