using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEB_API_HealTime.Data;
using WEB_API_HealTime.Models;
using WEB_API_HealTime.Utility;

namespace WEB_API_HealTime.Controllers;

[ApiController]
[Route("[controller]")]
public class ContatoController : ControllerBase
{
    private readonly DataContext _context;
    public ContatoController(DataContext context)
    {
        _context = context;
    }

    /*Cadastrar o contato da pessoa*/
    [HttpPost("Infomacoes")]
    public async Task<IActionResult> InfomacoesAsync([FromBody] ContatoPessoa ctt)
    {
        VerificarInfoPessoa verificarInfoPessoa = new();
        try
        {
            if (ctt.TelefoneCelularObri != null)
            {
                if (!verificarInfoPessoa.VerificarTelefoneCelular(ctt.TelefoneCelularObri))
                    throw new Exception("Telefone Celular invalido");
                if (ctt.TelefoneCelularOpcional != null && !verificarInfoPessoa.VerificarTelefoneCelular(ctt.TelefoneCelularOpcional))
                {
                    throw new Exception("Telefone Celular invalido");
                }
            }
            else
                throw new Exception("O telefone é obrigatório!");

            if (ctt.TelefoneFixo != null && !verificarInfoPessoa.VerificarTelefoneFixo(ctt.TelefoneFixo))
            {
                throw new Exception("Telefone Fixo Invalido");
            }

            await _context.ContatoPessoas.AddAsync(ctt);
            await _context.SaveChangesAsync();

            return Ok("Cadastrado com sucesso");

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /*Excluir um contato*/
    [HttpDelete("Delete/{idContato:int}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int idContato)
    {
        try
        {
            ContatoPessoa contatoPessoa = await _context.ContatoPessoas.
                                        FirstOrDefaultAsync(contato => contato.ContatoId == idContato);

            if (contatoPessoa is null)
                return NotFound("Não foi possível excluir o contato.");

            _context.ContatoPessoas.Remove(contatoPessoa);
            await _context.SaveChangesAsync();

            return Ok("Contato removido com sucesso!");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /*Exibir informações do contato e a pessoa que está relacionada a ela*/
    [HttpGet("InfomacoesPessoas/{idPessoa:int}")]
    public async Task<IActionResult> InfomacoesPessoasAsync(int idPessoa)
    {
        try
        {
            Pessoa pessoaContatos = await _context.Pessoas
                                    .Include(contato => contato.ContatosPessoas)
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync(pessoa => pessoa.PessoaId == idPessoa);

            if (pessoaContatos is null)
                return NotFound("Pessoa não encontrada.");

            return Ok(pessoaContatos);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
