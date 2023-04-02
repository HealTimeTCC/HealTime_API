using Microsoft.EntityFrameworkCore;
using WEB_API_HealTime.Data;
using WEB_API_HealTime.Models.Pessoas;
using WEB_API_HealTime.Repository.Interfaces;

namespace WEB_API_HealTime.Repository;

public class PessoaRepository : IPessoaRepository
{
    private DataContext _context;
    public PessoaRepository(DataContext context){_context = context;}//Esquecer public na hora de criar o construtor para DI, dá pau
    public async Task<string> IncluiPessoa(Pessoa pessoa)
    {
        await _context.Pessoas.AddAsync(pessoa);
        await _context.SaveChangesAsync();
        return pessoa.NomePessoa; 
    }
}
