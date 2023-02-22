using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEB_API_HealTime.Data;
using WEB_API_HealTime.Models;

namespace WEB_API_HealTime.Controllers;

[Route("[controller]")]
[ApiController]
public class MedicamentosController : ControllerBase
{
    private readonly DataContext _context;
    public MedicamentosController(DataContext context){ _context = context;}

    [HttpPost("NovoMedi")]
    public async Task<IActionResult> NovoMedi([FromBody] Medicacao novaMedicacao)
    {
        try
        {
            
            Medicacao medicacao = novaMedicacao.Nome is null ?
                throw new ArgumentNullException("O campo Nome é obrigatório")
                : await _context.Medicacoes.
                FirstOrDefaultAsync(m => m.Nome.ToLower() == novaMedicacao.Nome.ToLower());

            if (medicacao != null) 
            { 
                throw new Exception("Já existe um medicamento com esse nome, tente atualizar o cadastro dele");
            }

            TipoMedicacao tipo = await _context.TipoMedicacoes.FirstOrDefaultAsync(tp => tp.TipoMedicacaoId == novaMedicacao.TipoMedicacaoId);
           
            if (tipo is null) 
            {
                throw new Exception("Verifique a entrada, tipo não registrado");
            }

            if (novaMedicacao.QtdMedicacao is null)
                throw new ArgumentNullException("Informe a quantidade");
            
            Estoque estoqueNovo = new Estoque();
            estoqueNovo.QtdEstoque = novaMedicacao.QtdMedicacao ?? 0;
            estoqueNovo.Desc = novaMedicacao.Desc ?? "";
            estoqueNovo.Nome = novaMedicacao.Nome;
            estoqueNovo.CriadoEm = DateTime.Now;

            await _context.Medicacoes.AddRangeAsync(novaMedicacao);
            await _context.SaveChangesAsync();

            estoqueNovo.MedicacaoId = novaMedicacao.MedicacaoId;
            await _context.AddAsync(estoqueNovo);
            await _context.SaveChangesAsync();

            return Ok(novaMedicacao);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
