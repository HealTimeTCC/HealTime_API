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

    [HttpGet("StatusMedicacao")]
    public async Task<IActionResult> StatusMedicacao()
    {
        return Ok(await _context.StatusMedicacoes.ToListAsync());
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
}