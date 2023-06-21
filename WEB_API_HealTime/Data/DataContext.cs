using Microsoft.EntityFrameworkCore;
using WEB_API_HealTime.Utility;
using WEB_API_HealTime.Models.ConsultasMedicas;
using WEB_API_HealTime.Models.Medicacoes;
using WEB_API_HealTime.Models.Medicacoes.Enums;
using WEB_API_HealTime.Models.Pessoas;
using WEB_API_HealTime.Models.Pessoas.Enums;
using WEB_API_HealTime.Models.Pacientes;
namespace WEB_API_HealTime.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    #region DBSETs
    public DbSet<PrescricaoPaciente> PrescricaoPacientes { get; set; }
    public DbSet<Medico> Medicos { get; set; }
    public DbSet<Pessoa> Pessoas { get; set; }
    public DbSet<EnderecoPessoa> EnderecoPessoas { get; set; }
    public DbSet<ContatoPessoa> ContatoPessoas { get; set; }
    public DbSet<Medicacao> Medicacoes { get; set; }
    public DbSet<TipoMedicacao> TiposMedicacoes { get; set; }
    public DbSet<PrescricaoMedicacao> PrescricoesMedicacoes { get; set; }
    public DbSet<StatusConsulta> StatusConsultas { get; set; }
    public DbSet<ConsultaAgendada> ConsultasAgendadas { get; set; }
    public DbSet<ConsultaCancelada> ConsultaCanceladas { get; set; }
    public DbSet<Especialidade> Especialidades { get; set; }
    public DbSet<AndamentoMedicacao> AndamentoMedicacoes { get; set; }
    public DbSet<ObservacaoPaciente> ObservacoesPacientes { get; set; }
    public DbSet<ResponsavelPaciente> ResponsaveisPacientes { get; set; }
    public DbSet<GrauParentesco> GrauParentesco { get; set; }
    public DbSet<CuidadorPaciente> CuidadorPacientes { get; set; }
    #endregion
    protected override void OnModelCreating(ModelBuilder mdBuilder)
    {
        base.OnModelCreating(mdBuilder);

        #region --> Pacientes <--
        #region GrauParentesco 

        mdBuilder.Entity<GrauParentesco>()
            .HasKey(key => key.GrauParentescoId)
            .HasName("PK_GrauParentescoId");

        mdBuilder.Entity<GrauParentesco>()
            .Property(p => p.DescGrauParentesco)
            .HasColumnType("VARCHAR(15)")
            .IsRequired();

        #endregion
        #region ObservacaoPaciente

        mdBuilder.Entity<ObservacaoPaciente>()
            .HasKey(key => key.SqObservacao)
            .HasName("PK_SqObservacao");
        mdBuilder.Entity<ObservacaoPaciente>()
            .HasOne(one => one.Paciente)
            .WithMany(many => many.ObservacoesPacientes)
            .HasForeignKey(fk => fk.PacienteId)
            .HasConstraintName("FK_SqObservacao_Pessoas");

        mdBuilder.Entity<ObservacaoPaciente>()
               .Property(p => p.MtObservacao)
               .HasColumnType("datetime2(0)")
               .IsRequired();
        mdBuilder.Entity<ObservacaoPaciente>()
               .Property(p => p.Observacao)
               .HasColumnType("VARCHAR(255)")
               .IsRequired();
        #endregion
        #region ResponsavelPaciente

        mdBuilder.Entity<ResponsavelPaciente>()
            .HasKey(key => new { key.PacienteId, key.ResponsavelId })
            .HasName("PK_PacienteId_ResponsavelId");


        mdBuilder.Entity<ResponsavelPaciente>()
            .HasOne(one => one.Paciente)
            .WithMany(many => many.ResponsavelPacientes_Pacientes)
            .HasForeignKey(fk => fk.PacienteId)
            .HasConstraintName("FK_PacienteId_Pessoas_ResponsavelPaciente")
            .OnDelete(DeleteBehavior.Restrict);

        mdBuilder.Entity<ResponsavelPaciente>()
            .HasOne(one => one.Responsavel)
            .WithMany(many => many.ResponsavelPacientes_Responsavel)
                .HasForeignKey(fk => fk.ResponsavelId)
                .HasConstraintName("FK_ResponsavelId_Pessoas_ResponsavelPaciente")
                .OnDelete(DeleteBehavior.Restrict);

        mdBuilder.Entity<ResponsavelPaciente>()
            .HasOne(one => one.GrauParentesco)
            .WithMany(one => one.ResponsavelPacientes)
                .HasForeignKey(fk => fk.GrauParentescoId)
                .HasConstraintName("FK_GrauParentescoId_GrauParentesco_ResponsavelPaciente");
        mdBuilder.Entity<ResponsavelPaciente>()
            .Property(p => p.CriadoEm)
            .HasColumnType("datetime2(0)")
            .IsRequired()
            .HasDefaultValueSql("GETDATE()");

        #endregion
        #region CuidadorPaciente

        mdBuilder.Entity<CuidadorPaciente>()
            .HasKey(key => new { key.PacienteId, key.CuidadorId, key.CriadoEm })
            .HasName("PK_CuidadorPacientes_PacienteId_CuidadorId");
        mdBuilder.Entity<CuidadorPaciente>()
            .HasOne(one => one.PessoaPaciente)
            .WithMany(many => many.CuidadorPaciente_Pacientes)
            .HasForeignKey(p => p.PacienteId)
                .HasConstraintName("FK_Pessoa_CuidadorPaciente_PacienteId")
                .OnDelete(DeleteBehavior.Restrict);
        mdBuilder.Entity<CuidadorPaciente>()
            .HasOne(one => one.PessoaCuidador)
            .WithMany(many => many.CuidadorPaciente_Cuidador)
            .HasForeignKey(p => p.CuidadorId)
                .HasConstraintName("FK_Pessoa_CuidadorPaciente_CuidadorId")
                .OnDelete(DeleteBehavior.Restrict);

        mdBuilder.Entity<CuidadorPaciente>()
            .Property(p => p.CriadoEm)
            .HasColumnType("DATETIME2(0)")
            .IsRequired();
        mdBuilder.Entity<CuidadorPaciente>()
            .Property(p => p.FinalizadoEm)
            .HasColumnType("DATETIME2(0)");

        #endregion
        #endregion
        #region --> Pessoa <--

        #region PESSOAS
        mdBuilder.Entity<Pessoa>()
            .HasKey(pk => pk.PessoaId)
            .HasName("PK_PessoaId");
        mdBuilder.Entity<Pessoa>()
            .Property(tp => tp.TipoPessoa)
            .IsRequired();
        mdBuilder.Entity<Pessoa>()
            .Property(cpf => cpf.CpfPessoa)
            .HasColumnType("CHAR(11)")
            .IsRequired();
        mdBuilder.Entity<Pessoa>()
            .HasIndex(p => p.CpfPessoa)
            .IsUnique(true)
            .HasDatabaseName("UNIQUE_ON_CPF");
        mdBuilder.Entity<Pessoa>()
            .Property(nm => nm.NomePessoa)
            .HasColumnType("VARCHAR(25)")
            .IsRequired();
        mdBuilder.Entity<Pessoa>()
            .Property(sm => sm.SobreNomePessoa)
            .HasColumnType("VARCHAR(30)")
            .IsRequired();
        mdBuilder.Entity<Pessoa>()
            .Property(dt => dt.DtNascPessoa)
            .HasColumnType("datetime2(0)")
            .IsRequired();
        #region  --> HASH and SALT <--
        #endregion
        #endregion
        #region ContatoPessoa

        mdBuilder.Entity<ContatoPessoa>()
            .HasKey(key => key.PessoaId)
            .HasName("PK_ContatoPessoaId");

        mdBuilder.Entity<ContatoPessoa>()
            .HasOne<Pessoa>(one => one.Pessoa)
            .WithOne(one => one.ContatoPessoa)
                .HasForeignKey<ContatoPessoa>(fk => fk.PessoaId)
                .HasConstraintName("FK_Pessoa_ContatoPessoa_PessoaId");

        mdBuilder.Entity<ContatoPessoa>()
            .Property(p => p.Email)
            .HasColumnType("VARCHAR(100)")
            .IsRequired();
        mdBuilder.Entity<ContatoPessoa>()
            .HasIndex(i => i.Email)
            .IsUnique(true);

        mdBuilder.Entity<ContatoPessoa>()
            .Property(p => p.CriadoEm)
            .HasColumnType("datetime2(0)")
            .HasDefaultValueSql("GETDATE()")
            .IsRequired();
        mdBuilder.Entity<ContatoPessoa>()
            .HasIndex(p => p.Celular)
            .IsUnique(false);
        mdBuilder.Entity<ContatoPessoa>()
            .Property(p => p.Celular)
            .HasColumnType("CHAR(11)")
            .IsRequired();

        mdBuilder.Entity<ContatoPessoa>()
            .Property(p => p.CelularSecundario)
            .HasColumnType("CHAR(11)");

        mdBuilder.Entity<ContatoPessoa>()
            .Property(p => p.Telefone)
            .HasColumnType("CHAR(10)");

        mdBuilder.Entity<ContatoPessoa>()
            .Property(p => p.TelefoneSecundario)
            .HasColumnType("CHAR(10)");

        #endregion
        #region EnderecoPessoa

        mdBuilder.Entity<EnderecoPessoa>()
            .HasKey(pk => pk.PessoaId)
            .HasName("PK_FK_EnderecoPessoa");

        mdBuilder.Entity<EnderecoPessoa>()
            .HasOne(x => x.Pessoa)
            .WithOne(p => p.EnderecoPessoa)
                .HasForeignKey<EnderecoPessoa>(fk => fk.PessoaId)
                .HasConstraintName("FK_PK_EnderecoPessoa");
        mdBuilder.Entity<EnderecoPessoa>()
            .Property(str => str.Logradouro)
            .HasColumnType("VARCHAR(40)")
            .IsRequired();
        mdBuilder.Entity<EnderecoPessoa>()
            .Property(str => str.NroLogradouro)
            .HasColumnType("INT")
            .IsRequired();
        mdBuilder.Entity<EnderecoPessoa>()
            .Property(str => str.Complemento)
            .HasColumnType("VARCHAR(15)");
        mdBuilder.Entity<EnderecoPessoa>()
            .Property(str => str.BairroLogradouro)
            .HasColumnType("VARCHAR(25)")
            .IsRequired();
        mdBuilder.Entity<EnderecoPessoa>()
            .Property(str => str.CidadeEndereco)
            .HasColumnType("VARCHAR(25)")
            .IsRequired();
        mdBuilder.Entity<EnderecoPessoa>()
            .Property(str => str.UFEndereco)
            .HasColumnType("CHAR(2)")
            .IsRequired();
        mdBuilder.Entity<EnderecoPessoa>()
            .Property(str => str.CEPEndereco)
            .HasColumnType("CHAR(8)")
            .IsRequired();

        #endregion

        #endregion
        #region --> Medicacoes <--

        //-------------------------------------------------------------------

        #region PRESCRICAOPACIENTES
        /* -> BEGIN PRESCRICAOPACIENTES */
        mdBuilder.Entity<PrescricaoPaciente>()
            .HasKey(pk => pk.PrescricaoPacienteId)
            .HasName("PK_PrescricaoPacienteId");
        /* -> BEGIN: Esses dois abaixo são relacionamento <- */
        mdBuilder.Entity<PrescricaoPaciente>()
            .HasOne<Medico>(one => one.Medico)
            .WithMany(one => one.PrescricoesPacientes)
                .HasForeignKey(f => f.MedicoId)
                .HasConstraintName("FK_PrescricaoPaciente_Medico");

        mdBuilder.Entity<PrescricaoPaciente>()
            .HasOne(p => p.Pessoa)
            .WithMany(p => p.PrescricaoPacientes)
                .HasForeignKey(fk => fk.PacienteId)
                .HasConstraintName("FK_PacienteId_PrescricoesPacientes");
        /* -> END <- */
        mdBuilder.Entity<PrescricaoPaciente>()
            .Property(dt => dt.CriadoEm)
            .HasColumnType("datetime2(0)")
            .IsRequired();
        mdBuilder.Entity<PrescricaoPaciente>()
            .Property(dt => dt.Emissao)
            .HasColumnType("datetime2(0)")
            .IsRequired();
        mdBuilder.Entity<PrescricaoPaciente>()
            .Property(dt => dt.Validade)
            .HasColumnType("datetime2(0)")
            .IsRequired();
        mdBuilder.Entity<PrescricaoPaciente>()
            .Property(desc => desc.DescFichaPessoa)
            .HasColumnType("VARCHAR(350)");
        mdBuilder.Entity<PrescricaoPaciente>()
            .Property(flag => flag.FlagStatusAtivo)
            .HasDefaultValue(true)
            .IsRequired();
        #endregion
       
        #region PRESCRICAOMEDICACAO
        mdBuilder.Entity<PrescricaoMedicacao>()
       //.HasKey(pk => new { pk.PrescricaoMedicacaoId, pk.PrescricaoPacienteId, pk.MedicacaoId })
       .HasKey(pk => pk.PrescricaoMedicacaoId)
           .HasName("PK__PrescricaPacienteId");
        mdBuilder.Entity<PrescricaoMedicacao>()
            .HasOne<PrescricaoPaciente>(one => one.PrescricaoPaciente)
            .WithMany(many => many.PrescricoesMedicacoes)
                .HasForeignKey(fk => fk.PrescricaoPacienteId)
                .HasConstraintName("PK_PrescricaoPacienteId_PrescricaoMedicao")
                .OnDelete(DeleteBehavior.Restrict);
        mdBuilder.Entity<PrescricaoMedicacao>()
            .HasOne<Medicacao>(one => one.Medicacao)
            .WithOne(many => many.PrescricaoMedicacao)
                .HasForeignKey<PrescricaoMedicacao>(fk => fk.MedicacaoId)
                .HasConstraintName("PK_MedicacaoId_PrescricaoMedicao");

   
        mdBuilder.Entity<PrescricaoMedicacao>()
            .Property(pk => pk.PrescricaoMedicacaoId)
            .UseIdentityColumn();
        mdBuilder.Entity<PrescricaoMedicacao>()
            .HasIndex(pk => pk.MedicacaoId)
            .IsUnique(false);
        
        mdBuilder.Entity<PrescricaoMedicacao>()
            .HasIndex(pk => pk.MedicacaoId)
            .IsUnique(false);

        mdBuilder.Entity<PrescricaoMedicacao>()
           .Property(qtd => qtd.Qtde)
           .HasColumnType("FLOAT(10, 2)");
        
        mdBuilder.Entity<PrescricaoMedicacao>()
            .Property(qtd => qtd.Intervalo)
            .HasColumnType("TIME")
               .IsRequired();

        mdBuilder.Entity<PrescricaoMedicacao>()
            .Property(qtd => qtd.StatusMedicacaoFlag)
            .HasDefaultValue(true)
            .IsRequired();

        mdBuilder.Entity<PrescricaoMedicacao>()
            .Property(qtd => qtd.HorariosDefinidos)
            .HasDefaultValue(false);
        #endregion

        #region ANDAMENTOMEDICACAO

        mdBuilder.Entity<AndamentoMedicacao>()
            .HasKey(key => new
            {
                key.AndamentoMedicacaoId,
                key.PrescricaoMedicacaoId,
                key.MedicacaoId,
                key.PrescricaoPacienteId
            } )
            .HasName("PK_AndamentoMedicacao_AndamentoMedicacaoId");

        mdBuilder.Entity<AndamentoMedicacao>()
            .ToTable(tb => tb.HasTrigger("ControlStatePrescriptionMedicine"));

        //modelBuilder.Entity<Blog>()
        //.ToTable(tb => tb.HasTrigger("SomeTrigger"));


        mdBuilder.Entity<AndamentoMedicacao>()
            .HasOne(p => p.PrescricaoMedicacao)
            .WithMany(p => p.AndamentoMedicacoes)
            .HasForeignKey(p => p.PrescricaoMedicacaoId)
                .HasConstraintName("FK_AndamentoMedicacao_PrescricaoMedicacao");
        mdBuilder.Entity<AndamentoMedicacao>()
            .Property(p => p.AndamentoMedicacaoId)
            .ValueGeneratedNever();


        mdBuilder.Entity<AndamentoMedicacao>()
            .HasIndex(p => p.PrescricaoPacienteId)
            .IsUnique(false);

        mdBuilder.Entity<AndamentoMedicacao>()
           .HasIndex(p => p.PrescricaoMedicacaoId)
           .IsUnique(false);

        mdBuilder.Entity<AndamentoMedicacao>()
            .Property(p => p.PrescricaoMedicacaoId)
            .HasColumnType("INT")
            .IsRequired();

        mdBuilder.Entity<AndamentoMedicacao>()
            .Property(p => p.MtAndamentoMedicacao)
            .HasColumnType("datetime2(0)")
            .IsRequired();

        mdBuilder.Entity<AndamentoMedicacao>()
            .Property(p => p.QtdeMedicao)
            .HasColumnType("INT")
            .IsRequired();
        
        mdBuilder.Entity<AndamentoMedicacao>()
            .Property(p => p.CriadoEm)
            .HasColumnType("datetime2(0)")
            .IsRequired();

        mdBuilder.Entity<AndamentoMedicacao>()
            .Property(p => p.BaixaAndamentoMedicacao)
            .HasDefaultValue(false);

        mdBuilder.Entity<AndamentoMedicacao>()
            .Property(p => p.MtBaixaMedicacao)
            .HasColumnType("datetime2(0)");

        mdBuilder.Entity<AndamentoMedicacao>()
            .Property(cod => cod.CodAplicadorMedicacao)
            .HasColumnType("INT");
        #endregion


        //-------------------------------------------------------------------
        #region TipoMedicacao
        mdBuilder.Entity<TipoMedicacao>()
            .HasKey(pk => pk.TipoMedicacaoId)
                .HasName("PK_TipoMedicacaoId");
        mdBuilder.Entity<TipoMedicacao>()
            .Property(desc => desc.DescMedicacao)
            .HasColumnType("VARCHAR(100)");
        mdBuilder.Entity<TipoMedicacao>()
            .Property(title => title.TituloTipoMedicacao)
            .HasColumnType("VARCHAR(100)")
            .IsRequired();
        #endregion
        #region MEDICAMENTOS
        mdBuilder.Entity<Medicacao>()
            .HasKey(pk => pk.MedicacaoId)
            .HasName("PK_MedicacaoId");
        mdBuilder.Entity<Medicacao>()
            .HasOne<TipoMedicacao>(tp => tp.TipoMedicacao)
            .WithMany(tp => tp.Medicacoes)
                .HasForeignKey(fk => fk.TipoMedicacaoId)
                .HasConstraintName("FK_Medicacao_TipoMedicacao");
        mdBuilder.Entity<Medicacao>()
            .Property(st => st.StatusMedicacao)
            .HasDefaultValue(EnumStatusMedicacao.ATIVO);
        mdBuilder.Entity<Medicacao>()
            .Property(nm => nm.NomeMedicacao)
            .HasColumnType("VARCHAR(80)")
            .IsRequired();
        mdBuilder.Entity<Medicacao>()
            .Property(cam => cam.CompostoAtivoMedicacao)
            .HasColumnType("VARCHAR(50)")
            .IsRequired();
        mdBuilder.Entity<Medicacao>()
            .Property(lm => lm.LaboratorioMedicacao)
            .HasColumnType("VARCHAR(80)")
            .IsRequired();
        mdBuilder.Entity<Medicacao>()
            .Property(gen => gen.Generico)
            .HasColumnType("CHAR(1)")
            .IsRequired();
        #endregion

        #endregion

        #region --> ConsultaMedicao <--
        #region Especialidades
        /* -> BEGIN ESPECIALIDADES */
        mdBuilder.Entity<Especialidade>()
            .HasKey(pk => pk.EspecialidadeId)
            .HasName("PK_EspecialidadeId");
        mdBuilder.Entity<Especialidade>()
            .Property(p => p.DescEspecialidade)
            .HasColumnType("VARCHAR(25)")
            .IsRequired();
        /* -> END   ESPECIALIDADES */
        #endregion
        #region ConsultaAgenda
        /* -> BEGIN ConsultaAgendada */

        mdBuilder.Entity<ConsultaAgendada>()
            .HasKey(pk => pk.ConsultasAgendadasId)
            .HasName("PK_ConsultaAgendadaId");

        mdBuilder.Entity<ConsultaAgendada>()
            .HasOne<Especialidade>(m => m.Especialidade)
            .WithMany(m => m.ConsultaAgendadas)
                .HasForeignKey(m => m.EspecialidadeId)
                .HasConstraintName("FK_EspecialidadeId");

        mdBuilder.Entity<ConsultaAgendada>()
            .HasOne(one => one.Medico)
            .WithMany(many => many.ConsultaAgendadas)
                .HasForeignKey(fk => fk.MedicoId)
                .HasConstraintName("FK_MedicoId_ConsultaAgendadaId");
        mdBuilder.Entity<ConsultaAgendada>()
            .Property(d => d.DataSolicitacaoConsulta)
            .HasColumnType("datetime2(0)")
            .IsRequired();
        mdBuilder.Entity<ConsultaAgendada>()
            .Property(d => d.DataConsulta)
            .HasColumnType("datetime2(0)")
            .IsRequired();
        mdBuilder.Entity<ConsultaAgendada>()
            .Property(d => d.MotivoConsulta)
            .HasColumnType("VARCHAR(300)");
        mdBuilder.Entity<ConsultaAgendada>()
            .Property(d => d.Encaminhamento)
            .HasColumnType("CHAR(1)")
            .IsRequired();

        /* -> END ConsultaAgendada */
        #endregion
        #region StatusConsulta
        /* -> BEGIN StatusConsulta */

        mdBuilder.Entity<StatusConsulta>()
            .HasKey(pk => pk.StatusConsultaId)
            .HasName("PK_StatusConsultaId");
        mdBuilder.Entity<StatusConsulta>()
            .HasMany<ConsultaAgendada>(many => many.ConsultasAgendadas)
            .WithOne(f => f.StatusConsulta)
                .HasForeignKey(f => f.StatusConsultaId)
                .HasConstraintName("FK_ConsultaAgendadas_StatusConsulta");
        mdBuilder.Entity<StatusConsulta>()
            .Property(desc => desc.DescStatusConsulta)
            .HasColumnType("VARCHAR(25)")
            .IsRequired();

        /* -> END StatusConsulta */
        #endregion
        #region ConsultaCancelada
        /* -> BEGIN ConsultaCancelada */

        mdBuilder.Entity<ConsultaCancelada>()
            .HasKey(key => new { key.ConsultaCanceladaId, key.ConsultaAgendadaId })
            .HasName("PK_ConsultaCancelada_ConsultaAgendada");

        mdBuilder.Entity<ConsultaCancelada>()
            .Property(x => x.ConsultaCanceladaId)
            .ValueGeneratedOnAdd();

        mdBuilder.Entity<ConsultaCancelada>()
            .HasOne<ConsultaAgendada>(x => x.ConsultaAgendada)
            .WithOne(x => x.ConsultaCancelada)
                .HasForeignKey<ConsultaCancelada>(x => x.ConsultaAgendadaId)
                .HasConstraintName("FK_ConsultaAgendadaId");
        mdBuilder.Entity<ConsultaCancelada>()
            .Property(desc => desc.MotivoCancelamento)
            .HasColumnType("VARCHAR(300)")
            .IsRequired();
        mdBuilder.Entity<ConsultaCancelada>()
            .Property(dt => dt.DataCancelamento)
            .HasColumnType("datetime2(0)")
            .IsRequired();
        /* -> END ConsultaCancelada */
        #endregion
        #endregion
        #region MEDICO
        /* -> BEGIN MEDICO */
        mdBuilder.Entity<Medico>()
            .HasKey(pk => pk.MedicoId)
            .HasName("PK_MedicoId");
        mdBuilder.Entity<Medico>()
            .Property(nm => nm.NmMedico)
            .HasColumnType("VARCHAR(40)")
            .IsRequired();
        mdBuilder.Entity<Medico>()
            .Property(crm => crm.CrmMedico)
            .HasColumnType("CHAR(6)");
        mdBuilder.Entity<Medico>()
            .Property(crmuf => crmuf.UfCrmMedico)
            .HasColumnType("CHAR(2)")
            .IsRequired();


        /* -> END MEDICO */
        #endregion
        #region MEDICAÇÕES DEFAULT
        mdBuilder.Entity<Medicacao>()
            .HasData(
                new Medicacao
                {
                    MedicacaoId = 1,
                    TipoMedicacaoId = 1,
                    NomeMedicacao = "DIPIRONA 80g",
                    CompostoAtivoMedicacao = "pirazolônico não narcótico ",
                    Generico = "S",
                    LaboratorioMedicacao = "Sanofi-Aventis",
                    StatusMedicacao = EnumStatusMedicacao.ATIVO
                },
                new Medicacao
                {
                    MedicacaoId = 2,
                    TipoMedicacaoId = 2,
                    NomeMedicacao = "Rocefin",
                    CompostoAtivoMedicacao = "ceftriaxona",
                    Generico = "S",
                    LaboratorioMedicacao = "Roche",
                    StatusMedicacao = EnumStatusMedicacao.ATIVO
                }
            );
        #endregion
        #region MEDICOS DEFAULT
        mdBuilder.Entity<Medico>()
                .HasData(
                new Medico
                {
                    MedicoId = 1,
                    CrmMedico = "054321",
                    NmMedico = "Dr Guilherme Costa",
                    UfCrmMedico = "SP"
                },
                new Medico
                {
                    MedicoId = 2,
                    CrmMedico = "012345",
                    NmMedico = "Dr Adriana Gomes",
                    UfCrmMedico = "RJ"
                }
                );
        #endregion
        #region Pessoas (Acessos default)
        Criptografia.CriarPasswordHash("1q2w3e4r", out byte[] hash, out byte[] salt);
        mdBuilder.Entity<Pessoa>()
            .HasData(
                new Pessoa
                {
                    PessoaId = 1,
                    NomePessoa = "Mayara",
                    SobreNomePessoa = "Pilecarte",
                    CpfPessoa = "67146867064",
                    DtNascPessoa = DateTime.Parse("2003-12-15"),
                    PasswordHash = hash,
                    PasswordSalt = salt,
                    TipoPessoa = EnumTipoPessoa.Responsavel
                }, new Pessoa
                {
                    PessoaId = 2,
                    NomePessoa = "Thiago",
                    SobreNomePessoa = "Roque",
                    CpfPessoa = "94840911053",
                    DtNascPessoa = DateTime.Parse("2003-07-28"),
                    PasswordHash = hash,
                    PasswordSalt = salt,
                    TipoPessoa = EnumTipoPessoa.Cuidador
                },
                new Pessoa
                {
                    PessoaId = 3,
                    NomePessoa = "Dan",
                    SobreNomePessoa = "Marzo",
                    CpfPessoa = "50967422027",
                    DtNascPessoa = DateTime.Parse("2004-02-15"),
                    PasswordHash = hash,
                    PasswordSalt = salt,
                    TipoPessoa = EnumTipoPessoa.Paciente
                },
                new Pessoa
                {
                    PessoaId = 4,
                    NomePessoa = "Nicolly",
                    SobreNomePessoa = "Sodré",
                    CpfPessoa = "15063626050",
                    DtNascPessoa = DateTime.Parse("2004-02-15"),
                    TipoPessoa = EnumTipoPessoa.PacienteIncapaz
                },
                new Pessoa
                {
                    PessoaId = 5,
                    NomePessoa = "Giovana",
                    SobreNomePessoa = "Silva",
                    CpfPessoa = "70414926056",
                    DtNascPessoa = DateTime.Parse("2004-02-15"),
                    TipoPessoa = EnumTipoPessoa.PacienteIncapaz
                },
                new Pessoa
                {
                    PessoaId = 6,
                    NomePessoa = "Pedro",
                    SobreNomePessoa = "Rocha",
                    CpfPessoa = "46473986090",
                    DtNascPessoa = DateTime.Parse("2004-02-15"),
                    TipoPessoa = EnumTipoPessoa.PacienteIncapaz
                }
            );
        #endregion
        #region Contato pessoa
        mdBuilder.Entity<ContatoPessoa>()
            .HasData(
                new ContatoPessoa
                {
                    PessoaId = 1,
                    Email = "may@may.com",
                    CriadoEm = DateTime.Now,
                    Celular = "11978486810"
                },
                new ContatoPessoa
                {
                    PessoaId = 2,
                    Email = "thi@thi.com",
                    CriadoEm = DateTime.Now,
                    Celular = "11978486810"
                },
                new ContatoPessoa
                {
                    PessoaId = 3,
                    Email = "dan@dan.com",
                    CriadoEm = DateTime.Now,
                    Celular = "11978486810"
                }
            );
        #endregion
        #region Cuidador Paciente default 
        mdBuilder.Entity<CuidadorPaciente>()
            .HasData(
                new CuidadorPaciente { PacienteId = 4, CuidadorId = 2, CriadoEm = DateTime.Now },
                new CuidadorPaciente { PacienteId = 5, CuidadorId = 2, CriadoEm = DateTime.Now },
                new CuidadorPaciente { PacienteId = 6, CuidadorId = 2, CriadoEm = DateTime.Now }
            );
        #endregion
        #region Responsavel Paciente Default
        mdBuilder.Entity<ResponsavelPaciente>()
            .HasData(
                new ResponsavelPaciente { PacienteId = 4, ResponsavelId = 1, CriadoEm = DateTime.Now, GrauParentescoId = 1 },
                new ResponsavelPaciente { PacienteId = 5, ResponsavelId = 1, CriadoEm = DateTime.Now, GrauParentescoId = 3 }
            );
        #endregion
        #region StatusConsulta Default
        mdBuilder.Entity<StatusConsulta>()
            .HasData(
                new StatusConsulta
                {
                    StatusConsultaId = 1,
                    DescStatusConsulta = "Agendada"
                },
                new StatusConsulta
                {
                    StatusConsultaId = 2,
                    DescStatusConsulta = "Encerrada"
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
        #endregion

        mdBuilder.Entity<TipoMedicacao>().HasData(
                new TipoMedicacao { TipoMedicacaoId = 1, DescMedicacao = "Aplicado pela boca", TituloTipoMedicacao = "Via oral", ClasseAplicacao = EnumClasseAplicacaoMedicacao.Enteral },
                new TipoMedicacao { TipoMedicacaoId = 2, DescMedicacao = "Aplicado  por dembaixo da língua", TituloTipoMedicacao = "Sublingual", ClasseAplicacao = EnumClasseAplicacaoMedicacao.Enteral },
                new TipoMedicacao { TipoMedicacaoId = 3, DescMedicacao = "Aplicado pelo canal retal", TituloTipoMedicacao = "Supositorios", ClasseAplicacao = EnumClasseAplicacaoMedicacao.Enteral },
                new TipoMedicacao { TipoMedicacaoId = 4, DescMedicacao = "Aplicada diretamente no sangue", TituloTipoMedicacao = "Intravenosa", ClasseAplicacao = EnumClasseAplicacaoMedicacao.Parenteral },
                new TipoMedicacao { TipoMedicacaoId = 5, DescMedicacao = "Aplicada diretamente no músculo", TituloTipoMedicacao = "Intramuscular", ClasseAplicacao = EnumClasseAplicacaoMedicacao.Parenteral },
                new TipoMedicacao { TipoMedicacaoId = 6, DescMedicacao = "Aplicada debaixo da pele", TituloTipoMedicacao = "Subcutânea", ClasseAplicacao = EnumClasseAplicacaoMedicacao.Parenteral },
                new TipoMedicacao { TipoMedicacaoId = 7, DescMedicacao = string.Empty, TituloTipoMedicacao = "Respiratória", ClasseAplicacao = EnumClasseAplicacaoMedicacao.Parenteral },
                new TipoMedicacao { TipoMedicacaoId = 8, DescMedicacao = "Aplicada por pomadas", TituloTipoMedicacao = "Via tópica", ClasseAplicacao = EnumClasseAplicacaoMedicacao.Parenteral },
                new TipoMedicacao { TipoMedicacaoId = 9, DescMedicacao = string.Empty, TituloTipoMedicacao = "Via Ocular", ClasseAplicacao = EnumClasseAplicacaoMedicacao.Parenteral },
                new TipoMedicacao { TipoMedicacaoId = 10, DescMedicacao = string.Empty, TituloTipoMedicacao = "Via Nasal", ClasseAplicacao = EnumClasseAplicacaoMedicacao.Parenteral },
                new TipoMedicacao { TipoMedicacaoId = 11, DescMedicacao = string.Empty, TituloTipoMedicacao = "Via Auricular", ClasseAplicacao = EnumClasseAplicacaoMedicacao.Parenteral }
            );
        mdBuilder.Entity<Especialidade>()
            .HasData(
                new Especialidade { EspecialidadeId = 1, DescEspecialidade = "Cardiologia" },
                new Especialidade { EspecialidadeId = 2, DescEspecialidade = "Dermatologia" },
                new Especialidade { EspecialidadeId = 3, DescEspecialidade = "Ginecologia/Obstetrícia" },
                new Especialidade { EspecialidadeId = 4, DescEspecialidade = "Ortopedia" },
                new Especialidade { EspecialidadeId = 5, DescEspecialidade = "Anestesiologia" },
                new Especialidade { EspecialidadeId = 6, DescEspecialidade = "Pediatria" },
                new Especialidade { EspecialidadeId = 7, DescEspecialidade = "Oftalmologia" },
                new Especialidade { EspecialidadeId = 8, DescEspecialidade = "Psiquiatria" },
                new Especialidade { EspecialidadeId = 9, DescEspecialidade = "Urologia" },
                new Especialidade { EspecialidadeId = 10, DescEspecialidade = "Oncologia" },
                new Especialidade { EspecialidadeId = 11, DescEspecialidade = "Endocrinologia" },
                new Especialidade { EspecialidadeId = 12, DescEspecialidade = "Neurologia" },
                new Especialidade { EspecialidadeId = 13, DescEspecialidade = "Hematologia" },
                new Especialidade { EspecialidadeId = 14, DescEspecialidade = "Cirurgia Plástica" }
            );

        mdBuilder.Entity<GrauParentesco>()
            .HasData(
            new GrauParentesco
            {
                GrauParentescoId = 1,
                DescGrauParentesco = "Mãe"
            },
            new GrauParentesco
            {
                GrauParentescoId = 2,
                DescGrauParentesco = "Pai"
            },
            new GrauParentesco
            {
                GrauParentescoId = 3,
                DescGrauParentesco = "Filha/Filho"
            },
            new GrauParentesco
            {
                GrauParentescoId = 4,
                DescGrauParentesco = "Esposa"
            },
            new GrauParentesco
            {
                GrauParentescoId = 5,
                DescGrauParentesco = "Marido"
            }
            );
    }
}
