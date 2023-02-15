using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.PortableExecutable;
using WEB_API_HealTime.Data;
using WEB_API_HealTime.Models;

namespace WEB_API_HealTime.Controllers;

[ApiController]
[Route("[controller]")]
public class EnderecoController : ControllerBase
{
    private readonly DataContext _context;
    public EnderecoController(DataContext context)
    {
        _context = context;
    }

    [HttpPost("Inserir")]
    public async Task<IActionResult> AdicionarEnderecoAsync([FromBody] EnderecoPessoa endereco)
    {
        try
        {
            Pessoa pessoa = await _context.Pessoas.FirstOrDefaultAsync(pe => pe.PessoaId == endereco.PessoaId);

            if (pessoa is null)
                return NotFound("Não foi possível encontrar a pessoa informada.");

            if (!ValidarEndereco(endereco))
                return NotFound("Endereço inválido.");
            
            /*Realizar as demais validações*/
            await _context.EnderecoPessoas.AddAsync(endereco);
            await _context.SaveChangesAsync();

            return Ok("Endereco cadastrado com sucesso!");
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("Atualizar")]
    public async Task<IActionResult> AtualizarEnderecoAsync(EnderecoPessoa enderecoPessoa)
    {
        try
        {
            //Dados que podem ser atualizados -> CEP - RUA - UF - NRO
            Pessoa pBusca = await _context.Pessoas.FirstOrDefaultAsync(x => x.PessoaId == enderecoPessoa.PessoaId);
            if (pBusca == null)
                return NotFound("Pessoa não encontrada.");

            /*Continua....*/

            _context.EnderecoPessoas.Update(enderecoPessoa);
            await _context.SaveChangesAsync();

            return Ok(enderecoPessoa);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    static private bool ValidarEndereco(EnderecoPessoa endereco)
    {
        if (endereco.CepEndereco.Length == 8 && endereco.Endereco.Length >= 10 && endereco.BairroEndereco.Length >= 5 && endereco.CidadeEndereco.Length >= 5)
            return true;
        
        return false;
    }
}
