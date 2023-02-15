using Microsoft.EntityFrameworkCore;
using WEB_API_HealTime.Models;
using WEB_API_HealTime.Models.Enuns;

namespace WEB_API_HealTime.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<Pessoa> Pessoas { get; set; }
    public DbSet<ContatoPessoa> ContatoPessoas { get; set; }
    public DbSet<ResponsavelPaciente> ResponsaveisPacientes { get; set; }
    public DbSet<GrauParentesco> GrausParentesco { get; set; }
    public DbSet<CuidadorPaciente> CuidadorPacientes { get; set; }
    public DbSet<PrescricaoPaciente> PrescricaoPacientes { get; set; }
    public DbSet<EnderecoPessoa> EnderecoPessoas { get; set; }
    public DbSet<Medicacao> Medicacoes { get; set; }
    public DbSet<PrescricaoMedicamento> PrescricaoMedicamentos { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        /* - -------- PESSOAS -------- -*/
        modelBuilder.Entity<Pessoa>()
            .HasKey(key => key.PessoaId)
            .HasName("PK_Pessoas");
<<<<<<< HEAD

=======
>>>>>>> ELABORACAO_CONTROLLERS
        modelBuilder.Entity<Pessoa>()
            .Property(tp => tp.TipoPessoa)
            .HasDefaultValue(TipoPessoa.Paciente_Capaz);
        modelBuilder.Entity<Pessoa>()
            .Property(nome => nome.NomePessoa)
            .HasColumnType("VARCHAR(30)");
        modelBuilder.Entity<Pessoa>()
            .Property(sNome => sNome.SobrenomePessoa)
            .HasColumnType("VARCHAR(50)");
        modelBuilder.Entity<Pessoa>()
            .Property(cpf => cpf.CpfPessoa)
            .HasColumnType("CHAR(11)");
        modelBuilder.Entity<Pessoa>()
            .Property(dt => dt.DtUltimoAcesso)
            .HasColumnType("SMALLDATETIME")
            .HasDefaultValueSql("GETDATE()");
        modelBuilder.Entity<Pessoa>()
            .Property(dtn => dtn.DtNascimentoPessoa)
            .HasColumnType("SMALLDATETIME")
            .IsRequired();
        modelBuilder.Entity<Pessoa>()
            .Property(gen => gen.GeneroPessoa)
            .IsRequired();
        modelBuilder.Entity<Pessoa>()
            .Property(obs => obs.ObsPacienteIncapaz)
            .HasColumnType("VARCHAR(350)");

        /* - -------- Relação: PESSOAS-CONTATOPESSOAS -> 1-1 -------- -*/

        modelBuilder.Entity<ContatoPessoa>()
            .HasOne<Pessoa>(one => one.Pessoa)
            .WithMany(many => many.ContatosPessoas)
                .HasForeignKey(fk => fk.PessoaId)
                .HasConstraintName("FK_Pessoas_ContatosPessoas");

        /* - -------- CONTATOPESSOAS -------- -*/

        modelBuilder.Entity<ContatoPessoa>()
            .HasKey(key => key.ContatoId)
            .HasName("PK_ContatoPessoas");

        modelBuilder.Entity<ContatoPessoa>()
            .Property(tel => tel.TelefoneCelularObri)
            .HasColumnType("VARCHAR(11)")
            .IsRequired();
        modelBuilder.Entity<ContatoPessoa>()
            .Property(tel => tel.TelefoneCelularOpcional)
            .HasColumnType("VARCHAR(11)");
        modelBuilder.Entity<ContatoPessoa>()
            .Property(tel => tel.TelefoneFixo)
            .HasColumnType("VARCHAR(10)");
        modelBuilder.Entity<ContatoPessoa>()
            .Property(tel => tel.EmailContato)
            .HasColumnType("VARCHAR(70)");
        modelBuilder.Entity<ContatoPessoa>()
            .Property(tipo => tipo.TipoCtt)
            .IsRequired();

        /* - -------- Relação: PESSOAS-RESPONSAVEISPACIENTE -> 1-1 -------- -*/

        modelBuilder.Entity<ResponsavelPaciente>()
            .HasKey(pk => pk.ResponsavelPacienteId)
                .HasName("PK_ResponsavelPacienteId");

        /* - -------- Relação: PESSOAS-RESPONSAVEISPACIENTE(PacienteInId - Pessoas) -> 1-1 -------- -*/

        modelBuilder.Entity<ResponsavelPaciente>()
            .HasOne<Pessoa>(one => one.PacienteId)
            .WithMany(many => many.PacienteIdInRe)
                .HasForeignKey(fk => fk.PacienteInId)
                .HasConstraintName("FK_PESSOAS_RESPONSAVELPACIENTE_PACIENTEINID");

                
        /* - -------- Relação: PESSOAS-RESPONSAVEISPACIENTE(ResponsavelId - Pessoas) -> 1-1 -------- -*/

        modelBuilder.Entity<ResponsavelPaciente>()
            .HasOne<Pessoa>(one => one.IdResponsavel)
            .WithMany(many => many.ResponsavelIdRe)
                .HasForeignKey(fk => fk.ResponsavelId)
                .HasConstraintName("FK_PESSOAS_RESPONSAVELPACIENTE_RESPONSAVELID");

        /* - -------- RESPONSAVEISPACIENTE -------- -*/

        modelBuilder.Entity<ResponsavelPaciente>()
            .HasKey(pk => pk.ResponsavelPacienteId)
                .HasName("PK_ResponsavelPacienteId");
        modelBuilder.Entity<ResponsavelPaciente>()
            .Property(pk => pk.ResponsavelPacienteId)
            .HasColumnType("VARCHAR(40)");
        modelBuilder.Entity<Models.ResponsavelPaciente>()
            .Property(dt => dt.CriadoEm)
            .HasColumnType("SMALLDATETIME")
            .HasDefaultValueSql("GETDATE()")
            .IsRequired();

        /* - -------- Relação: RESPONSAVEISPACIENTE-GRAUPARENTESCO -> 1-1 -------- -*/

        modelBuilder.Entity<GrauParentesco>()
            .HasOne<ResponsavelPaciente>(rp => rp.ResponsavelPacientes)
            .WithOne(gp => gp.GrauParentesco)
                .HasForeignKey<ResponsavelPaciente>(fk => fk.GrauParentescoId)
                .HasConstraintName("FK_ResponsavelPaciente_GRAUPARENTESCO");


        /* - -------- GRAUPARENTESCO -------- -*/

        modelBuilder.Entity<GrauParentesco>()
            .HasKey(pk => pk.GrauParentescoId)
            .HasName("PK_GrauParentescoId");

        modelBuilder.Entity<GrauParentesco>()
            .Property(desc => desc.DescGrauParentesco)
            .HasColumnType("VARCHAR(30)");

        /* - -------- Relação: PESSOAS-CUIDADORPACIENTE(PacienteIncapazId - PacienteInIdCpRE) -> 1-1 -------- -*/

        modelBuilder.Entity<CuidadorPaciente>()
            .HasOne<Pessoa>(one => one.PacienteIncapazRelacaoNoPessoas)
            .WithMany(many => many.PacienteInIdCpRE)
                .HasForeignKey(fk => fk.PacienteIncapazId)
                .HasConstraintName("FK_PESSOAS_CUIDADORPACIENTE_PacienteIncapazId");


        /* - -------- Relação: PESSOAS-CUIDADORPACIENTE(ResponsavelReCP - ResponsavelIdCpRE) -> 1-1 -------- -*/

        modelBuilder.Entity<CuidadorPaciente>()
            .HasOne<Pessoa>(one => one.ResponsavelRelacaoNoPessoas)
            .WithMany(many => many.ResponsavelIdCpRE)
                .HasForeignKey(fk => fk.ResponsavelId)
                .HasConstraintName("FK_PESSOAS_CUIDADORPACIENTE_RESPONSAVELID");

        /* - -------- Relação: PESSOAS-CUIDADORPACIENTE(ResponsavelReCP - ResponsavelIdCpRE) -> 1-1 -------- -*/

        modelBuilder.Entity<CuidadorPaciente>()
            .HasOne<Pessoa>(one => one.CuidadorRelacaoNoPessoas)
            .WithMany(many => many.CuidadorIdCpRE)
                .HasForeignKey(fk => fk.CuidadorId)
                .HasConstraintName("FK_PESSOAS_CUIDADORPACIENTE_CuidadorId");

        /* - -------- CUIDADORPACIENTE -------- -*/

        modelBuilder.Entity<CuidadorPaciente>()
            .HasKey(pk => pk.CuidadorPacienteId)
                .HasName("PK_CuidadorPacienteId");

        modelBuilder.Entity<CuidadorPaciente>()
            .Property(dt => dt.CriadoEm)
            .HasColumnType("SMALLDATETIME")
            .HasDefaultValueSql("GETDATE()");

        /* - -------- Relação: PESSOAS-PRESCRICAPACIENTE(PrescricaoPacientesDesc - PacienteRePresc) -> 1-N -------- -*/

        modelBuilder.Entity<PrescricaoPaciente>()
            .HasOne<Pessoa>(one => one.PacienteRePresc)
            .WithMany(many => many.PrescricaoPacientesDesc)
                .HasForeignKey(fk => fk.PacienteId)
                .HasConstraintName("FK_PESSOAS_PRESCRICAOPACIENTE_PacienteId");
        
        /* - -------- PRESCRICAOPACIENTE -------- -*/

        modelBuilder.Entity<PrescricaoPaciente>()
        .HasKey(pk => pk.PrescricaoPacienteId)
            .HasName("PK_PrescricaoPacienteId");

        modelBuilder.Entity<PrescricaoPaciente>()
            .Property(dt => dt.DataCadastroSistemaPrescricao)
            .HasColumnType("SMALLDATETIME")
            .HasDefaultValueSql("GETDATE()");
        modelBuilder.Entity<PrescricaoPaciente>()
        .Property(dt => dt.EmissaoPrescricao)
        .HasColumnType("SMALLDATETIME")
        .IsRequired();
        
        modelBuilder.Entity<PrescricaoPaciente>()
        .Property(desc => desc.DescFichaPessoa)
        .HasColumnType("VARCHAR(300)");

        /* - -------- Relação: PESSOAS-ENDERECOPESSOAS(Pessoas) -> 1-1 -------- -*/

            modelBuilder.Entity<EnderecoPessoa>()
            .HasOne<Pessoa>(one => one.Pessoa)
            .WithOne(one => one.EnderecoPessoa)
                .HasForeignKey<EnderecoPessoa>(fk => fk.PessoaId)
                .HasConstraintName("FK_EnderecoPessoas_Pessoas");

        /*- -------- ENDERECOPESSOAS -------- -*/

        modelBuilder.Entity<EnderecoPessoa>()
            .HasKey(id => id.PessoaId)
            .HasName("PK_EnderecoPessoa");

        modelBuilder.Entity<EnderecoPessoa>()
            .Property(end => end.Endereco)
            .HasColumnType("VARCHAR(40)")
            .IsRequired();
        modelBuilder.Entity<EnderecoPessoa>()
            .Property(br => br.BairroEndereco)
            .HasColumnType("VARCHAR(40)");
        modelBuilder.Entity<EnderecoPessoa>()
            .Property(cd => cd.CidadeEndereco)
            .HasColumnType("VARCHAR(40)")
            .IsRequired();
        modelBuilder.Entity<EnderecoPessoa>()
            .Property(cpl => cpl.Complemento)
            .HasColumnType("VARCHAR(40)");
        modelBuilder.Entity<EnderecoPessoa>()
            .Property(cep => cep.CepEndereco)
            .HasColumnType("CHAR(8)")
            .IsRequired();
        modelBuilder.Entity<EnderecoPessoa>()
            .Property(uf => uf.UfEndereco)
            .IsRequired();

        /* - -------- Relação: PRESCRICAOMEDICAMENTOS-PRESCRICAOPACIENTES() -> N-1 -------- -*/
        
        modelBuilder.Entity<PrescricaoMedicamento>()
            .HasOne<PrescricaoPaciente>(one => one.PrescricaoPaciente)
            .WithMany(pm => pm.PrescricaoMedicamentos)
            .HasForeignKey(fk => fk.PrescricaoPacienteId)
                .HasConstraintName("FK_PrescricaoPacienteId");

        /*- -------- PRESCRICAOMEDICAMENTOS -------- -*/

        modelBuilder.Entity<PrescricaoMedicamento>()
            .HasKey(pk => pk.PrescricaoMedicamentoId)
            .HasName("PK_PrescricaoMedicamentoId");
        
        modelBuilder.Entity<PrescricaoMedicamento>()
            .Property(p => p.HrInicioDtMedicacao)
            .HasColumnType("SMALLDATETIME")
            .IsRequired();
        modelBuilder.Entity<PrescricaoMedicamento>()
            .Property(p => p.DtTerminoTratamento)
            .HasColumnType("SMALLDATETIME");
        modelBuilder.Entity<PrescricaoMedicamento>()
            .Property(p => p.QtdDiariaMedia)
            .IsRequired();
        modelBuilder.Entity<PrescricaoMedicamento>()
            .Property(p => p.CheckSituacao)
            .HasDefaultValue(true);
        modelBuilder.Entity<PrescricaoMedicamento>()
            .Property(p => p.NomeMedicamento)
            .IsRequired()
            .HasColumnType("VARCHAR(30)");
        /* - -------- Relação: PRESCRICAOMEDICAMENTOS-MEDICACAO -> 1-N -------- -*/

        modelBuilder.Entity<PrescricaoMedicamento>()
            .HasOne<Medicacao>(one => one.Medicacao)
            .WithOne(many => many.PrescricaoMedicamento)
                .HasForeignKey<PrescricaoMedicamento>(fk => fk.MedicacaoId)
                .HasConstraintName("FK_PrescricaoMedicamento_Medicacoes__MedicamentoId");

        /*- -------- MEDICACAO -------- -*/

        modelBuilder.Entity<Medicacao>()
            .HasKey(pk => pk.MedicacaoId)
            .HasName("PK_MedicacaoId");
        modelBuilder.Entity<Medicacao>()
            .Property(p => p.DtValidade)
            .HasColumnType("SMALLDATETIME")
            .IsRequired();
        modelBuilder.Entity<Medicacao>()
            .Property(p => p.Fabricante)
            .HasColumnType("VARCHAR(300)")
            .IsRequired();
        modelBuilder.Entity<Medicacao>()
            .Property(p => p.Nome)
            .HasColumnType("VARCHAR(30)")
            .IsRequired();
        modelBuilder.Entity<Medicacao>()
            .Property(p => p.StatusMedicacao)
            .HasDefaultValue(true);
        modelBuilder.Entity<Medicacao>()
            .Property(qtd => qtd.QtdMedicacao)
            .IsRequired();
        
        /*- -------- Relação: TipoMedicamento -------- -*/

        modelBuilder.Entity<Medicacao>()
            .HasOne<TipoMedicacao>(pk => pk.TipoMedicacao)
            .WithOne(pk => pk.Medicacao)
                .HasForeignKey<Medicacao>(fk => fk.TipoMedicacaoId)
                .HasConstraintName("FK_Medicacao_TipoMedicacao_TipoMedicacaoId");

        /*- -------- TIPOMEDICAMENTO -------- -*/

        modelBuilder.Entity<TipoMedicacao>()
            .HasKey(pk => pk.TipoMedicacaoId)
            .HasName("PK_TipoMedicamentoId");
        modelBuilder.Entity<TipoMedicacao>()
            .Property(p => p.DescMedicacao)
            .HasColumnType("VARCHAR(50)");

        /*- -------- Relaçao: ESTOQUE-Medicacao -------- -*/

        modelBuilder.Entity<Estoque>()
            .HasOne<Medicacao>(fk => fk.Medicacao)
            .WithOne(fk => fk.Estoque)
                .HasForeignKey<Estoque>(fk => fk.MedicacaoId)
                .HasConstraintName("FK_Estoque_Medicacoes");

        /*- -------- ESTOQUE -------- -*/

        modelBuilder.Entity<Estoque>()
            .HasKey(pk => pk.MedicacaoId)
            .HasName("PK_Estoque_MedicacaoId");
        
        modelBuilder.Entity<Estoque>()
            .Property(p => p.AtualizadoEm)
            .HasColumnType("SMALLDATETIME")
            .HasDefaultValueSql("GETDATE()");
        modelBuilder.Entity<Estoque>()
            .Property(p => p.CriadoEm)
            .HasColumnType("SMALLDATETIME")
            .IsRequired();//Adicionar manualmente esse valor devido a ser adicionado uma vez e testar
        modelBuilder.Entity<Estoque>()
            .Property(p => p.Desc)
            .HasColumnType("VARCHAR(200)")
            .IsRequired();
        modelBuilder.Entity<Estoque>()
            .Property(p => p.Nome)
            .IsRequired()
            .HasColumnType("VARCHAR(40)");

        /*- -------- Relaçao: ANDAMENTOMEDICACAO-PRESCRICAOMEDICAMENTO -------- -*/

        modelBuilder.Entity<PrescricaoMedicamento>()
            .HasMany<AndamentoMedicacao>( n => n.AndamentoMedicacoes)
            .WithOne(i => i.PrescricaoMedicamento)
                .HasForeignKey(fk => fk.PrescricaoMedicamentoId)
                .HasConstraintName("FK_PrescricaoMedicamentoId");

        /*- -------- ANDAMENTOMEDICACAO -------- -*/

        modelBuilder.Entity<AndamentoMedicacao>()
            .HasKey(pk => pk.AndamentoMedicacaoId)
            .HasName("PK_AndamentoMedicacaoId");
        modelBuilder.Entity<AndamentoMedicacao>()
            .Property(p => p.CriadoEm)
            .HasColumnType("SMALLDATETIME")
            .HasDefaultValueSql("GETDATE()")
            .IsRequired();

        ///*- -------- Relação: BAIXAHISTORICOESTOQUE - ESTOQUE - 1 - N -------- -*/

        modelBuilder.Entity<BaixaHistoricoEstoque>()
            .HasOne<Estoque>(p => p.Estoque)
            .WithMany(p => p.BaixaHistoricoEstoques)
                .HasForeignKey(fk => fk.EstoqueId)
                .HasConstraintName("FK_Estoque_BaixaHistoricoEstoques");

        /*- -------- BAIXAHISTORICOESTOQUE -------- -*/

        modelBuilder.Entity<BaixaHistoricoEstoque>()
            .HasKey(pk => pk.BaixaHistoricoEstoqueId)
            .HasName("PK_BaixaHistoricoEstoqueId");
        

    
    }
}
