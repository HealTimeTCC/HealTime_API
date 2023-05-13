using Microsoft.EntityFrameworkCore;
using WEB_API_HealTime.Data;
using WEB_API_HealTime.Dto.GlobalEnums;
using WEB_API_HealTime.Dto.IncluiMedicacaoDto;
using WEB_API_HealTime.Models.ConsultasMedicas;
using WEB_API_HealTime.Models.Medicacoes;
using WEB_API_HealTime.Models.Medicacoes.Enums;
using WEB_API_HealTime.Models.Pessoas.Enums;
using WEB_API_HealTime.Repository.Interfaces;

namespace WEB_API_HealTime.Repository;

public class MedicacaoRepository : IMedicacaoRepository
{
    private readonly DataContext _context;
    //private readonly IPessoaRepository _pessoaRepository;

    public MedicacaoRepository(DataContext context/*, IPessoaRepository pessoaRepository*/) { _context = context; /*_pessoaRepository = pessoaRepository;*/ }

    public async Task<StatusCodeEnum> CancelaPrescricaoMedicacao(int codPaciente)
    {
        try
        {
            List<PrescricaoMedicacao> listOff = await ListarPrescricaoMedicacoes(codPaciente);
            if (listOff.Count == 0) return StatusCodeEnum.NotFound;
            listOff.ForEach(x => x.StatusMedicacaoFlag = "N");
            _context.UpdateRange(listOff);
            await _context.SaveChangesAsync();
            return StatusCodeEnum.Success;
        }
        catch (Exception)
        {
            return StatusCodeEnum.BadRequest;
        }
    }
    public async Task<List<PrescricaoMedicacao>> ListarPrescricaoMedicacoes(int codPessoa)
    {
        try
        {
            return await _context.PrescricoesMedicacoes
                .Where(x => x.PrescricaoPacienteId == codPessoa).ToListAsync();
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
            prescricaoCancela.FlagStatus = "N";
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
            prescricaoMedicacao.StatusMedicacaoFlag = "N";
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
}
