using Microsoft.AspNetCore.CookiePolicy;
using WEB_API_HealTime.Models.Medicacoes.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WEB_API_HealTime.Data;
using WEB_API_HealTime.Dto;
using WEB_API_HealTime.Dto.PrescricaoDTO;
using WEB_API_HealTime.Models.ConsultasMedicas;
using WEB_API_HealTime.Models.Medicacoes;

namespace WEB_API_HealTime.Controllers;

[Route("[controller]")]
[ApiController]
public class MedicacoesController : ControllerBase
{
    private readonly DataContext _context;
    public MedicacoesController(DataContext context) { _context = context; }
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _context.Medicos.ToListAsync());
    }
    
    [HttpPost("IncluiPrescricao")]
    public async Task<IActionResult> IncluiPrescricaoAsync([FromBody] PrescricaoDTO prescricaoDTO)
    {
        try
        {
            if (prescricaoDTO is null)
                throw new Exception("Objeto nulo");

            //Using para guardar dados da PRESCRIÇÃO DO PACIENTE

            Medico medico = prescricaoDTO.Medico is null ?
            throw new Exception("Objeto nulo")
            : await _context.Medicos
            .FirstOrDefaultAsync(x => x.MedicoId == prescricaoDTO.PrescricaoPaciente.MedicoId);

            prescricaoDTO.PrescricaoPaciente.CriadoEm = DateTime.Now;

            using (_context.PrescricaoPacientes.AddRangeAsync(prescricaoDTO.PrescricaoPaciente))
            {
                await _context.SaveChangesAsync();
            }
            if (prescricaoDTO.Medicamentos.Count < 1)
                throw new Exception("É necessario no minimo 1 medicamento");

            await _context.AddRangeAsync(prescricaoDTO.Medicamentos);
            await _context.SaveChangesAsync();

            int indice = 0;
            while (indice < prescricaoDTO.Medicamentos.Count)
            {
                if (prescricaoDTO.PrescricoesMedicacoes[indice].Intervalo < 1 || prescricaoDTO.PrescricoesMedicacoes[indice].Intervalo > 24)
                    return BadRequest("O intervalo das medicações deve estar entre 1h e 24h");
                prescricaoDTO.PrescricoesMedicacoes[indice].PrescricaoPacienteId = prescricaoDTO.PrescricaoPaciente.PrescricaoPacienteId;
                prescricaoDTO.PrescricoesMedicacoes[indice].MedicacaoId = prescricaoDTO.Medicamentos[indice].MedicacaoId;

                indice++;
            }

            await _context.PrescricoesMedicacoes
                .AddRangeAsync(prescricaoDTO.PrescricoesMedicacoes);
            await _context.SaveChangesAsync();

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    /*  RETORNA UMA LISTA, SE SOBRE TEMPO INCLUA FILTROS  */
    /*
     * Tenha a seguinte visao:
     * A pessoa vai selecionar a Prescricao Atraves da lista fornecida de la ela tirará o ID que vai ser cancelado
     * Detalhe, mais para frente ele vai verificar CLAIM
     */
    /*Cancelamento de prescricao e medicamentos*/
    [HttpPatch("CancelaPrescPacienteCompleta/{id:int}")]
    public async Task<IActionResult> CancelaPrescricaoPacienteCompleta(int id)
    {
        try
        {
            var prescricaoCancela = id < 1 ?
                throw new Exception("Não é aceito valor menor que 1 :(")
                : await _context.PrescricaoPacientes
                    .FirstOrDefaultAsync(can => can.PrescricaoPacienteId == id);

            if (prescricaoCancela != null)
            {
                if (prescricaoCancela.FlagStatus == "N")
                    return BadRequest("Prescrição já está Inativa");
                
                    List<PrescricaoMedicacao> listOff = await _context.PrescricoesMedicacoes
                        .Where(fl => fl.PrescricaoPacienteId == prescricaoCancela.PacienteId).ToListAsync();
                    listOff.ForEach(x => x.StatusMedicacaoFlag = "N");
                    _context.UpdateRange(listOff);
                    await _context.SaveChangesAsync();

                prescricaoCancela.FlagStatus = "N";
                _context.PrescricaoPacientes.Update(prescricaoCancela);
                await _context.SaveChangesAsync();
                return Ok(prescricaoCancela);
            }
            return NotFound("Nenhuma prescricao encontrada");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);  
        }
    }
    [HttpPatch("CancelaMedicacao/{idPrescricao}/{idMedicacao}")]
    public async Task<IActionResult> CancelaItemMedicacaoPrescricao(int idPrescricao, int idMedicacao)
    {
        try
        {
            var prescricaoMedicacao = await _context.PrescricoesMedicacoes
                .Include(x => x.Medicacao)
                .FirstOrDefaultAsync(m => m.PrescricaoPacienteId == idPrescricao && m.MedicacaoId == idMedicacao);

            if (prescricaoMedicacao is null)
                return NotFound("O medicamento da prescrição não foi encontrado");

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

            return Ok($"Medicamento {prescricaoMedicacao.Medicacao.NomeMedicacao}");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
        
    /*Consulta de prescricao e medicamentos*/
    [HttpGet("ConsultaPrescricao/{id:int}")]
    public async Task<IActionResult> ConsultaPrescricaoById(int id)
    {
        try
        {
            var prescricaoPacienteById = await _context.PrescricaoPacientes
                .Include(p => p.PrescricoesMedicacoes)
                .ThenInclude(p => p.Medicacao)
                .Where(x => x.PacienteId == id).ToListAsync();
            if (prescricaoPacienteById != null)
            {
                return Ok(prescricaoPacienteById);
            }
            return NotFound("Nada foi encontrado, verifique o ID");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet("ConsultaMedicacaoById/{id:int}")]
    public async Task<IActionResult> ConsultaMedicacaoById(int id)
    {
        try
        {
            Medicacao medicacao = await _context.Medicacoes
                .FirstOrDefaultAsync(m => m.MedicacaoId == id);
            if (medicacao is null)
                return NotFound($"Medicamento com ID {id} não encontrado");
            return Ok(medicacao);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}