﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WEB_API_HealTime.Data;

#nullable disable

namespace WEB_API_HealTime.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230225002005_MudandoNome")]
    partial class MudandoNome
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WEB_API_HealTime.Models.AndamentoMedicacao", b =>
                {
                    b.Property<int>("AndamentoMedicacaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AndamentoMedicacaoId"));

                    b.Property<DateTime>("CriadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("SMALLDATETIME")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("PrescricaoMedicamentoId")
                        .HasColumnType("int");

                    b.Property<int>("QtdAtual")
                        .HasColumnType("int");

                    b.Property<int>("QtdInicial")
                        .HasColumnType("int");

                    b.HasKey("AndamentoMedicacaoId")
                        .HasName("PK_AndamentoMedicacaoId");

                    b.HasIndex("PrescricaoMedicamentoId");

                    b.ToTable("AndamentoMedicacao");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.BaixaHistoricoEstoque", b =>
                {
                    b.Property<int>("BaixaHistoricoEstoqueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BaixaHistoricoEstoqueId"));

                    b.Property<DateTime?>("BaixaEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("DescBaixa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EstoqueId")
                        .HasColumnType("int");

                    b.HasKey("BaixaHistoricoEstoqueId")
                        .HasName("PK_BaixaHistoricoEstoqueId");

                    b.HasIndex("EstoqueId");

                    b.ToTable("BaixaHistoricoEstoque");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.ContatoPessoa", b =>
                {
                    b.Property<int>("ContatoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContatoId"));

                    b.Property<string>("EmailContato")
                        .HasColumnType("VARCHAR(70)");

                    b.Property<int>("PessoaId")
                        .HasColumnType("int");

                    b.Property<string>("TelefoneCelularObri")
                        .IsRequired()
                        .HasColumnType("VARCHAR(11)");

                    b.Property<string>("TelefoneCelularOpcional")
                        .HasColumnType("VARCHAR(11)");

                    b.Property<string>("TelefoneFixo")
                        .HasColumnType("VARCHAR(10)");

                    b.Property<int>("TipoCtt")
                        .HasColumnType("int");

                    b.HasKey("ContatoId")
                        .HasName("PK_ContatoPessoas");

                    b.HasIndex("PessoaId");

                    b.ToTable("ContatoPessoas");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.CuidadorPaciente", b =>
                {
                    b.Property<int>("CuidadorPacienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CuidadorPacienteId"));

                    b.Property<DateTime?>("CriadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("SMALLDATETIME")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int?>("CuidadorId")
                        .HasColumnType("int");

                    b.Property<int?>("PacienteIncapazId")
                        .HasColumnType("int");

                    b.Property<int?>("ResponsavelId")
                        .HasColumnType("int");

                    b.HasKey("CuidadorPacienteId")
                        .HasName("PK_CuidadorPacienteId");

                    b.HasIndex("CuidadorId");

                    b.HasIndex("PacienteIncapazId");

                    b.HasIndex("ResponsavelId");

                    b.ToTable("CuidadorPacientes");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.EnderecoPessoa", b =>
                {
                    b.Property<int?>("PessoaId")
                        .HasColumnType("int");

                    b.Property<string>("BairroEndereco")
                        .HasColumnType("VARCHAR(40)");

                    b.Property<string>("CepEndereco")
                        .IsRequired()
                        .HasColumnType("CHAR(8)");

                    b.Property<string>("CidadeEndereco")
                        .IsRequired()
                        .HasColumnType("VARCHAR(40)");

                    b.Property<string>("Complemento")
                        .HasColumnType("VARCHAR(40)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("VARCHAR(40)");

                    b.Property<int>("UfEndereco")
                        .HasColumnType("int");

                    b.HasKey("PessoaId")
                        .HasName("PK_EnderecoPessoa");

                    b.ToTable("EnderecoPessoas");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.Estoque", b =>
                {
                    b.Property<int>("MedicacaoId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("AtualizadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("SMALLDATETIME")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime?>("CriadoEm")
                        .IsRequired()
                        .HasColumnType("SMALLDATETIME");

                    b.Property<string>("Desc")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(40)");

                    b.Property<int>("QtdEstoque")
                        .HasColumnType("int");

                    b.HasKey("MedicacaoId")
                        .HasName("PK_Estoque_EstoqueId");

                    b.ToTable("Estoque");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.GrauParentesco", b =>
                {
                    b.Property<int>("GrauParentescoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GrauParentescoId"));

                    b.Property<string>("DescGrauParentesco")
                        .HasColumnType("VARCHAR(30)");

                    b.HasKey("GrauParentescoId")
                        .HasName("PK_GrauParentescoId");

                    b.ToTable("GrausParentesco");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.Medicacao", b =>
                {
                    b.Property<int>("MedicacaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MedicacaoId"));

                    b.Property<int>("Composicao")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(30)");

                    b.Property<int?>("QtdMedicacao")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<bool?>("StatusMedicacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<int>("TipoMedicacaoId")
                        .HasColumnType("int");

                    b.HasKey("MedicacaoId")
                        .HasName("PK_MedicacaoId");

                    b.HasIndex("TipoMedicacaoId");

                    b.ToTable("Medicacoes");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.Pessoa", b =>
                {
                    b.Property<int?>("PessoaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("PessoaId"));

                    b.Property<string>("CpfPessoa")
                        .HasColumnType("CHAR(11)");

                    b.Property<DateTime?>("DtNascimentoPessoa")
                        .IsRequired()
                        .HasColumnType("SMALLDATETIME");

                    b.Property<DateTime?>("DtUltimoAcesso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("SMALLDATETIME")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("GeneroPessoa")
                        .HasColumnType("int");

                    b.Property<string>("NomePessoa")
                        .HasColumnType("VARCHAR(30)");

                    b.Property<string>("ObsPacienteIncapaz")
                        .HasColumnType("VARCHAR(350)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("SobrenomePessoa")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<int?>("TipoPessoa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.HasKey("PessoaId")
                        .HasName("PK_Pessoas");

                    b.ToTable("Pessoas");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.PrescricaoMedicamento", b =>
                {
                    b.Property<int>("PrescricaoMedicamentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PrescricaoMedicamentoId"));

                    b.Property<bool?>("CheckSituacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime?>("DtTerminoTratamento")
                        .HasColumnType("SMALLDATETIME");

                    b.Property<DateTime?>("HrInicioDtMedicacao")
                        .IsRequired()
                        .HasColumnType("SMALLDATETIME");

                    b.Property<int?>("IntervaloMedicacao")
                        .HasColumnType("int");

                    b.Property<int>("MedicacaoId")
                        .HasColumnType("int");

                    b.Property<string>("NomeMedicamento")
                        .IsRequired()
                        .HasColumnType("VARCHAR(30)");

                    b.Property<int?>("PrescricaoPacienteId")
                        .HasColumnType("int");

                    b.Property<int?>("QtdDiariaMedia")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("PrescricaoMedicamentoId")
                        .HasName("PK_PrescricaoMedicamentoId");

                    b.HasIndex("MedicacaoId")
                        .IsUnique();

                    b.HasIndex("PrescricaoPacienteId");

                    b.ToTable("PrescricaoMedicamentos");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.PrescricaoPaciente", b =>
                {
                    b.Property<int>("PrescricaoPacienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PrescricaoPacienteId"));

                    b.Property<DateTime?>("DataCadastroSistema")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("SMALLDATETIME")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("DescFichaPessoa")
                        .HasColumnType("VARCHAR(300)");

                    b.Property<DateTime?>("EmissaoPrescricao")
                        .IsRequired()
                        .HasColumnType("SMALLDATETIME");

                    b.Property<int?>("PacienteId")
                        .HasColumnType("int");

                    b.HasKey("PrescricaoPacienteId")
                        .HasName("PK_PrescricaoPacienteId");

                    b.HasIndex("PacienteId");

                    b.ToTable("PrescricaoPacientes");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.ResponsavelPaciente", b =>
                {
                    b.Property<string>("ResponsavelPacienteId")
                        .HasColumnType("VARCHAR(40)");

                    b.Property<DateTime>("CriadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("SMALLDATETIME")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int?>("GrauParentescoId")
                        .HasColumnType("int");

                    b.Property<int?>("PacienteInId")
                        .HasColumnType("int");

                    b.Property<int?>("ResponsavelId")
                        .HasColumnType("int");

                    b.HasKey("ResponsavelPacienteId")
                        .HasName("PK_ResponsavelPacienteId");

                    b.HasIndex("GrauParentescoId")
                        .IsUnique()
                        .HasFilter("[GrauParentescoId] IS NOT NULL");

                    b.HasIndex("PacienteInId");

                    b.HasIndex("ResponsavelId");

                    b.ToTable("ResponsaveisPacientes");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.TipoMedicacao", b =>
                {
                    b.Property<int>("TipoMedicacaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TipoMedicacaoId"));

                    b.Property<int>("ClasseAplicacao")
                        .HasColumnType("int");

                    b.Property<string>("DescMedicacao")
                        .HasColumnType("VARCHAR(300)");

                    b.Property<string>("TituloTipoMedicacao")
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("TipoMedicacaoId")
                        .HasName("PK_TipoMedicamentoId");

                    b.ToTable("TipoMedicacoes");

                    b.HasData(
                        new
                        {
                            TipoMedicacaoId = 1,
                            ClasseAplicacao = 1,
                            DescMedicacao = "Aplicação pela boca",
                            TituloTipoMedicacao = "Via oral"
                        },
                        new
                        {
                            TipoMedicacaoId = 2,
                            ClasseAplicacao = 1,
                            DescMedicacao = "Aplicação por debaixo da lingua",
                            TituloTipoMedicacao = "Sublingual"
                        },
                        new
                        {
                            TipoMedicacaoId = 3,
                            ClasseAplicacao = 1,
                            DescMedicacao = "Aplicação retal",
                            TituloTipoMedicacao = "Supositorios"
                        },
                        new
                        {
                            TipoMedicacaoId = 4,
                            ClasseAplicacao = 2,
                            DescMedicacao = "Direta no sangue",
                            TituloTipoMedicacao = "Intravenosa"
                        },
                        new
                        {
                            TipoMedicacaoId = 5,
                            ClasseAplicacao = 2,
                            DescMedicacao = "Direta no músculo",
                            TituloTipoMedicacao = "Intramuscular"
                        },
                        new
                        {
                            TipoMedicacaoId = 6,
                            ClasseAplicacao = 2,
                            DescMedicacao = "Debaixo da pele",
                            TituloTipoMedicacao = "Subcutânea"
                        },
                        new
                        {
                            TipoMedicacaoId = 7,
                            ClasseAplicacao = 2,
                            DescMedicacao = "Via que se estende desde a mucosa nasal até os pulmões",
                            TituloTipoMedicacao = "Respiratória"
                        },
                        new
                        {
                            TipoMedicacaoId = 8,
                            ClasseAplicacao = 2,
                            DescMedicacao = "Aplicação na pele (Pomadas)",
                            TituloTipoMedicacao = "Via tópica"
                        },
                        new
                        {
                            TipoMedicacaoId = 9,
                            ClasseAplicacao = 2,
                            DescMedicacao = "Aplicação direta no olho",
                            TituloTipoMedicacao = "Via Ocular"
                        },
                        new
                        {
                            TipoMedicacaoId = 10,
                            ClasseAplicacao = 2,
                            DescMedicacao = "Aplicação pelo nariz",
                            TituloTipoMedicacao = "Via Nasal"
                        },
                        new
                        {
                            TipoMedicacaoId = 11,
                            ClasseAplicacao = 2,
                            DescMedicacao = "Aplicação no ouvido",
                            TituloTipoMedicacao = "Via Auricular"
                        });
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.AndamentoMedicacao", b =>
                {
                    b.HasOne("WEB_API_HealTime.Models.PrescricaoMedicamento", "PrescricaoMedicamento")
                        .WithMany("AndamentoMedicacoes")
                        .HasForeignKey("PrescricaoMedicamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_PrescricaoMedicamentoId");

                    b.Navigation("PrescricaoMedicamento");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.BaixaHistoricoEstoque", b =>
                {
                    b.HasOne("WEB_API_HealTime.Models.Estoque", "Estoque")
                        .WithMany("BaixaHistoricoEstoques")
                        .HasForeignKey("EstoqueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Estoque_BaixaHistoricoEstoques");

                    b.Navigation("Estoque");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.ContatoPessoa", b =>
                {
                    b.HasOne("WEB_API_HealTime.Models.Pessoa", "Pessoa")
                        .WithMany("ContatosPessoas")
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Pessoas_ContatosPessoas");

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.CuidadorPaciente", b =>
                {
                    b.HasOne("WEB_API_HealTime.Models.Pessoa", "CuidadorRelacaoNoPessoas")
                        .WithMany("CuidadorIdCpRE")
                        .HasForeignKey("CuidadorId")
                        .HasConstraintName("FK_PESSOAS_CUIDADORPACIENTE_CuidadorId");

                    b.HasOne("WEB_API_HealTime.Models.Pessoa", "PacienteIncapazRelacaoNoPessoas")
                        .WithMany("PacienteInIdCpRE")
                        .HasForeignKey("PacienteIncapazId")
                        .HasConstraintName("FK_PESSOAS_CUIDADORPACIENTE_PacienteIncapazId");

                    b.HasOne("WEB_API_HealTime.Models.Pessoa", "ResponsavelRelacaoNoPessoas")
                        .WithMany("ResponsavelIdCpRE")
                        .HasForeignKey("ResponsavelId")
                        .HasConstraintName("FK_PESSOAS_CUIDADORPACIENTE_RESPONSAVELID");

                    b.Navigation("CuidadorRelacaoNoPessoas");

                    b.Navigation("PacienteIncapazRelacaoNoPessoas");

                    b.Navigation("ResponsavelRelacaoNoPessoas");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.EnderecoPessoa", b =>
                {
                    b.HasOne("WEB_API_HealTime.Models.Pessoa", "Pessoa")
                        .WithOne("EnderecoPessoa")
                        .HasForeignKey("WEB_API_HealTime.Models.EnderecoPessoa", "PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_EnderecoPessoas_Pessoas");

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.Estoque", b =>
                {
                    b.HasOne("WEB_API_HealTime.Models.Medicacao", "Medicacao")
                        .WithOne("Estoque")
                        .HasForeignKey("WEB_API_HealTime.Models.Estoque", "MedicacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Estoque_Medicacoes");

                    b.Navigation("Medicacao");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.Medicacao", b =>
                {
                    b.HasOne("WEB_API_HealTime.Models.TipoMedicacao", "TipoMedicacao")
                        .WithMany("Medicacoes")
                        .HasForeignKey("TipoMedicacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Medicacao_TipoMedicacao_TipoMedicacaoId");

                    b.Navigation("TipoMedicacao");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.PrescricaoMedicamento", b =>
                {
                    b.HasOne("WEB_API_HealTime.Models.Medicacao", "Medicacao")
                        .WithOne("PrescricaoMedicamento")
                        .HasForeignKey("WEB_API_HealTime.Models.PrescricaoMedicamento", "MedicacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_PrescricaoMedicamento_Medicacoes__MedicamentoId");

                    b.HasOne("WEB_API_HealTime.Models.PrescricaoPaciente", "PrescricaoPaciente")
                        .WithMany("PrescricaoMedicamentos")
                        .HasForeignKey("PrescricaoPacienteId")
                        .HasConstraintName("FK_PrescricaoPacienteId");

                    b.Navigation("Medicacao");

                    b.Navigation("PrescricaoPaciente");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.PrescricaoPaciente", b =>
                {
                    b.HasOne("WEB_API_HealTime.Models.Pessoa", "PacienteRePresc")
                        .WithMany("PrescricaoPacientesDesc")
                        .HasForeignKey("PacienteId")
                        .HasConstraintName("FK_PESSOAS_PRESCRICAOPACIENTE_PacienteId");

                    b.Navigation("PacienteRePresc");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.ResponsavelPaciente", b =>
                {
                    b.HasOne("WEB_API_HealTime.Models.GrauParentesco", "GrauParentesco")
                        .WithOne("ResponsavelPacientes")
                        .HasForeignKey("WEB_API_HealTime.Models.ResponsavelPaciente", "GrauParentescoId")
                        .HasConstraintName("FK_ResponsavelPaciente_GRAUPARENTESCO");

                    b.HasOne("WEB_API_HealTime.Models.Pessoa", "PacienteId")
                        .WithMany("PacienteIdInRe")
                        .HasForeignKey("PacienteInId")
                        .HasConstraintName("FK_PESSOAS_RESPONSAVELPACIENTE_PACIENTEINID");

                    b.HasOne("WEB_API_HealTime.Models.Pessoa", "IdResponsavel")
                        .WithMany("ResponsavelIdRe")
                        .HasForeignKey("ResponsavelId")
                        .HasConstraintName("FK_PESSOAS_RESPONSAVELPACIENTE_RESPONSAVELID");

                    b.Navigation("GrauParentesco");

                    b.Navigation("IdResponsavel");

                    b.Navigation("PacienteId");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.Estoque", b =>
                {
                    b.Navigation("BaixaHistoricoEstoques");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.GrauParentesco", b =>
                {
                    b.Navigation("ResponsavelPacientes");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.Medicacao", b =>
                {
                    b.Navigation("Estoque");

                    b.Navigation("PrescricaoMedicamento");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.Pessoa", b =>
                {
                    b.Navigation("ContatosPessoas");

                    b.Navigation("CuidadorIdCpRE");

                    b.Navigation("EnderecoPessoa");

                    b.Navigation("PacienteIdInRe");

                    b.Navigation("PacienteInIdCpRE");

                    b.Navigation("PrescricaoPacientesDesc");

                    b.Navigation("ResponsavelIdCpRE");

                    b.Navigation("ResponsavelIdRe");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.PrescricaoMedicamento", b =>
                {
                    b.Navigation("AndamentoMedicacoes");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.PrescricaoPaciente", b =>
                {
                    b.Navigation("PrescricaoMedicamentos");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.TipoMedicacao", b =>
                {
                    b.Navigation("Medicacoes");
                });
#pragma warning restore 612, 618
        }
    }
}
