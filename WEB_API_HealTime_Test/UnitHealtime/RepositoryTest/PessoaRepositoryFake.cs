
using Microsoft.EntityFrameworkCore;
using WEB_API_HealTime.Models.Pessoas;
using WEB_API_HealTime.Models.Pessoas.Enums;
using WEB_API_HealTime.Repository.Interfaces;
using WEB_API_HealTime.Utility;
using WEB_API_HealTime.Utility.EnumsGlobal;

namespace WEB_API_HealTime_Test.UnitHealtime.Repository;

public class PessoaRepositoryFake : IPessoaRepository
{
    private readonly List<Pessoa> _pessoa;
    public PessoaRepositoryFake()
    {
        Criptografia.CriarPasswordHash("1q2w3e4r", out byte[] hash, out byte[] salt);
        
        
        _pessoa = new List<Pessoa>()
        {
            new Pessoa()
            {
                PessoaId = 1
                ,NomePessoa = "DanMarzoGil"
                ,SobreNomePessoa = "Gil Gil"
                ,TipoPessoa = EnumTipoPessoa.Responsavel
                ,CpfPessoa = "12345678909"
                ,DtNascPessoa = DateTime.Parse("2004-02-15")
                ,PasswordSalt= salt
                ,PasswordHash= hash
                ,ContatoPessoa = {
                    PessoaId= 1
                    ,Email = "marzogildan@gmail.com"
                    ,CriadoEm = DateTime.Now
                    ,Celular = "11955008212"
                }
            }
            ,new Pessoa()
            {
                PessoaId = 2,
                NomePessoa = "Mayara",
                SobreNomePessoa = "Pillecart",
                TipoPessoa = EnumTipoPessoa.Cuidador,
                CpfPessoa = "09876543221",
                DtNascPessoa = DateTime.Parse("1998-06-11"),
                PasswordSalt= salt,
                PasswordHash= hash
            }
            ,new Pessoa()
            {
                PessoaId = 3,
                NomePessoa = "Nicolly",
                SobreNomePessoa = "Socre",
                TipoPessoa = EnumTipoPessoa.Paciente,
                CpfPessoa = "12345678909",
                DtNascPessoa = DateTime.Parse("2004-02-15"),
                PasswordSalt= salt,
                PasswordHash= hash
            }
            ,new Pessoa()
            {
                PessoaId = 4,
                NomePessoa = "Thiago",
                SobreNomePessoa = "Roque",
                TipoPessoa = EnumTipoPessoa.PacienteIncapaz,
                CpfPessoa = "09876543212",
                DtNascPessoa = DateTime.Parse("2003-06-11"),
                PasswordSalt= salt,
                PasswordHash= hash
            }
        };
    }

    public async Task<Pessoa> AutenticarPessoas(string email)
    {
        return _pessoa.FirstOrDefault(a => a.ContatoPessoa.Email.ToUpper() == email.ToUpper());
    }

    public Task<Pessoa> ConsultarPessoa(TipoConsultaPessoa tipoConsultaPessoa, string cpfConsulta = "", string emailConsulta = "", string idPessoa = "")
    {
        throw new NotImplementedException();
    }

    public Task<string> IncluiPessoa(Pessoa pessoa, ContatoPessoa contatoPessoa = null)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RegistrarNovoEndereco(EnderecoPessoa enderecoPessoa)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdatePessoa(Pessoa pessoa, TipoUpdatePessoa tipoConsultaPessoa)
    {
        throw new NotImplementedException();
    }
}
