using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEB_API_HealTime.Data;
using WEB_API_HealTime.Models;

namespace WEB_API_HealTime.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EstoqueController : ControllerBase
    {
        private readonly DataContext _context;

        [HttpPost("AddEstoque")]
        public async Task<IActionResult> AddEstoque( Estoque estoque)
        {
            try
            {

                Estoque buscaEstoque = await _context.Estoque.FirstOrDefaultAsync(e => e.Nome == estoque.Nome);

                if (buscaEstoque != null)
                    throw new Exception("Nome de estoque já cadastrado!");
                if (buscaEstoque.Desc == null)
                    throw new Exception("O estoque deve ter alguma descrição");


                await _context.Estoque.AddAsync(estoque);
                await _context.SaveChangesAsync();
                return Ok("Estoque adicionado");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /*[HttpPost]
        public async Task<IActionResult> AddMedEstoque(Medicacao medicao)
        {

        }*/

    }
}
