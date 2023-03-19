﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WEB_API_HealTime.Data;

#nullable disable

namespace WEB_API_HealTime.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WEB_API_HealTime.Models.ConsultasMedicas.ConsultaAgendada", b =>
                {
                    b.Property<int>("ConsultasAgendadasId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ConsultasAgendadasId"));

                    b.Property<DateTime>("DataConsulta")
                        .HasColumnType("DATE");

                    b.Property<DateTime>("DataSolicitacaoConsulta")
                        .HasColumnType("DATE");

                    b.Property<string>("Encaminhamento")
                        .IsRequired()
                        .HasColumnType("CHAR(1)");

                    b.Property<int>("EspecialidadeId")
                        .HasColumnType("int");

                    b.Property<int>("MedicoId")
                        .HasColumnType("int");

                    b.Property<string>("MotivoConsulta")
                        .HasColumnType("VARCHAR(300)");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.Property<int>("StatusConsultasId")
                        .HasColumnType("int");

                    b.HasKey("ConsultasAgendadasId")
                        .HasName("PK_ConsultaAgendadaId");

                    b.HasIndex("MedicoId")
                        .IsUnique();

                    b.ToTable("ConsultasAgendadas");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.ConsultasMedicas.Medico", b =>
                {
                    b.Property<int>("MedicoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MedicoId"));

                    b.Property<string>("CrmMedico")
                        .HasColumnType("CHAR(6)");

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
                            CrmMedico = "054321",
                            NmMedico = "Dr Val",
                            UfCrmMedico = "SP"
                        },
                        new
                        {
                            MedicoId = 2,
                            CrmMedico = "012345",
                            NmMedico = "Dr Teste",
                            UfCrmMedico = "RJ"
                        });
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.ConsultasMedicas.StatusConsulta", b =>
                {
                    b.Property<int>("StatusConsultaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatusConsultaId"));

                    b.Property<string>("DescStatusConsulta")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusConsultaId");

                    b.ToTable("StatusConsultas");
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

                    b.Property<int>("StatusMedicacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<int>("TipoMedicacaoId")
                        .HasColumnType("int");

                    b.HasKey("MedicacaoId")
                        .HasName("PK_MedicacaoId");

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

                    b.HasData(
                        new
                        {
                            PessoaId = 1,
                            CpfPessoa = "12345678909",
                            DtNascPessoa = new DateTime(2004, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NomePessoa = "Dan",
                            PasswordHash = new byte[] { 209, 89, 174, 250, 246, 40, 155, 173, 168, 176, 167, 107, 42, 190, 222, 205, 13, 74, 117, 174, 255, 103, 243, 6, 224, 29, 179, 107, 225, 91, 60, 96, 162, 170, 14, 79, 134, 206, 163, 75, 110, 112, 160, 215, 29, 50, 96, 16, 20, 19, 15, 2, 245, 183, 22, 19, 41, 103, 172, 47, 133, 166, 123, 58 },
                            PasswordSalt = new byte[] { 221, 252, 226, 120, 53, 97, 92, 111, 69, 154, 132, 204, 2, 67, 42, 85, 16, 99, 225, 152, 102, 72, 173, 17, 238, 71, 13, 113, 220, 29, 61, 74, 71, 146, 176, 234, 122, 153, 81, 149, 130, 206, 107, 230, 20, 125, 42, 225, 238, 252, 79, 37, 239, 4, 248, 205, 167, 161, 182, 38, 88, 251, 159, 187, 243, 34, 57, 186, 30, 53, 212, 83, 66, 132, 149, 55, 18, 136, 105, 47, 140, 171, 65, 113, 46, 159, 155, 154, 45, 63, 233, 193, 119, 8, 123, 123, 228, 58, 76, 15, 121, 143, 228, 244, 76, 84, 175, 147, 175, 92, 17, 185, 58, 15, 112, 13, 249, 25, 195, 174, 234, 250, 247, 244, 228, 201, 143, 227 },
                            SobreNomePessoa = "Marzo",
                            TipoPessoaId = 1
                        });
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

                    b.Property<string>("StatusMedicacaoFlag")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("CHAR(1)")
                        .HasDefaultValue("S");

                    b.HasKey("PrescricaoPacienteId", "MedicacaoId")
                        .HasName("PK_CONCAT_PrescricaPacienteId_MedicacaoId");

                    b.HasIndex("MedicacaoId")
                        .IsUnique();

                    b.HasIndex("PrescricaoPacienteId");

                    b.ToTable("PrescricoesMedicacoes");
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

                    b.Property<string>("FlagStatus")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("CHAR(1)")
                        .HasDefaultValue("S");

                    b.Property<int>("MedicoId")
                        .HasColumnType("int");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Validade")
                        .HasColumnType("DATETIME");

                    b.HasKey("PrescricaoPacienteId")
                        .HasName("PK_PrescricaoPacienteId");

                    b.HasIndex("MedicoId");

                    b.HasIndex("PacienteId");

                    b.ToTable("PrescricaoPacientes");
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

                    b.HasData(
                        new
                        {
                            TipoMedicacaoId = 1,
                            ClasseAplicacao = 1,
                            DescMedicacao = "Experimental",
                            TituloTipoMedicacao = "NASAL"
                        },
                        new
                        {
                            TipoMedicacaoId = 2,
                            ClasseAplicacao = 2,
                            DescMedicacao = "Experimental EXPERIMENTE CALADO",
                            TituloTipoMedicacao = "PILULA"
                        });
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.ConsultasMedicas.ConsultaAgendada", b =>
                {
                    b.HasOne("WEB_API_HealTime.Models.ConsultasMedicas.Medico", "Medico")
                        .WithOne("ConsultaAgendada")
                        .HasForeignKey("WEB_API_HealTime.Models.ConsultasMedicas.ConsultaAgendada", "MedicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_MedicoId_ConsultaAgendadaId");

                    b.Navigation("Medico");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.Medicacoes.Medicacao", b =>
                {
                    b.HasOne("WEB_API_HealTime.Models.Medicacoes.TipoMedicacao", "TipoMedicacao")
                        .WithMany("Medicacoes")
                        .HasForeignKey("TipoMedicacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Medicacao_TipoMedicacao");

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
                        .WithMany("PrescricoesPacientes")
                        .HasForeignKey("MedicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_PrescricaoPaciente_Medico");

                    b.HasOne("WEB_API_HealTime.Models.Medicacoes.Pessoa", "Pessoa")
                        .WithMany("PrescricaoPacientes")
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_PacienteId_PrescricoesPacientes");

                    b.Navigation("Medico");

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.ConsultasMedicas.Medico", b =>
                {
                    b.Navigation("ConsultaAgendada");

                    b.Navigation("PrescricoesPacientes");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.Medicacoes.Medicacao", b =>
                {
                    b.Navigation("PrescricaoMedicacao");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.Medicacoes.Pessoa", b =>
                {
                    b.Navigation("PrescricaoPacientes");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.Medicacoes.PrescricaoPaciente", b =>
                {
                    b.Navigation("PrescricoesMedicacoes");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.Medicacoes.TipoMedicacao", b =>
                {
                    b.Navigation("Medicacoes");
                });
#pragma warning restore 612, 618
        }
    }
}
