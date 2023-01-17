using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Data.Entity;
using System.Linq.Expressions;
using WEB_API_HealTime.Data;
using WEB_API_HealTime.Models;
using WEB_API_HealTime.Utility;

namespace WEB_API_HealTime.Controllers;

[ApiController]
[Route("[controller]")]
public class PessoasController : ControllerBase
{
    private readonly DataContext _context;
    public PessoasController(DataContext context){ _context = context; }

    [HttpPost("Cadastro")]
    public async Task<IActionResult> CadastroAsync(Pessoa pessoa)
    {
		try
		{
            VerificarInfoPessoa verificarInfoPessoa = new VerificarInfoPessoa();

            Pessoa buscaP = await _context.Pessoas.FirstOrDefaultAsync(x => x.CpfPessoa == pessoa.CpfPessoa);
            if (buscaP != null)
                throw new Exception("Cpf já cadastrado.");
            //O endereço tera como auto preenchimento será consumida em outra api

            if (!verificarInfoPessoa.VerificadorCpfPessoa(pessoa.CpfPessoa))
                throw new Exception($"Cpf '{pessoa.CpfPessoa}' está inválido.");
            if(!verificarInfoPessoa.VerificarNomePessoa(pessoa.NomePessoa, pessoa.SobrenomePessoa))
                throw new Exception($"O nome está inválido.");
            if(!verificarInfoPessoa.VerificarDtNascimentoPessoa(pessoa.DtNascimentoPesssoa, pessoa.TipoPessoa))
                throw new Exception($"Data de nascimento está inválido.");

            Guid idGuid;
            while (true)
            {
                idGuid = Guid.NewGuid();

                Pessoa pessoaGuid = await _context.Pessoas.FirstOrDefaultAsync(pId => pId.ToString() == idGuid.ToString());

                if (pessoaGuid != null)
                    continue;
                else
                    break;
            }
            pessoa.PessoaId = idGuid.ToString();

            //Uso de variavel Global para criação de contato
          
            await _context.Pessoas.AddAsync(pessoa);
            await _context.SaveChangesAsync();
            return Ok($"{pessoa.NomePessoa} salvo!");
        }
		catch (Exception ex)
		{
            return BadRequest(ex.Message);
		}
    }

    [HttpPost("InfoContato")]
    public async Task<IActionResult> InfoContatoAsync(ContatoPessoa ctt)
    {
        VerificarInfoPessoa verificarInfoPessoa = new();
        try
        {
            List<ContatoPessoa> maxCtt = await _context
                .ContatoPessoas
                .Where(x => x.PessoaId == x.PessoaId)
                .ToListAsync();
            if (ctt.TelefoneCelular is null)
                throw new Exception("O numero de telefone é obrigatório");
            if (!verificarInfoPessoa.VerificarTelefoneCelular(ctt.TelefoneCelular))
                new Exception("Telefone Celular invalido");
            if (ctt.TelefoneFixo != null)
            {
                if (!verificarInfoPessoa.VerificarTelefoneFixo(ctt.TelefoneFixo))
                    throw new Exception("Telefone Fixo Invalido");
            }
            return Ok("Cadastrado com sucesso");

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }            
    }
    
    [HttpPost("IncluiInfoPacienteIn")]//Cria model so para molde do Pa In?
    public async Task<IActionResult> IncluiInfoPacienteIn(string cpfBusca, string obs)
    {
        try
        {
            if (cpfBusca is null)
                throw new Exception("O CPF é obrigatório");
            
            if (obs is null)
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