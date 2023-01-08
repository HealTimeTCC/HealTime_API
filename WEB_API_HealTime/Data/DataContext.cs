using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using WEB_API_HealTime.Models;

namespace WEB_API_HealTime.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    public DbSet<Pessoa> Pessoas { get; set; }
    //Colocar valor default dps
    public DbSet<ContatoPessoa> ContatoPessoas { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        /*modelBuilder.Entity<ContatoPessoa>().HasData(
            new ContatoPessoa()
            {
                ContatoId = 1,
                EmailContato = "marzogildan@gmail.com",
                PessoaId = "4c6f9a05-f3ee-447f-be11-21e00ad0177e"

            });*/
    }



}
