using Microsoft.EntityFrameworkCore;
using WEB_API_HealTime.Models;

namespace WEB_API_HealTime.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    public DbSet<PrescricaoPaciente> PrescricaoPacientes { get; set; }
    public DbSet<Medico> Medicos { get; set; }

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
        /* -> THEN <- */
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
        /* -> THEN  PRESCRICAOPACIENTES */

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
        

        /* -> THEN MEDICO */

    }
}
