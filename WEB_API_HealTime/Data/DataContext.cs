using Microsoft.EntityFrameworkCore;
using WEB_API_HealTime.Models;

namespace WEB_API_HealTime.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    public DbSet<PrescricaoPaciente> PrescricaoPacientes { get; set; }
    public DbSet<Medico> Medicos { get; set; }
    public DbSet<Pessoa> Pessoas { get; set; }
    public DbSet<Medicacao> Medicacoes { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        /* -> BEGIN PRESCRICAOPACIENTES */
        modelBuilder.Entity<PrescricaoPaciente>()
            .HasKey(pk => pk.PrescricaoPacienteId)
            .HasName("PK_PrescricaoPacienteId");
            /* -> BEGIN: Esses dois abaixo são relacionamento <- */
        modelBuilder.Entity<PrescricaoPaciente>()
            .Property(p => p.MedicoId);
        modelBuilder.Entity<PrescricaoPaciente>()
            .HasOne<Medico>(one => one.Medico)
            .WithOne(one => one.PrescricaoPaciente)
                .HasForeignKey<PrescricaoPaciente>(f => f.MedicoId)
                .HasConstraintName("FK_PrescricaoPaciente_Medico");
        modelBuilder.Entity<PrescricaoPaciente>()
            .Property(p => p.PacienteId);
            /* -> END <- */
        modelBuilder.Entity<PrescricaoPaciente>()
            .Property(dt => dt.CriadoEm)
            .HasColumnType("DATETIME")
            .IsRequired();
        modelBuilder.Entity<PrescricaoPaciente>()
            .Property(dt => dt.Emissao)
            .HasColumnType("DATETIME")
            .IsRequired(); 
        modelBuilder.Entity<PrescricaoPaciente>()
            .Property(dt => dt.Validade)
            .HasColumnType("DATETIME")
            .IsRequired();
        modelBuilder.Entity<PrescricaoPaciente>()
            .Property(desc => desc.DescFichaPessoa)
            .HasColumnType("VARCHAR(350)");
        /* -> END  PRESCRICAOPACIENTES */

        /* -> BEGIN MEDICO */
        modelBuilder.Entity<Medico>()
            .HasKey(pk => pk.MedicoId)
            .HasName("PK_MedicoId");
        modelBuilder.Entity<Medico>()
            .Property(nm => nm.NmMedico)
            .HasColumnType("VARCHAR(40)")
            .IsRequired();
        modelBuilder.Entity<Medico>()
            .Property(crm => crm.CrmMedico)
            .HasColumnType("INT");
        modelBuilder.Entity<Medico>()
            .Property(crmuf => crmuf.UfCrmMedico)
            .HasColumnType("CHAR(2)")
            .IsRequired();


        /* -> END MEDICO */
        modelBuilder.Entity<Medico>().HasData(
            new Medico
            {
                MedicoId=1,
                CrmMedico=12345,
                NmMedico="Dr Val",
                UfCrmMedico="SP"
            },
            new Medico
            {
                MedicoId=2,
                CrmMedico=12345,
                NmMedico="Dr Teste",
                UfCrmMedico="RJ"
            });

        /* -> BEGIN PESSOAS */

        modelBuilder.Entity<Pessoa>()
            .HasKey(pk => pk.PessoaId)
            .HasName("PK_PessoaId");
        modelBuilder.Entity<Pessoa>()
            .Property(tp => tp.TipoPessoaId)
            .HasColumnType("INT")
            .IsRequired();
        modelBuilder.Entity<Pessoa>()
            .Property(cpf => cpf.CpfPessoa)
            .HasColumnType("CHAR(11)")
            .IsRequired();
        modelBuilder.Entity<Pessoa>()
            .Property(nm => nm.NomePessoa)
            .HasColumnType("VARCHAR(25)")
            .IsRequired();
        modelBuilder.Entity<Pessoa>()
            .Property(sm => sm.SobreNomePessoa)
            .HasColumnType("VARCHAR(30)")
            .IsRequired();
        modelBuilder.Entity<Pessoa>()
            .Property(dt =>dt.DtNascPessoa)
            .HasColumnType("DATE")
            .IsRequired();
        /* -> END PESSOAS */

        /* -> BEGIN MEDICAMENTOS */

        modelBuilder.Entity<Medicacao>()
            .HasKey(pk => pk.MedicacaoId)
            .HasName("PK_MedicacaoId");
        //modelBuilder.Entity<Medicacao>()
        //    .HasOne(st => st.StatusMedicacaoId)
        //    .WithMany()
        //modelBuilder.Entity<Medicacao>()
        //    .HasOne(st => st.TipoMedicacaoId)
        //    .WithMany()
        modelBuilder.Entity<Medicacao>()
            .Property(nm => nm.NomeMedicacao)
            .HasColumnType("VARCHAR(80)")
            .IsRequired();
        modelBuilder.Entity<Medicacao>()
            .Property(cam => cam.CompostoAtivoMedicacao)
            .HasColumnType("VARCHAR(50)")
            .IsRequired();
        modelBuilder.Entity<Medicacao>()
            .Property(lm => lm.LaboratorioMedicaocao)
            .HasColumnType("VARCHAR(80)")
            .IsRequired();
        modelBuilder.Entity<Medicacao>()
            .Property(gen => gen.Generico)
            .HasColumnType("CHAR(1)")
            .IsRequired();
        /* -> END MEDICAMENTOS */

    }
}
