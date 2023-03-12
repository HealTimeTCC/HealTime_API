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
    [Migration("20230312165334_StatusMedicacao_value_default")]
    partial class StatusMedicacao_value_default
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WEB_API_HealTime.Models.ConsultasMedicas.Medico", b =>
                {
                    b.Property<int>("MedicoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MedicoId"));

                    b.Property<int>("CrmMedico")
                        .HasColumnType("INT");

                    b.Property<string>("NmMedico")
                        .IsRequired()
                        .HasColumnType("VARCHAR(40)");

                    b.Property<string>("UfCrmMedico")
                        .IsRequired()
                        .HasColumnType("CHAR(2)");

                    b.HasKey("MedicoId")
                        .HasName("PK_MedicoId");

                    b.ToTable("Medicos");

                    b.HasData(
                        new
                        {
                            MedicoId = 1,
                            CrmMedico = 12345,
                            NmMedico = "Dr Val",
                            UfCrmMedico = "SP"
                        },
                        new
                        {
                            MedicoId = 2,
                            CrmMedico = 12345,
                            NmMedico = "Dr Teste",
                            UfCrmMedico = "RJ"
                        });
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.Medicacoes.Medicacao", b =>
                {
                    b.Property<int>("MedicacaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MedicacaoId"));

                    b.Property<string>("CompostoAtivoMedicacao")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Generico")
                        .IsRequired()
                        .HasColumnType("CHAR(1)");

                    b.Property<string>("LaboratorioMedicaocao")
                        .IsRequired()
                        .HasColumnType("VARCHAR(80)");

                    b.Property<string>("NomeMedicacao")
                        .IsRequired()
                        .HasColumnType("VARCHAR(80)");

                    b.Property<int>("StatusMedicacaoId")
                        .HasColumnType("int");

                    b.Property<int>("TipoMedicacaoId")
                        .HasColumnType("int");

                    b.HasKey("MedicacaoId")
                        .HasName("PK_MedicacaoId");

                    b.HasIndex("StatusMedicacaoId");

                    b.HasIndex("TipoMedicacaoId");

                    b.ToTable("Medicacoes");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.Medicacoes.Pessoa", b =>
                {
                    b.Property<int>("PessoaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PessoaId"));

                    b.Property<string>("CpfPessoa")
                        .IsRequired()
                        .HasColumnType("CHAR(11)");

                    b.Property<DateTime?>("DtNascPessoa")
                        .IsRequired()
                        .HasColumnType("DATE");

                    b.Property<string>("NomePessoa")
                        .IsRequired()
                        .HasColumnType("VARCHAR(25)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("SobreNomePessoa")
                        .IsRequired()
                        .HasColumnType("VARCHAR(30)");

                    b.Property<int?>("TipoPessoaId")
                        .IsRequired()
                        .HasColumnType("INT");

                    b.HasKey("PessoaId")
                        .HasName("PK_PessoaId");

                    b.ToTable("Pessoas");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.Medicacoes.PrescricaoMedicacao", b =>
                {
                    b.Property<int>("PrescricaoPacienteId")
                        .HasColumnType("int");

                    b.Property<int>("MedicacaoId")
                        .HasColumnType("int");

                    b.Property<int>("Duracao")
                        .HasColumnType("int");

                    b.Property<int>("Intervalo")
                        .HasColumnType("int");

                    b.Property<int>("Qtde")
                        .HasColumnType("int");

                    b.HasKey("PrescricaoPacienteId", "MedicacaoId")
                        .HasName("PK_CONCAT_PrescricaPacienteId_MedicacaoId");

                    b.HasIndex("MedicacaoId")
                        .IsUnique();

                    b.ToTable("PrescricaoMedicacao");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.Medicacoes.PrescricaoPaciente", b =>
                {
                    b.Property<int>("PrescricaoPacienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PrescricaoPacienteId"));

                    b.Property<DateTime?>("CriadoEm")
                        .IsRequired()
                        .HasColumnType("DATETIME");

                    b.Property<string>("DescFichaPessoa")
                        .HasColumnType("VARCHAR(350)");

                    b.Property<DateTime>("Emissao")
                        .HasColumnType("DATETIME");

                    b.Property<int>("MedicoId")
                        .HasColumnType("int");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Validade")
                        .HasColumnType("DATETIME");

                    b.HasKey("PrescricaoPacienteId")
                        .HasName("PK_PrescricaoPacienteId");

                    b.HasIndex("MedicoId")
                        .IsUnique();

                    b.ToTable("PrescricaoPacientes");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.Medicacoes.StatusMedicacao", b =>
                {
                    b.Property<int>("StatusMedicacaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatusMedicacaoId"));

                    b.Property<string>("DescStatusMedicacao")
                        .HasColumnType("VARCHAR(25)");

                    b.HasKey("StatusMedicacaoId")
                        .HasName("PK_StatusMedicacaoId");

                    b.ToTable("StatusMedicacoes");

                    b.HasData(
                        new
                        {
                            StatusMedicacaoId = 1,
                            DescStatusMedicacao = "ATIVO"
                        },
                        new
                        {
                            StatusMedicacaoId = 2,
                            DescStatusMedicacao = "INATIVO"
                        },
                        new
                        {
                            StatusMedicacaoId = 3,
                            DescStatusMedicacao = "EFEITO COLATERAL GRAVE"
                        },
                        new
                        {
                            StatusMedicacaoId = 4,
                            DescStatusMedicacao = "REAÇÃO GRAVE"
                        });
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.Medicacoes.TipoMedicacao", b =>
                {
                    b.Property<int>("TipoMedicacaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TipoMedicacaoId"));

                    b.Property<int>("ClasseAplicacao")
                        .HasColumnType("int");

                    b.Property<string>("DescMedicacao")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("TituloTipoMedicacao")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("TipoMedicacaoId")
                        .HasName("PK_TipoMedicacaoId");

                    b.ToTable("TiposMedicacoes");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.Medicacoes.Medicacao", b =>
                {
                    b.HasOne("WEB_API_HealTime.Models.Medicacoes.StatusMedicacao", "StatusMedicacao")
                        .WithMany()
                        .HasForeignKey("StatusMedicacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WEB_API_HealTime.Models.Medicacoes.TipoMedicacao", "TipoMedicacao")
                        .WithMany()
                        .HasForeignKey("TipoMedicacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StatusMedicacao");

                    b.Navigation("TipoMedicacao");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.Medicacoes.PrescricaoMedicacao", b =>
                {
                    b.HasOne("WEB_API_HealTime.Models.Medicacoes.Medicacao", "Medicacao")
                        .WithOne("PrescricaoMedicacao")
                        .HasForeignKey("WEB_API_HealTime.Models.Medicacoes.PrescricaoMedicacao", "MedicacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("PK_MedicacaoId_PrescricaoMedicao");

                    b.HasOne("WEB_API_HealTime.Models.Medicacoes.PrescricaoPaciente", "PrescricaoPaciente")
                        .WithMany("PrescricoesMedicacoes")
                        .HasForeignKey("PrescricaoPacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("PK_PrescricaoPacienteId_PrescricaoMedicao");

                    b.Navigation("Medicacao");

                    b.Navigation("PrescricaoPaciente");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.Medicacoes.PrescricaoPaciente", b =>
                {
                    b.HasOne("WEB_API_HealTime.Models.ConsultasMedicas.Medico", "Medico")
                        .WithOne("PrescricaoPaciente")
                        .HasForeignKey("WEB_API_HealTime.Models.Medicacoes.PrescricaoPaciente", "MedicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_PrescricaoPaciente_Medico");

                    b.Navigation("Medico");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.ConsultasMedicas.Medico", b =>
                {
                    b.Navigation("PrescricaoPaciente");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.Medicacoes.Medicacao", b =>
                {
                    b.Navigation("PrescricaoMedicacao");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.Medicacoes.PrescricaoPaciente", b =>
                {
                    b.Navigation("PrescricoesMedicacoes");
                });
#pragma warning restore 612, 618
        }
    }
}
