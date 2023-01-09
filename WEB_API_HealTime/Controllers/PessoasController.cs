using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Linq.Expressions;
using WEB_API_HealTime.Data;
using WEB_API_HealTime.Models;

namespace WEB_API_HealTime.Controllers;

[ApiController]
[Route("[controller]")]
public class PessoasController : ControllerBase
{
    private readonly DataContext _context;
    public PessoasController(DataContext context){ _context = context; }

    [HttpPost("Cadastro")]
    public async Task<IActionResult> AddPessoa(Pessoa pessoa)
    {
		try
		{
            Pessoa buscaP = await _context.Pessoas.FirstOrDefaultAsync(x => x.CpfPessoa == pessoa.CpfPessoa);
            if (buscaP != null)
                throw new Exception("Usuario existe");
            //O endereço tera como auto preenchimento será consumida em outra api

            Guid idGuid;
            while (true)
            {
                idGuid = Guid.NewGuid();

                Pessoa pessoaGuid = await _context.Pessoas.FirstOrDefaultAsync(pId => pId.PessoaId == idGuid);

                if (pessoaGuid != null)
                    continue;
                else
                    break;
            }
            pessoa.PessoaId = idGuid;

            await _context.Pessoas.AddAsync(pessoa);
            await _context.SaveChangesAsync();
            return Ok($"{pessoa.NomePessoa} salvo!");
        }
		catch (Exception ex)
		{
            return BadRequest(ex.Message);
		}
    }

    [HttpPost("IncluiInfoPacienteIn")]
    public async Task<IActionResult> IncluiInfoPacienteInAsync(string cpfBusca, string obs)
    {
        try
        {
            if (cpfBusca == null)
                throw new Exception("O CPF é obrigatório");
            
            if (obs == null)
                throw new Exception("O campo Observação não deve estar em branco");
            
            Pessoa buscaInfP = await _context.Pessoas.FirstOrDefaultAsync(p => p.CpfPessoa == cpfBusca);

            if (buscaInfP is null)
                throw new Exception("CPF não cadastrado {Ideia para o front Redirection}");

            if (buscaInfP.ObsPacienteIncapaz is null)
                buscaInfP.ObsPacienteIncapaz = obs;

            buscaInfP.ObsPacienteIncapaz += " - ";
            buscaInfP.ObsPacienteIncapaz += obs;


            _context.Update(buscaInfP);
            await _context.SaveChangesAsync();


            return Ok("");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("AtualizarEndereco")]//Parado 
    public async Task<IActionResult> AtualizarEnderecoAsync(Pessoa enderecoPessoa)
    {
        try
        {
            //Dados obrigatorios -> CPF 
            //Dados que podem ser atualizados -> CEP - RUA - UF - NRO

            Pessoa pBusca = await _context.Pessoas.FirstOrDefaultAsync(x => x.CpfPessoa == enderecoPessoa.CpfPessoa);
            if (pBusca == null)
                throw new Exception("CPF não existe");

            return Ok(enderecoPessoa);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
