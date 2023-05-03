using Microsoft.EntityFrameworkCore;
using WEB_API_HealTime.Data;
using WEB_API_HealTime.Dto.GlobalEnums;
using WEB_API_HealTime.Dto.Pessoa;
using WEB_API_HealTime.Models.Pessoas;
using WEB_API_HealTime.Repository.Interfaces;
using WEB_API_HealTime.Utility.EnumsGlobal;

namespace WEB_API_HealTime.Repository;

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

        switch (tipoConsultaPessoa)
        {
            case TipoConsultaPessoa.email:
                return await _context.Pessoas
                .Include(c => c.ContatoPessoa)
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.ContatoPessoa.Email.ToUpper() == emailConsulta.ToUpper());
            case TipoConsultaPessoa.pessoaId:
                return await _context.Pessoas
                .Include(c => c.ContatoPessoa)
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.PessoaId == int.Parse(idPessoa));
            case TipoConsultaPessoa.cpf:
                return await _context.Pessoas
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.CpfPessoa == cpfConsulta);
            case TipoConsultaPessoa.cpfEIdPessoa:
                return await _context.Pessoas
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.CpfPessoa == cpfConsulta && e.PessoaId == int.Parse(idPessoa));
            default:
                return null;//nesse ele não chega
        }

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

    public async Task<string> IncluiPessoa(Pessoa pessoa, ContatoPessoa contatoPessoa = null)
    {
        if (contatoPessoa is null)
        {
            await _context.Pessoas.AddAsync(pessoa);
            await _context.SaveChangesAsync();
            return pessoa.NomePessoa;
        }
        else
        { 
            await _context.Pessoas.AddAsync(pessoa);
            await _context.SaveChangesAsync();
            contatoPessoa.PessoaId = pessoa.PessoaId;
            await _context.ContatoPessoas.AddAsync(contatoPessoa);
            await _context.SaveChangesAsync();
            return pessoa.NomePessoa;
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
