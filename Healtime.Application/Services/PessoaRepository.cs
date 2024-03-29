﻿using Healtime.Application.Dto.Pessoa;
using Healtime.Application.Interfaces;
using Healtime.Domain.Entities.Pessoas;
using Healtime.Domain.Enums;
using Healtime.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Healtime.Application.Services;
public class PessoaRepository : IPessoaRepository
{
    private DataContext _context;
    public PessoaRepository(DataContext context) { _context = context; }//Esquecer public na hora de criar o construtor para DI, dá pau

    public async Task<Pessoa> AutenticarPessoas(string email)
    {
        return await _context.Pessoas
            .Include(ctt => ctt.ContatoPessoa)
            .FirstOrDefaultAsync(p => p.ContatoPessoa.Email.ToUpper() == email.ToUpper());
    }

    public async Task<Pessoa> ConsultarPessoa(TipoConsultaPessoa tipoConsultaPessoa, string cpfConsulta = "", string emailConsulta = "", string idPessoa = "")
    {
        return tipoConsultaPessoa switch
        {
            TipoConsultaPessoa.email => await _context.Pessoas
                            .Include(c => c.ContatoPessoa)
                            .AsNoTracking()
                            .FirstOrDefaultAsync(e => e.ContatoPessoa.Email.ToUpper() == emailConsulta.ToUpper()),
            TipoConsultaPessoa.pessoaId => await _context.Pessoas
                            .Include(c => c.ContatoPessoa)
                            .AsNoTracking()
                            .FirstOrDefaultAsync(e => e.PessoaId == int.Parse(idPessoa)),
            TipoConsultaPessoa.cpf => await _context.Pessoas
                            .AsNoTracking()
                            .FirstOrDefaultAsync(e => e.CpfPessoa == cpfConsulta),
            TipoConsultaPessoa.cpfEIdPessoa => await _context.Pessoas
                            .AsNoTracking()
                            .FirstOrDefaultAsync(e => e.CpfPessoa == cpfConsulta && e.PessoaId == int.Parse(idPessoa)),
            _ => null,//nesse ele não chega
        };
    }

    public async Task<StatusCodeEnum> IncluiFoto(IncluiFotoPessoaDto incluiFoto)
    {
        try
        {
            Pessoa pessoa = await ConsultarPessoa(TipoConsultaPessoa.pessoaId, idPessoa: incluiFoto.PessoaId.ToString());

            if (pessoa == null) return StatusCodeEnum.NotFound;

            pessoa.FotoUsuario = incluiFoto.FotoPessoa;
            var attach = _context.Attach(pessoa);
            attach.Property(x =>x.FotoUsuario).IsModified= true;
            attach.Property(x =>x.PessoaId).IsModified= false;
            await _context.SaveChangesAsync();
            return StatusCodeEnum.Success;
        }
        catch (Exception)
        {
            return StatusCodeEnum.BadRequest;
        }
    }

    public async Task<Pessoa> IncluiPessoa(Pessoa pessoa, ContatoPessoa contatoPessoa = null)
    {
        if (contatoPessoa is null)
        {
            await _context.Pessoas.AddAsync(pessoa);
            await _context.SaveChangesAsync();
            return pessoa;
        }
        else
        { 
            await _context.Pessoas.AddAsync(pessoa);
            await _context.SaveChangesAsync();
            contatoPessoa.PessoaId = pessoa.PessoaId;
            await _context.ContatoPessoas.AddAsync(contatoPessoa);
            await _context.SaveChangesAsync();
            return pessoa;
        }
    }

    public async Task<bool> RegistrarNovoEndereco(EnderecoPessoa enderecoPessoa)
    {
        await _context.EnderecoPessoas.AddAsync(enderecoPessoa);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdatePessoa(Pessoa pessoa, TipoUpdatePessoa tipoUpdatePessoa)
    {
        //Por enquanto tem so esse, mas tem que atualizar dps
        var attach = _context.Pessoas.Attach(pessoa);
        attach.Property(e => e.PasswordHash).IsModified = true;
        attach.Property(e => e.PasswordSalt).IsModified = true;
        await _context.SaveChangesAsync();
        return true;
    }
}
