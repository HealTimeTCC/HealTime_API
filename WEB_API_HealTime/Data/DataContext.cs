using Microsoft.EntityFrameworkCore;
using WEB_API_HealTime.Utility;
using WEB_API_HealTime.Models.ConsultasMedicas;
using WEB_API_HealTime.Models.Medicacoes;
using WEB_API_HealTime.Models.Medicacoes.Enums;

namespace WEB_API_HealTime.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    public DbSet<PrescricaoPaciente> PrescricaoPacientes { get; set; }
    public DbSet<Medico> Medicos { get; set; }
    public DbSet<Pessoa> Pessoas { get; set; }
    public DbSet<Medicacao> Medicacoes { get; set; }
    public DbSet<TipoMedicacao> TiposMedicacoes { get; set; }
    public DbSet<PrescricaoMedicacao> PrescricoesMedicacoes { get; set; }
    public DbSet<StatusConsulta> StatusConsultas { get; set; }
    public DbSet<ConsultaAgendada> ConsultasAgendadas { get; set; }
    public DbSet<ConsultaCancelada> ConsultaCanceladas { get; set; }
    public DbSet<Especialidade> Especialidades { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        /* -> BEGIN ESPECIALIDADES */
        modelBuilder.Entity<Especialidade>()
            .HasKey(pk => pk.EspecialidadeId)
            .HasName("PK_EspecialidadeId");
        
        /* -> END   ESPECIALIDADES */

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
            .HasOne(p => p.Pessoa)
            .WithMany(p => p.PrescricaoPacientes)
                .HasForeignKey(fk => fk.PacienteId)
                .HasConstraintName("FK_PacienteId_PrescricoesPacientes");
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
        modelBuilder.Entity<PrescricaoPaciente>()
            .Property(flag => flag.FlagStatus)
            .HasColumnType("CHAR(1)")
            .HasDefaultValue("S")
            .IsRequired();
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
            .HasColumnType("CHAR(6)");
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
            .HasOne<TipoMedicacao>(tp => tp.TipoMedicacao)
            .WithMany(tp => tp.Medicacoes)
                .HasForeignKey(fk => fk.TipoMedicacaoId)
                .HasConstraintName("FK_Medicacao_TipoMedicacao");
        modelBuilder.Entity<Medicacao>()
            .Property(st => st.StatusMedicacao)
            .HasDefaultValue(EnumStatusMedicacao.ATIVO);
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
            .HasIndex(pk => pk.PrescricaoPacienteId);
        //.IsUnique(false);//fazer teste com UNIQUE, fiz isso por gambis
        modelBuilder.Entity<PrescricaoMedicacao>()
            .Property(flag => flag.StatusMedicacaoFlag)
            .HasColumnType("CHAR(1)")
            .HasDefaultValue("S");

        /* -> END PRESCRICAOMEDICACAO */


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

        /* -> BEGIN ConsultaAgendada */

        modelBuilder.Entity<ConsultaAgendada>()
            .HasKey(pk => pk.ConsultasAgendadasId)
            .HasName("PK_ConsultaAgendadaId");

        modelBuilder.Entity<ConsultaAgendada>()
            .HasOne<Especialidade>(m => m.Especialidade)
            .WithMany(m => m.ConsultaAgendadas)
                .HasForeignKey(m => m.EspecialidadeId)
                .HasConstraintName("FK_EspecialidadeId");

        modelBuilder.Entity<ConsultaAgendada>()
            .HasOne(one => one.Medico)
            .WithMany(many => many.ConsultaAgendadas)
                .HasForeignKey(fk => fk.MedicoId)
                .HasConstraintName("FK_MedicoId_ConsultaAgendadaId");
        modelBuilder.Entity<ConsultaAgendada>()
            .Property(d => d.DataSolicitacaoConsulta)
            .HasColumnType("DATE")
            .IsRequired();
        modelBuilder.Entity<ConsultaAgendada>()
            .Property(d => d.DataConsulta)
            .HasColumnType("DATE")
            .IsRequired();
        modelBuilder.Entity<ConsultaAgendada>()
            .Property(d => d.MotivoConsulta)
            .HasColumnType("VARCHAR(300)");
        modelBuilder.Entity<ConsultaAgendada>()
            .Property(d => d.Encaminhamento)
            .HasColumnType("CHAR(1)")
            .IsRequired();

        /* -> END ConsultaAgendada */

        /* -> BEGIN StatusConsulta */

        modelBuilder.Entity<StatusConsulta>()
            .HasKey(pk => pk.StatusConsultaId)
            .HasName("PK_StatusConsultaId");
        modelBuilder.Entity<StatusConsulta>()
            .HasMany<ConsultaAgendada>(many => many.ConsultasAgendadas)
            .WithOne(f => f.StatusConsulta)
                .HasForeignKey(f => f.StatusConsultasId)
                .HasConstraintName("FK_ConsultaAgendadas_StatusConsulta");
        modelBuilder.Entity<StatusConsulta>()
            .Property(desc => desc.DescStatusConsulta)
            .HasColumnType("VARCHAR(25)")
            .IsRequired();

        /* -> END StatusConsulta */
        /* -> BEGIN ConsultaCancelada */

        //modelBuilder.Entity<ConsultaCancelada>()
        //    .Property(i => i.ConsultaAgendadaId)
        //    .ValueGeneratedNever();

        modelBuilder.Entity<ConsultaCancelada>()
            .HasKey(key => new { key.ConsultaCanceladaId, key.ConsultaAgendadaId })
            .HasName("PK_ConsultaCancelada_ConsultaAgendada");

        modelBuilder.Entity<ConsultaCancelada>()
            .Property(x => x.ConsultaCanceladaId)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<ConsultaCancelada>()
            .HasOne<ConsultaAgendada>(x => x.ConsultaAgendada)
            .WithOne(x => x.ConsultaCancelada)
                .HasForeignKey<ConsultaCancelada>(x => x.ConsultaAgendadaId)
                .HasConstraintName("FK_ConsultaAgendadaId");
        modelBuilder.Entity<ConsultaCancelada>()
            .Property(desc => desc.MotivoCancelamento)
            .HasColumnType("VARCHAR(300)")
            .IsRequired();
        modelBuilder.Entity<ConsultaCancelada>()
            .Property(dt => dt.DataCancelamento)
            .HasColumnType("DATE")
            .IsRequired();
        /* -> END ConsultaCancelada */


        /*VALORES DEFAULT*/
        modelBuilder.Entity<Medico>()
                .HasData(
                new Medico
                {
                    MedicoId = 1,
                    CrmMedico = "054321",
                    NmMedico = "Dr Val",
                    UfCrmMedico = "SP"
                },
                new Medico
                {
                    MedicoId = 2,
                    CrmMedico = "012345",
                    NmMedico = "Dr Teste",
                    UfCrmMedico = "RJ"
                }
                );
        Criptografia.CriarPasswordHash("1q2w3e4r", out byte[] hash, out byte[] salt);
        modelBuilder.Entity<Pessoa>()
            .HasData(
                new Pessoa
                {
                    PessoaId = 1,
                    NomePessoa = "Dan",
                    SobreNomePessoa = "Marzo",
                    CpfPessoa = "12345678909",
                    DtNascPessoa = DateTime.Parse("2004-02-15"),
                    PasswordHash = hash,
                    PasswordSalt = salt,
                    TipoPessoaId = 1
                }
            );
        modelBuilder.Entity<StatusConsulta>()
            .HasData(
                new StatusConsulta
                {
                    StatusConsultaId = 1,
                    DescStatusConsulta = "Encerrada"
                },
                new StatusConsulta
                {
                    StatusConsultaId = 2,
                    DescStatusConsulta = "Agendada"
                },
                new StatusConsulta
                {
                    StatusConsultaId = 3,
                    DescStatusConsulta = "Cancelada"
                },
                new StatusConsulta
                {
                    StatusConsultaId = 4,
                    DescStatusConsulta = "Remarcada"
                },
                new StatusConsulta
                {
                    StatusConsultaId = 5,
                    DescStatusConsulta = "Fila de espera"
                }
            );
        //Tipo medicacao
        modelBuilder.Entity<TipoMedicacao>().HasData(
                new { TipoMedicacaoId = 1, DescMedicacao = "Aplicado pela boca", TituloTipoMedicacao = "Via oral",               ClasseAplicacao = EnumClasseAplicacaoMedicacao.Enteral },
                new { TipoMedicacaoId = 2, DescMedicacao = "Aplicado  por dembaixo da língua", TituloTipoMedicacao= "Sublingual",   ClasseAplicacao = EnumClasseAplicacaoMedicacao.Enteral },
                new { TipoMedicacaoId = 3, DescMedicacao = "Aplicado pelo canal retal",        TituloTipoMedicacao= "Supositorios", ClasseAplicacao = EnumClasseAplicacaoMedicacao.Enteral },
                new { TipoMedicacaoId = 4, DescMedicacao = "Aplicada diretamente no sangue",   TituloTipoMedicacao= "Intravenosa",  ClasseAplicacao = EnumClasseAplicacaoMedicacao.Parenteral },
                new { TipoMedicacaoId = 5, DescMedicacao = "Aplicada diretamente no músculo",  TituloTipoMedicacao= "Intramuscular",ClasseAplicacao = EnumClasseAplicacaoMedicacao.Parenteral},
                new { TipoMedicacaoId = 6, DescMedicacao = "Aplicada debaixo da pele",         TituloTipoMedicacao= "Subcutânea",   ClasseAplicacao = EnumClasseAplicacaoMedicacao.Parenteral},
                new { TipoMedicacaoId = 7, DescMedicacao = string.Empty,                       TituloTipoMedicacao= "Respiratória", ClasseAplicacao = EnumClasseAplicacaoMedicacao.Parenteral},
                new { TipoMedicacaoId = 8, DescMedicacao = "Aplicada por pomadas",             TituloTipoMedicacao= "Via tópica",   ClasseAplicacao = EnumClasseAplicacaoMedicacao.Parenteral},
                new { TipoMedicacaoId = 9, DescMedicacao  = string.Empty,                      TituloTipoMedicacao= "Via Ocular",   ClasseAplicacao = EnumClasseAplicacaoMedicacao.Parenteral},
                new { TipoMedicacaoId = 10, DescMedicacao = string.Empty,                      TituloTipoMedicacao= "Via Nasal",    ClasseAplicacao = EnumClasseAplicacaoMedicacao.Parenteral},
                new { TipoMedicacaoId = 11, DescMedicacao = string.Empty, TituloTipoMedicacao = "Via Auricular",ClasseAplicacao = EnumClasseAplicacaoMedicacao.Parenteral }
            );
    }
}
