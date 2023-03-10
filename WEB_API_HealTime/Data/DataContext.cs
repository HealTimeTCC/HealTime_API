using Microsoft.EntityFrameworkCore;
using WEB_API_HealTime.Models.ConsultasMedicas;
using WEB_API_HealTime.Models.Medicacoes;

namespace WEB_API_HealTime.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    public DbSet<PrescricaoPaciente> PrescricaoPacientes { get; set; }
    public DbSet<Medico> Medicos { get; set; }
    public DbSet<Pessoa> Pessoas { get; set; }
    public DbSet<Medicacao> Medicacoes { get; set; }
    public DbSet<StatusMedicacao> StatusMedicacoes { get; set; }
    public DbSet<TipoMedicacao> TiposMedicacoes { get; set; }
    public DbSet<PrescricaoMedicacao> PrescricoesMedicacoes { get; set; }
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
            .WithMany(one => one.PrescricoesPacientes)
                .HasForeignKey(f => f.MedicoId)
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
            .Property(dt => dt.DtNascPessoa)
            .HasColumnType("DATE")
            .IsRequired();
        /* -> END PESSOAS */

        /* -> BEGIN MEDICAMENTOS */

        modelBuilder.Entity<Medicacao>()
            .HasKey(pk => pk.MedicacaoId)
            .HasName("PK_MedicacaoId");
        modelBuilder.Entity<Medicacao>()
            .HasOne<StatusMedicacao>(one =>one.StatusMedicacao)
            .WithMany(many => many.Medicacoes)
            .HasForeignKey(fk => fk.StatusMedicacaoId)
                .HasConstraintName("FK_Medicacao_StatusMedicacao");

        modelBuilder.Entity<Medicacao>()
            .HasOne<TipoMedicacao>(tp => tp.TipoMedicacao)
            .WithMany(tp => tp.Medicacoes)
                .HasForeignKey(fk => fk.TipoMedicacaoId)
                .HasConstraintName("FK_Medicacao_TipoMedicacao");

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

        /* -> BEGIN PRESCRICAOMEDICACAO */

        modelBuilder.Entity<PrescricaoMedicacao>()
            .HasOne<PrescricaoPaciente>(one => one.PrescricaoPaciente)
            .WithMany(many => many.PrescricoesMedicacoes)
                .HasForeignKey(fk => fk.PrescricaoPacienteId)
                .HasConstraintName("PK_PrescricaoPacienteId_PrescricaoMedicao");
        modelBuilder.Entity<PrescricaoMedicacao>()
            .HasOne<Medicacao>(one => one.Medicacao)
            .WithOne(many => many.PrescricaoMedicacao)
                .HasForeignKey<PrescricaoMedicacao>(fk => fk.MedicacaoId)
                .HasConstraintName("PK_MedicacaoId_PrescricaoMedicao");
        modelBuilder.Entity<PrescricaoMedicacao>()
            .HasKey(pk => new { pk.PrescricaoPacienteId, pk.MedicacaoId })
                .HasName("PK_CONCAT_PrescricaPacienteId_MedicacaoId");
        modelBuilder.Entity<PrescricaoMedicacao>()
            .HasIndex(pk => pk.PrescricaoPacienteId)
            .IsUnique(false);//fazer teste com UNIQUE, fiz isso por gambis

        /* -> END PRESCRICAOMEDICACAO */

        /* -> BEGIN STATUSMEDICACAO */

        modelBuilder.Entity<StatusMedicacao>()
            .HasKey(pk => pk.StatusMedicacaoId)
                .HasName("PK_StatusMedicacaoId");
        modelBuilder.Entity<StatusMedicacao>()
            .Property(desc => desc.DescStatusMedicacao)
            .HasColumnType("VARCHAR(25)");

        /* -> END STATUSMEDICACAO */
        
        /* -> BEGIN TIPOMEDICACAO */

        modelBuilder.Entity<TipoMedicacao>()
            .HasKey(pk => pk.TipoMedicacaoId)
                .HasName("PK_TipoMedicacaoId");
        modelBuilder.Entity<TipoMedicacao>()
            .Property(desc => desc.DescMedicacao)
            .HasColumnType("VARCHAR(100)");
        modelBuilder.Entity<TipoMedicacao>()
            .Property(title => title.TituloTipoMedicacao)
            .HasColumnType("VARCHAR(100)")
            .IsRequired();
        /* -> END TIPOMEDICACAO */



        /*VALORES DEFAULT*/
        modelBuilder.Entity<Medico>()
            .HasData(
            new Medico
            {
                MedicoId = 1,
                CrmMedico = 12345,
                NmMedico = "Dr Val",
                UfCrmMedico = "SP"
            },
            new Medico
            {
                MedicoId = 2,
                CrmMedico = 12345,
                NmMedico = "Dr Teste",
                UfCrmMedico = "RJ"
            }
            );
        modelBuilder.Entity<StatusMedicacao>()
            .HasData(
                new StatusMedicacao 
                {
                    StatusMedicacaoId = 1,
                    DescStatusMedicacao = "ATIVO"
                },
                new StatusMedicacao 
                {
                    StatusMedicacaoId = 2,
                    DescStatusMedicacao = "INATIVO"
                },
                new StatusMedicacao 
                {
                    StatusMedicacaoId = 3,
                    DescStatusMedicacao = "EFEITO COLATERAL GRAVE"
                },
                new StatusMedicacao 
                {
                    StatusMedicacaoId = 4,
                    DescStatusMedicacao = "REAÇÃO GRAVE"
                }
            );
        modelBuilder.Entity<TipoMedicacao>()
            .HasData(
                new TipoMedicacao
                {
                    TipoMedicacaoId     = 1,
                    TituloTipoMedicacao = "NASAL",
                    ClasseAplicacao     = 1,
                    DescMedicacao       = "Experimental"
                },
                new TipoMedicacao
                {
                    TipoMedicacaoId     = 2,
                    TituloTipoMedicacao = "PILULA",
                    ClasseAplicacao     = 2,
                    DescMedicacao       = "Experimental EXPERIMENTE CALADO"
                }
            );
    }
}
