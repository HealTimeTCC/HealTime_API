using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Http;
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
                prescricaoDTO.PrescricoesMedicacoes[indice].PrescricaoPacienteId = 
                    prescricaoDTO.PrescricaoPaciente.PrescricaoPacienteId;
                prescricaoDTO.PrescricoesMedicacoes[indice].MedicacaoId = 
                    prescricaoDTO.Medicamentos[indice].MedicacaoId;
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
    [HttpGet("PrescricaoPaciente/{id:int}")]
    public async Task<IActionResult> PrescricaoPacienteById(int id)
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

    /*
     * Tenha a seguinte visao:
     * A pessoa vai selecionar a Prescricao Atraves da lista fornecida de la ela tirará o ID que vai ser cancelado
     * Detalhe, mais para frente ele vai verificar CLAIM
     */

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


}